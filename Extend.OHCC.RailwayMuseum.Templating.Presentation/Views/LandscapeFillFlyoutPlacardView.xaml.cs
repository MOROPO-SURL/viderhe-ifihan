using SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Presentation.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Presentation.Views
{
    public partial class LandscapeFillFlyoutPlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        private Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView contexteImageView;

        public LandscapeFillFlyoutPlacardView(Models.View.LandscapeFillFlyoutPlacardViewModel model)
        {
            InitializeComponent();

            BindingContext = model;

            FillFlyoutImage.Source = FFImageLoading.Svg.Forms.SvgImageSource.FromResource(string.Format("SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Presentation.Assets.Images.Placard-Flyout-Fill-{0}-{1}-{2}.svg", model.FlyoutShapeKind, model.FlyoutHorizontalOrientation, model.FlyoutBackgroundColorMode), GetType().Assembly);
            LogoImage.Source = model.FlyoutBackgroundColorMode == Enumerations.FlyoutBackgroundColorMode.Light ?
                FFImageLoading.Svg.Forms.SvgImageSource.FromResource("SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Presentation.Assets.Images.MF-Identity-Landscape.svg", GetType().Assembly) :
                FFImageLoading.Svg.Forms.SvgImageSource.FromResource("SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Presentation.Assets.Images.MF-Identity-Landscape-Color-White.svg", GetType().Assembly);

            if (model.FlyoutBackgroundColorMode == Enumerations.FlyoutBackgroundColorMode.Light)
            {
                var accountInformationProvider = Xamarin.Forms.DependencyService.Get<Common.Presentation.Providers.Facade.IAccountInformationProviderFacade>();

                HeaderLabel.TextColor = accountInformationProvider.PrimaryColor;
                ContentLabel.TextColor = accountInformationProvider.SecoundaryColor;
            }

            switch (model.FlyoutHorizontalOrientation)
            {
                case Enumerations.FlyoutHorizontalOrientation.Left:
                    Xamarin.Forms.Grid.SetColumn(FlyoutDataGrid, 0);

                    break;
                case Enumerations.FlyoutHorizontalOrientation.Right:
                default:
                    Xamarin.Forms.Grid.SetColumn(FlyoutDataGrid, 1);

                    break;
            }

            if (model.ContextedImageLayoutMode == Essential.Templating.Presentation.Enumerations.PictureLayoutMode.AspectFitWithOpaqueAspectFilledBySelf)
            {
                contexteImageView = new Essential.Templating.Presentation.Views.SelfOpaqueFillSimplePicturePlacardView(new Essential.Templating.Presentation.Models.View.SelfOpaqueFillSimplePicturePlacardViewModel
                {
                    Aspect = Xamarin.Forms.Aspect.AspectFit,
                    ScreenPresentationTime = System.TimeSpan.Zero,
                    Source = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(model.ContextedImage.Id)),
                    ThumnailSource = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildThumbnailUri(model.ContextedImage.ThumbnailId)),
                    ZoomingEnabled = false
                });
            }
            else
            {
                contexteImageView = new Essential.Templating.Presentation.Views.SimplePicturePlacardView(new Essential.Templating.Presentation.Models.View.SimplePicturePlacardViewModel
                {
                    Aspect =model.ContextedImageLayoutMode.ToXamarinFormsAspect(),
                    ScreenPresentationTime = System.TimeSpan.Zero,
                    Source = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(model.ContextedImage.Id)),
                    ZoomingEnabled = false
                });
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

            var model = BindingContext as Models.View.LandscapeFillFlyoutPlacardViewModel;

            if (model.FlyoutHorizontalOrientation == Enumerations.FlyoutHorizontalOrientation.Left)
            {
                FlyoutGrid.TranslationX = PlacardLayout.Width * -1;
            }
            else
            {
                FlyoutGrid.TranslationX = PlacardLayout.Width;
            }

            FlyoutGrid.IsVisible = true;

            var internalShowInStoryboard = new XFToolKit.Presentation.Transform.Animations.Storyboard
            {
                Delay = "2000",
                IsParallel = true
            };

            internalShowInStoryboard.Animations.Add(new XFToolKit.Presentation.Transform.Animations.TranslateToXAnimation
            {
                Target = FlyoutGrid,
                TranslateX = 0,
                EasingType = XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut
            });

            if (model.ContextedImageCenteredAtPresentation)
            {
                internalShowInStoryboard.Animations.Add(new XFToolKit.Presentation.Transform.Animations.TranslateToXAnimation
                {
                    Target = contexteImageView,
                    TranslateX = model.FlyoutHorizontalOrientation == Enumerations.FlyoutHorizontalOrientation.Left ? PlacardLayout.Width / 4d : PlacardLayout.Width / 4d * -1,
                    EasingType = XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                    Delay = "100"
                });
            }

            internalShowInStoryboard.Begin();

            if (model.ContextedImageZoomingEnabled)
            {
                var presentedImageZoominAnimation = new XFToolKit.Presentation.Transform.Animations.ScaleToAnimation
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