using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Enumerations;
using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Presentation.Models.View;
using MOROPO.VIDERHE.Extend.Essential.Templating.Presentation.Extensions;

namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Presentation.Views
{
    public partial class LandscapeFillFlyoutPlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        private Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView contexteImageView;

        public LandscapeFillFlyoutPlacardView(LandscapeFillFlyoutPlacardViewModel model, double relativeSizeScaleFactor) : base(relativeSizeScaleFactor)
        {
            InitializeComponent();

            BindingContext = model;

            FillFlyoutImage.Source = FFImageLoading.Svg.Forms.SvgImageSource.FromResource(string.Format("MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Presentation.Assets.Images.Placard-Flyout-Fill-{0}-{1}-{2}.svg", model.FlyoutShapeKind, model.FlyoutHorizontalOrientation, model.FlyoutBackgroundColorMode), GetType().Assembly);
            LogoImage.Source = model.FlyoutBackgroundColorMode == FlyoutBackgroundColorMode.Light ?
                FFImageLoading.Svg.Forms.SvgImageSource.FromResource("MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Presentation.Assets.Images.MF-Identity-Landscape.svg", GetType().Assembly) :
                FFImageLoading.Svg.Forms.SvgImageSource.FromResource("MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Presentation.Assets.Images.MF-Identity-Landscape-Color-White.svg", GetType().Assembly);

            if (model.FlyoutBackgroundColorMode == FlyoutBackgroundColorMode.Light)
            {
                var accountInformationProvider = Xamarin.Forms.DependencyService.Get<Common.Presentation.Providers.Facade.IAccountInformationProviderFacade>();

                HeaderLabel.TextColor = accountInformationProvider.PrimaryColor;
                ContentLabel.TextColor = accountInformationProvider.SecoundaryColor;
            }

            switch (model.FlyoutHorizontalOrientation)
            {
                case FlyoutHorizontalOrientation.Left:
                    Xamarin.Forms.Grid.SetColumn(FlyoutDataGrid, 0);

                    break;
                case FlyoutHorizontalOrientation.Right:
                default:
                    Xamarin.Forms.Grid.SetColumn(FlyoutDataGrid, 1);

                    break;
            }

            if (model.ContextedImageLayoutMode == Essential.Templating.Enumerations.PictureLayoutMode.AspectFitWithOpaqueAspectFilledBySelf)
            {
                contexteImageView = new Essential.Templating.Presentation.Views.SelfOpaqueFillSimplePicturePlacardView(new Essential.Templating.Presentation.Models.View.SelfOpaqueFillSimplePicturePlacardViewModel
                {
                    Aspect = Xamarin.Forms.Aspect.AspectFit,
                    ScreenPresentationTime = System.TimeSpan.Zero,
                    Source = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(model.ContextedImage.Id)),
                    ThumnailSource = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildImageThumbnailUri(model.ContextedImage.Id)),
                    ZoomingEnabled = false
                }, relativeSizeScaleFactor);
            }
            else
            {
                contexteImageView = new Essential.Templating.Presentation.Views.SimplePicturePlacardView(new Essential.Templating.Presentation.Models.View.SimplePicturePlacardViewModel
                {
                    Aspect =model.ContextedImageLayoutMode.ToXamarinFormsAspect(),
                    ScreenPresentationTime = System.TimeSpan.Zero,
                    Source = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(model.ContextedImage.Id)),
                    ZoomingEnabled = false
                }, relativeSizeScaleFactor);
            }

            PlacardLayout.Children.Insert(0, contexteImageView);
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

            var model = BindingContext as LandscapeFillFlyoutPlacardViewModel;

            if (model.FlyoutHorizontalOrientation == FlyoutHorizontalOrientation.Left)
            {
                FlyoutGrid.TranslationX = PlacardLayout.Width * -1;
            }
            else
            {
                FlyoutGrid.TranslationX = PlacardLayout.Width;
            }

            FlyoutGrid.IsVisible = true;

            var internalShowInStoryboard = new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.Storyboard
            {
                Delay = "2000",
                IsParallel = true
            };

            internalShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.TranslateToXAnimation
            {
                Target = FlyoutGrid,
                TranslateX = 0,
                EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut
            });
            internalShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.FadeInAnimation
            {
                Target = LogoImage,
                Direction = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Up,
                EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicIn,
                Delay = "500",
                Duration = "800"
            });
            internalShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.FadeToAnimation
            {
                Target = HeaderLabel,
                Opacity=1,
                EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicIn,
                Delay = "1300",
                Duration = "500"
            });
            internalShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.FadeToAnimation
            {
                Target = ContentLabel,
                Opacity=1,
                EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicIn,
                Delay = "1550",
                Duration = "500"
            });

            if (model.ContextedImageCenteredAtPresentation)
            {
                internalShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.TranslateToXAnimation
                {
                    Target = contexteImageView,
                    TranslateX = model.FlyoutHorizontalOrientation == FlyoutHorizontalOrientation.Left ? PlacardLayout.Width / 4d : PlacardLayout.Width / 4d * -1,
                    EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                    Delay = "100"
                });
            }

            internalShowInStoryboard.Begin();

            if (model.ContextedImageZoomingEnabled)
            {
                var presentedImageZoominAnimation = new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.ScaleToAnimation
                {
                    Target = contexteImageView,
                    Scale = 1.2,
                    Duration = model.ScreenPresentationTime.TotalMilliseconds.ToString()
                };

                presentedImageZoominAnimation.Begin();
            }
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            PlacardLayout.Children.RemoveAt(0);

            contexteImageView.Dispose();

            contexteImageView = null;

            FillFlyoutImage.Source = null;
            LogoImage.Source = null;
        }
    }
}