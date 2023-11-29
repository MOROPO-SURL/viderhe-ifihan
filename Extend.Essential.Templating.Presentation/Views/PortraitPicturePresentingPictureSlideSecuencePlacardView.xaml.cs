using MOROPO.VIDERHE.Extend.Common.Templating.Enumerations;
using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Presenters;
using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Views;
using MOROPO.VIDERHE.Extend.Essential.Templating.Descriptors;
using MOROPO.VIDERHE.Extend.Essential.Templating.Enumerations;
using MOROPO.VIDERHE.Extend.Essential.Templating.Models.Context;
using MOROPO.VIDERHE.Support.Presentation.Factories;
using MOROPO.VIDERHE.Support.Presentation.Models.View;
using MOROPO.VIDERHE.Extend.Common.Presentation.Views;
using MOROPO.VIDERHE.Extend.Essential.Templating.Presentation.Extensions;

namespace MOROPO.VIDERHE.Extend.Essential.Templating.Presentation.Views
{
    public partial class PortraitPicturePresentingPictureSlideSecuencePlacardView : BaseTemplatedPlacardPresentationView
    {
        private ScreenplayPresenter screenplayPresenter;

        public PortraitPicturePresentingPictureSlideSecuencePlacardView(Models.View.PortraitPicturePresentingPictureSlideSecuencePlacardViewModel model, double relativeSizeScaleFactor) : base(relativeSizeScaleFactor)
        {
            InitializeComponent();

            BindingContext = model;
        }

        public override Xamarin.Forms.Layout<Xamarin.Forms.View> WrapLayout => Wrapper;

        public override Xamarin.Forms.View PlacardView => FramesContainerWrapper;

        public override void ConfigureLayout(Xamarin.Forms.View view)
        {
            Xamarin.Forms.Grid.SetColumn(view, 0);
            Xamarin.Forms.Grid.SetRow(view, 0);
        }

        public override void PerformPlacardStarup()
        {
            base.PerformPlacardStarup();

            var placards = new System.Collections.Generic.List<PlacardViewModel>();

            var targetTemplateDescriptor = new Descriptors.SimplePictureTemplateDescriptor();

            var targetTemplateViewModel = new Support.Presentation.Models.View.TemplateViewModel
            {
                Id = targetTemplateDescriptor.Id,
                PlayerOrientationSupport = PlayerOrientationSupportKind.Any
            };

            foreach (var item in (BindingContext as Models.View.PortraitPicturePresentingPictureSlideSecuencePlacardViewModel).PresentedPictureSlideSecuence.Slides)
            {
                placards.Add(new Support.Presentation.Models.View.PlacardViewModel
                {
                    Id = System.Guid.NewGuid(),
                    Template = targetTemplateViewModel,
                    SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Templating.Models.Context.SimplePicturePlacardContextModel
                    {
                        Image = item.Image,
                        LayoutMode = item.LayoutMode,
                        ScreenPresentationTime = System.TimeSpan.FromSeconds((BindingContext as Models.View.PortraitPicturePresentingPictureSlideSecuencePlacardViewModel).PresentedPictureSlideSecuence.PicturePresentationSecounds),
                        IsZoomingEnabled = true
                    })
                });
            }

            screenplayPresenter = new Common.Templating.Presentation.Presenters.ScreenplayPresenter(FramesContainer, PlacardViewModelToPresentationView, placards.ToArray(), new Providers.PictureSlideSecuenceTransitionProvider(), EndPresentation, false, null);

            screenplayPresenter.BeginPresentation();

            var height = FramesContainerWrapper.Width * (BindingContext as Models.View.PortraitPicturePresentingPictureSlideSecuencePlacardViewModel).PresenterImageHeigth / (BindingContext as Models.View.PortraitPicturePresentingPictureSlideSecuencePlacardViewModel).PresenterImageWidth;

            if ((BindingContext as Models.View.PortraitPicturePresentingPictureSlideSecuencePlacardViewModel).PresenterSide == PortraitPresentationSide.Top)
            {
                PresenterImage.TranslationY = height * -1;
            }
            else
            {
                PresenterImage.TranslationY = height;
            }

            PresenterImage.IsVisible = true;

            var internalShowInStoryboard = new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.Storyboard
            {
                Delay = "2000",
                IsParallel = true
            };

            internalShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.TranslateToYAnimation
            {
                Target = PresenterImage,
                TranslateY = 0,
                EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut
            });

            if ((BindingContext as Models.View.PortraitPicturePresentingPictureSlideSecuencePlacardViewModel).PresentedPictureSlideSecuenceCenteredAtPresentation)
            {
                internalShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.TranslateToYAnimation
                {
                    Target = FramesContainer,
                    TranslateY = (BindingContext as Models.View.PortraitPicturePresentingPictureSlideSecuencePlacardViewModel).PresenterSide == PortraitPresentationSide.Top ? height / 2 : height / 2 * -1,
                    EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                    Delay = "100"
                });
            }

            internalShowInStoryboard.Begin();
        }

        private BasePlacardPresentationView PlacardViewModelToPresentationView(PlacardViewModel model, System.Func<Xamarin.Essentials.DisplayOrientation> getOrientationFunction, double relativeSizeScaleFactor)
        {
            if (model.Template.Id != SimplePictureTemplateDescriptor.ID) throw new System.InvalidOperationException();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<SimplePicturePlacardContextModel>(model.SerializedContext);

            if (context.LayoutMode == PictureLayoutMode.AspectFitWithOpaqueAspectFilledBySelf)
            {
                return new SelfOpaqueFillSimplePicturePlacardView(new Models.View.SelfOpaqueFillSimplePicturePlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    Source = Xamarin.Forms.ImageSource.FromUri(ImageUriFactory.BuildImageUri(context.Image.Id)),
                    ThumnailSource = Xamarin.Forms.ImageSource.FromUri(ThumbnailUriFactory.BuildThumbnailUri(context.Image.ThumbnailId)),
                    Aspect = context.LayoutMode.ToXamarinFormsAspect(),
                    ZoomingEnabled = context.IsZoomingEnabled
                }, relativeSizeScaleFactor);
            }
            else
            {
                return new SimplePicturePlacardView(new Models.View.SimplePicturePlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    Source = Xamarin.Forms.ImageSource.FromUri(ImageUriFactory.BuildImageUri(context.Image.Id)),
                    Aspect = context.LayoutMode.ToXamarinFormsAspect(),
                    ZoomingEnabled = context.IsZoomingEnabled
                }, relativeSizeScaleFactor);
            }
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            screenplayPresenter.Dispose();

            screenplayPresenter = null;
        }
    }
}