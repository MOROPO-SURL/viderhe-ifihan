namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Presentation.Views
{
    public partial class LandscapeAnonimusHeroPlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        public LandscapeAnonimusHeroPlacardView(Models.View.LandscapeAnonimusHeroPlacardViewModel model)
        {
            InitializeComponent();

            BindingContext = model;

            MaskBackgroundImagen.Source = Xamarin.Forms.ImageSource.FromResource(string.Format("SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Presentation.Assets.Images.Placard-Hero-{0}.png", model.BackgroundMode), GetType().Assembly);

            var accountInformationProvider = Xamarin.Forms.DependencyService.Get<Common.Presentation.Providers.Facade.IAccountInformationProviderFacade>();

            switch (model.BackgroundMode)
            {
                case Enumerations.AnonimusHeroBackgroundMode.OldPaper:
                    LogoImage.Source = FFImageLoading.Svg.Forms.SvgImageSource.FromResource("SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Presentation.Assets.Images.MF-Identity-Landscape.svg", GetType().Assembly);

                    HeaderLabel.TextColor = accountInformationProvider.PrimaryColor;
                    ContentLabel.TextColor = accountInformationProvider.SecoundaryColor;

                    break;

                case Enumerations.AnonimusHeroBackgroundMode.GrayGranite:
                    LogoImage.Source = FFImageLoading.Svg.Forms.SvgImageSource.FromResource("SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Presentation.Assets.Images.MF-Identity-Landscape-Color-Secoundary.svg", GetType().Assembly);

                    HeaderLabel.TextColor = accountInformationProvider.SecoundaryColor;
                    ContentLabel.TextColor = accountInformationProvider.SecoundaryColor;

                    break;

                case Enumerations.AnonimusHeroBackgroundMode.OrangeGranite:
                default:
                    LogoImage.Source = FFImageLoading.Svg.Forms.SvgImageSource.FromResource("SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Presentation.Assets.Images.MF-Identity-Landscape-Color-White.svg", GetType().Assembly);

                    HeaderLabel.TextColor = Xamarin.Forms.Color.White;
                    ContentLabel.TextColor = Xamarin.Forms.Color.White;

                    break;
            }
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

            var internalShowInStoryboard = new XFToolKit.Presentation.Transform.Animations.Storyboard
            {
                IsParallel = true
            };

            internalShowInStoryboard.Animations.Add(new XFToolKit.Presentation.Transform.Animations.ScaleToAnimation
            {
                Target = MaskBackgroundImagen,
                Scale = 1,
                EasingType = XFToolKit.Presentation.Transform.Enumerations.EasingType.Linear,
                Duration="500"
            });
            internalShowInStoryboard.Animations.Add(new XFToolKit.Presentation.Transform.Animations.ScaleToAnimation
            {
                Target = LogoImage,
                Scale = 1,
                EasingType = XFToolKit.Presentation.Transform.Enumerations.EasingType.SpringOut,
                Delay = "1500",
                Duration = "500"
            });
            internalShowInStoryboard.Animations.Add(new XFToolKit.Presentation.Transform.Animations.FadeInAnimation
            {
                Target = HeaderLabel,
                Direction = XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Down,
                EasingType = XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicIn,
                Delay = "2000",
                Duration = "500"
            });
            internalShowInStoryboard.Animations.Add(new XFToolKit.Presentation.Transform.Animations.FadeInAnimation
            {
                Target = ContentLabel,
                Direction = XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Down,
                EasingType = XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicIn,
                Delay = "2250",
                Duration = "500"
            });

            internalShowInStoryboard.Begin();
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            MaskBackgroundImagen.Source = null;
            HeroImage.Source = null;
            LogoImage.Source = null;
        }
    }
}