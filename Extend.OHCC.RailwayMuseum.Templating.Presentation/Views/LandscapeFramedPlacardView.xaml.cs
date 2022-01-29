namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Presentation.Views
{
    public partial class LandscapeFramedPlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        public LandscapeFramedPlacardView(Models.View.LandscapeFramedPlacardViewModel model, Common.Presentation.Providers.Facade.IAccountInformationProviderFacade accountInformationProvider)
        {
            InitializeComponent();

            BindingContext = model;

            var useLightFrame = false;

            switch (model.BackgroundMode)
            {
                case Enumerations.BackgroundMode.SolidPrimary:
                    PlacardLayout.BackgroundColor = accountInformationProvider.PrimaryColor;

                    useLightFrame = true;

                    break;
                case Enumerations.BackgroundMode.SolidSecoundary:
                    PlacardLayout.BackgroundColor = accountInformationProvider.SecoundaryColor;

                    useLightFrame = true;

                    break;
                case Enumerations.BackgroundMode.GradientLinearV1:
                    break;
                case Enumerations.BackgroundMode.GradientLinearV2:
                    break;
                case Enumerations.BackgroundMode.TextureWallPrimaryLigth:
                    break;
                case Enumerations.BackgroundMode.TextureWallPrimaryDark:
                    break;
                case Enumerations.BackgroundMode.TextureWallSecoundaryLigth:
                    break;
                case Enumerations.BackgroundMode.TextureWallSecoundaryDark:
                    break;
                case Enumerations.BackgroundMode.TextureOldPaper:
                    break;
                case Enumerations.BackgroundMode.TextureGraniteOrange:
                    break;
                case Enumerations.BackgroundMode.TextureGraniteGray:
                    break;
                case Enumerations.BackgroundMode.SolidLight:
                case Enumerations.BackgroundMode.SolidDark:
                default:
                    throw new System.InvalidOperationException();
            }

            switch (model.FrameStyle)
            {
                case Enumerations.FrameStyle.Fancy:
                    FrameImage.Source = FFImageLoading.Svg.Forms.SvgImageSource.FromResource(string.Format("SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Presentation.Assets.Images.Placard-Frame-Landscape-Bullet-{0}.svg", useLightFrame ? "White" : "Secoundary"), GetType().Assembly);

                    break;
                case Enumerations.FrameStyle.Tally:
                default:
                    FrameImage.Source = FFImageLoading.Svg.Forms.SvgImageSource.FromResource(string.Format("SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Presentation.Assets.Images.Placard-Frame-Landscape-Outline-{0}.svg", useLightFrame ? "White" : "Secoundary"), GetType().Assembly);

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

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            FrameImage.Source = null;
        }
    }
}