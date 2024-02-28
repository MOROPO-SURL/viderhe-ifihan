using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Enumerations;
using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Presentation.Models.View;

namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Presentation.Views
{
    public partial class LandscapeAnonimusHeroPlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        public LandscapeAnonimusHeroPlacardView(LandscapeAnonimusHeroPlacardViewModel model, double relativeSizeScaleFactor) : base(relativeSizeScaleFactor)
        {
            InitializeComponent();

            BindingContext = model;

            MaskBackgroundImagen.Source = Xamarin.Forms.ImageSource.FromResource(string.Format("MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Presentation.Assets.Images.Placard-Hero-{0}.png", model.BackgroundMode), GetType().Assembly);

            var accountInformationProvider = Xamarin.Forms.DependencyService.Get<Common.Presentation.Providers.Facade.IAccountInformationProviderFacade>();

            switch (model.BackgroundMode)
            {
                case AnonimusHeroBackgroundMode.OldPaper:
                    LogoImage.Source = FFImageLoading.Svg.Forms.SvgImageSource.FromResource("MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Presentation.Assets.Images.MF-Identity-Landscape.svg", GetType().Assembly);

                    HeaderLabel.TextColor = accountInformationProvider.PrimaryColor;
                    ContentLabel.TextColor = accountInformationProvider.SecoundaryColor;

                    break;

                case AnonimusHeroBackgroundMode.GrayGranite:
                    LogoImage.Source = FFImageLoading.Svg.Forms.SvgImageSource.FromResource("MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Presentation.Assets.Images.MF-Identity-Landscape-Color-Secoundary.svg", GetType().Assembly);

                    HeaderLabel.TextColor = accountInformationProvider.SecoundaryColor;
                    ContentLabel.TextColor = accountInformationProvider.SecoundaryColor;

                    break;

                case AnonimusHeroBackgroundMode.OrangeGranite:
                default:
                    LogoImage.Source = FFImageLoading.Svg.Forms.SvgImageSource.FromResource("MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Presentation.Assets.Images.MF-Identity-Landscape-Color-White.svg", GetType().Assembly);

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

            var internalShowInStoryboard = new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.Storyboard
            {
                IsParallel = true
            };

            internalShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.ScaleToAnimation
            {
                Target = MaskBackgroundImagen,
                Scale = 1,
                EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.Linear,
                Duration="500"
            });
            internalShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.ScaleToAnimation
            {
                Target = LogoImage,
                Scale = 1,
                EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.SpringOut,
                Delay = "1500",
                Duration = "500"
            });
            internalShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.FadeInAnimation
            {
                Target = HeaderLabel,
                Direction = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Down,
                EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicIn,
                Delay = "2000",
                Duration = "500"
            });
            internalShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.FadeInAnimation
            {
                Target = ContentLabel,
                Direction = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Down,
                EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicIn,
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