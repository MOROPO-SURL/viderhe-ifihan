using SkiaSharp.Views.Forms;
using SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Presentation.Extensions;
using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Views
{
    public partial class LeftLandscapeTranslucentContextualOverlapForImageSecuencePlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        private Common.Templating.Presentation.Presenters.ScreenplayPresenter screenplayPresenter;

        public LeftLandscapeTranslucentContextualOverlapForImageSecuencePlacardView(Models.View.LandscapeTranslucentContextualOverlapForImageSecuencePlacardViewModel model)
        {
            InitializeComponent();

            BindingContext = model;

            OverlapLayout.IsVisible = false;
        }

        public override Xamarin.Forms.Layout<Xamarin.Forms.View> WrapLayout => Wrapper;

        public override Xamarin.Forms.View PlacardView => PlacardLayout;

        public override void ConfigureLayout(Xamarin.Forms.View view)
        {
            Xamarin.Forms.Grid.SetColumn(view, 0);
            Xamarin.Forms.Grid.SetRow(view, 0);
        }

        public override void PerformPlacardStarup()
        {
            base.PerformPlacardStarup();

            var concreteBindingContext = BindingContext as Models.View.LandscapeTranslucentContextualOverlapForImageSecuencePlacardViewModel;

            var placards = new System.Collections.Generic.List<Support.Presentation.Models.View.PlacardViewModel>();

            var targetTemplateDescriptor = new Essential.Templating.Descriptors.SimplePictureTemplateDescriptor();

            var targetTemplateViewModel = new Support.Presentation.Models.View.TemplateViewModel
            {
                Id = targetTemplateDescriptor.Id,
                PlayerOrientationSupport = Common.Templating.Enumerations.PlayerOrientationSupportKind.Any
            };

            foreach (var item in concreteBindingContext.PresentedPictureSlideSecuence.Slides)
            {
                placards.Add(new Support.Presentation.Models.View.PlacardViewModel
                {
                    Id = System.Guid.NewGuid(),
                    Template = targetTemplateViewModel,
                    SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Essential.Templating.Models.Context.SimplePicturePlacardContextModel
                    {
                        Image = item.Image,
                        LayoutMode = item.LayoutMode,
                        ScreenPresentationTime = System.TimeSpan.FromSeconds(concreteBindingContext.PresentedPictureSlideSecuence.PicturePresentationSecounds),
                        IsZoomingEnabled = true
                    })
                });
            }

            screenplayPresenter = new Common.Templating.Presentation.Presenters.ScreenplayPresenter(FramesContainer, PlacardViewModelToPresentationView, placards.ToArray(), new Essential.Templating.Presentation.Providers.PictureSlideSecuenceTransitionProvider(), EndPresentation, false, null);

            screenplayPresenter.BeginPresentation();

            OverlapLayout.TranslationX = Width * (concreteBindingContext.OverlapSize.ToColumnCount() / 6d) * -1;

            OverlapLayout.IsVisible = true;

            int overlapShowInAnimationDuration = 650;
            int infoBlockShoInAnimationDuration = 600;

            var internalShowInStoryboard = new XFToolKit.Presentation.Transform.Animations.Storyboard
            {
                Delay = "2000",
                IsParallel = true
            };

            internalShowInStoryboard.Animations.Add(new XFToolKit.Presentation.Transform.Animations.TranslateToXAnimation
            {
                Target = OverlapLayout,
                TranslateX = 0,
                EasingType = XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                Duration = overlapShowInAnimationDuration.ToString()
            });
            internalShowInStoryboard.Animations.Add(new XFToolKit.Presentation.Transform.Animations.FadeInAnimation
            {
                Target = TitleLabel,
                Direction = XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Right,
                RelativeOffset = 100d,
                Delay = overlapShowInAnimationDuration.ToString(),
                EasingType = XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                Duration = infoBlockShoInAnimationDuration.ToString()
            });

            var index = 1;

            foreach (var infoBlockLayout in InfoBlocksLayout.Children)
            {
                internalShowInStoryboard.Animations.Add(new XFToolKit.Presentation.Transform.Animations.FadeInAnimation
                {
                    Target = infoBlockLayout,
                    Direction = XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Right,
                    RelativeOffset = 100d,
                    Delay = (overlapShowInAnimationDuration + infoBlockShoInAnimationDuration / 2 * index++).ToString(),
                    EasingType = XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                    Duration = infoBlockShoInAnimationDuration.ToString()
                });
            }

            internalShowInStoryboard.Begin();
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            screenplayPresenter.Dispose();

            screenplayPresenter = null;
        }

        private void OverlapContentWrapLayout_PaintSurface(object sender, SKPaintSurfaceEventArgs eventArgs)
        {
            var concreteBindingContext = BindingContext as Models.View.LandscapeTranslucentContextualOverlapForImageSecuencePlacardViewModel;

            eventArgs.Surface.Canvas.Clear();

            var paint = new SkiaSharp.SKPaint()
            {
                Style = SkiaSharp.SKPaintStyle.Fill,
                Color = (BindingContext as Models.View.LandscapeTranslucentContextualOverlapForImageSecuencePlacardViewModel).OverlapBackgroundColor.ToSKColor().WithAlpha(Providers.ConstantProvider.TRANSLUCED_OPACITY_LEVEL)
            };

            eventArgs.Surface.Canvas.DrawPath(concreteBindingContext.ToHorizontalSKPath(eventArgs.Info.Width, eventArgs.Info.Height, Wrapper.Width), paint);
        }

        private Common.Presentation.Views.BasePlacardPresentationView PlacardViewModelToPresentationView(Support.Presentation.Models.View.PlacardViewModel model)
        {
            if (model.Template.Id != Essential.Templating.Descriptors.SimplePictureTemplateDescriptor.ID) throw new System.InvalidOperationException();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Essential.Templating.Models.Context.SimplePicturePlacardContextModel>(model.SerializedContext);

            if (context.LayoutMode == Essential.Templating.Enumerations.PictureLayoutMode.AspectFitWithOpaqueAspectFilledBySelf)
            {
                return new Essential.Templating.Presentation.Views.SelfOpaqueFillSimplePicturePlacardView(new Essential.Templating.Presentation.Models.View.SelfOpaqueFillSimplePicturePlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    Source = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(context.Image.Id)),
                    ThumnailSource = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildThumbnailUri(context.Image.ThumbnailId)),
                    Aspect = context.LayoutMode.ToXamarinFormsAspect(),
                    ZoomingEnabled = context.IsZoomingEnabled
                });
            }
            else
            {
                return new Essential.Templating.Presentation.Views.SimplePicturePlacardView(new Essential.Templating.Presentation.Models.View.SimplePicturePlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    Source = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(context.Image.Id)),
                    Aspect = context.LayoutMode.ToXamarinFormsAspect(),
                    ZoomingEnabled = context.IsZoomingEnabled
                });
            }
        }
    }
}