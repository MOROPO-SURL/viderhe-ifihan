using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Enumerations;
using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Presentation.Models.View;

namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Presentation.Views
{
    public partial class LandscapeFramedPlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        public LandscapeFramedPlacardView(LandscapeFramedPlacardViewModel model, double relativeSizeScaleFactor) : base(relativeSizeScaleFactor)
        {
            InitializeComponent();

            BindingContext = model;

            var accountInformationProvider = Xamarin.Forms.DependencyService.Get<Common.Presentation.Providers.Facade.IAccountInformationProviderFacade>();

            var useLightFrame = false;

            switch (model.BackgroundMode)
            {
                case BackgroundMode.SolidPrimary:
                    PlacardLayout.BackgroundColor = accountInformationProvider.PrimaryColor;

                    useLightFrame = true;

                    break;
                case BackgroundMode.SolidSecoundary:
                    PlacardLayout.BackgroundColor = accountInformationProvider.SecoundaryColor;

                    useLightFrame = true;

                    break;
                case BackgroundMode.GradientLinearV1:
                    break;
                case BackgroundMode.GradientLinearV2:
                    break;
                case BackgroundMode.TextureWallPrimaryLigth:
                    break;
                case BackgroundMode.TextureWallPrimaryDark:
                    break;
                case BackgroundMode.TextureWallSecoundaryLigth:
                    break;
                case BackgroundMode.TextureWallSecoundaryDark:
                    break;
                case BackgroundMode.TextureOldPaper:
                    break;
                case BackgroundMode.TextureGraniteOrange:
                    break;
                case BackgroundMode.TextureGraniteGray:
                    break;
                case BackgroundMode.SolidLight:
                case BackgroundMode.SolidDark:
                default:
                    throw new System.InvalidOperationException();
            }

            switch (model.FrameStyle)
            {
                case FrameStyle.Fancy:
                    FrameImage.Source = FFImageLoading.Svg.Forms.SvgImageSource.FromResource(string.Format("MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Presentation.Assets.Images.Placard-Frame-Landscape-Bullet-{0}.svg", useLightFrame ? "White" : "Secoundary"), GetType().Assembly);

                    break;
                case FrameStyle.Tally:
                default:
                    FrameImage.Source = FFImageLoading.Svg.Forms.SvgImageSource.FromResource(string.Format("MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Presentation.Assets.Images.Placard-Frame-Landscape-Outline-{0}.svg", useLightFrame ? "White" : "Secoundary"), GetType().Assembly);

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