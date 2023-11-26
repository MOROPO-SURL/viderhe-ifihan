namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Presentation.Views
{
    public partial class LandscapePennantPlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        public LandscapePennantPlacardView(Models.View.LandscapePennantPlacardViewModel model, double relativeSizeScaleFactor) : base(relativeSizeScaleFactor)
        {
            InitializeComponent();

            BindingContext = model;

            PennantImage.Source = FFImageLoading.Svg.Forms.SvgImageSource.FromResource(string.Format("SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Presentation.Assets.Images.Placard-Pennant-{0}-{1}-{2}.svg", model.FlyoutShapeKind, model.PennantVerticalOrientation, model.FlyoutBackgroundColorMode), GetType().Assembly);
            LogoImage.Source = model.FlyoutBackgroundColorMode == Enumerations.FlyoutBackgroundColorMode.Light ?
                FFImageLoading.Svg.Forms.SvgImageSource.FromResource("SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Presentation.Assets.Images.MF-Identity-Landscape.svg", GetType().Assembly) :
                FFImageLoading.Svg.Forms.SvgImageSource.FromResource("SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Presentation.Assets.Images.MF-Identity-Landscape-Color-White.svg", GetType().Assembly);

            if (model.FlyoutBackgroundColorMode == Enumerations.FlyoutBackgroundColorMode.Light)
            {
                var accountInformationProvider = Xamarin.Forms.DependencyService.Get<Common.Presentation.Providers.Facade.IAccountInformationProviderFacade>();

                HeaderLabel.TextColor = accountInformationProvider.PrimaryColor;

                ContentLabel.TextColor = accountInformationProvider.SecoundaryColor;
            }

            switch (model.PennantVerticalOrientation)
            {
                case Enumerations.PennantVerticalOrientation.Top:
                    Xamarin.Forms.Grid.SetRow(DataLayoutWrapGrid, 0);

                    break;
                case Enumerations.PennantVerticalOrientation.Bottom:
                default:
                    Xamarin.Forms.Grid.SetRow(DataLayoutWrapGrid, 1);

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

            ContextedImagen.Source = null;
            PennantImage.Source = null;
            LogoImage.Source = null;
        }
    }
}