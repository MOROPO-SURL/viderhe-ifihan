using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Pages
{
    public partial class InformationMenuPage : XFToolKit.Mvvm.Pages.ContentPage
    {
        private Models.View.InformationMenuOverlayViewModel model;

        private Common.Presentation.Providers.Facade.IAccountInformationProviderFacade accountInformationProvider;

        private Enumerations.InformationMenuSection activeSection;

        public InformationMenuPage(Models.View.InformationMenuOverlayViewModel model)
        {
            InitializeComponent();

            this.model = model;

            activeSection = Enumerations.InformationMenuSection.RailwayMuseum;

            accountInformationProvider = Xamarin.Forms.DependencyService.Get<Common.Presentation.Providers.Facade.IAccountInformationProviderFacade>();

            SectionSeparatorBoxView.Color = accountInformationProvider.SecoundaryColor;

            Section1IconLabel.TextColor = accountInformationProvider.PrimaryColor;
            Section2IconLabel.TextColor = accountInformationProvider.PrimaryColor;
            Section3IconLabel.TextColor = accountInformationProvider.PrimaryColor;

            LogoImage.Source = FFImageLoading.Svg.Forms.SvgImageSource.FromResource("SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Assets.Images.MF-Logo.svg", GetType().Assembly);

            FirstSectionIndicatorImage.Source = FFImageLoading.Svg.Forms.SvgImageSource.FromResource("SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Assets.Images.Information-Menu-Section-Item-Indicator-Left.svg", GetType().Assembly);
            SecoundSectionIndicatorImage.Source = FFImageLoading.Svg.Forms.SvgImageSource.FromResource("SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Assets.Images.Information-Menu-Section-Item-Indicator-Right.svg", GetType().Assembly);
            ThirthSectionIndicatorImage.Source = FFImageLoading.Svg.Forms.SvgImageSource.FromResource("SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Assets.Images.Information-Menu-Section-Item-Indicator-Left.svg", GetType().Assembly);

            PresentActiveSection();
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            model = null;

            accountInformationProvider = null;

            LogoImage.Source = null;

            FirstSectionIndicatorImage.Source = null;
            SecoundSectionIndicatorImage.Source = null;
            ThirthSectionIndicatorImage.Source = null;
        }

        private void PresentActiveSection()
        {
            if (activeSection == Enumerations.InformationMenuSection.RailwayMuseum)
            {
                SectionBackgroundImage.Source = null;
                SectionBackgroundImage.Source = Xamarin.Forms.ImageSource.FromResource("SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Assets.Images.RailwayMuseum-Background.jpg", GetType().Assembly);

                RailwayMuseumSectionGrid.BackgroundColor = accountInformationProvider.SecoundaryColor;
                OHCCSectionGrid.BackgroundColor = Xamarin.Forms.Color.Transparent;

                OHCCSectionNameLabel.TextColor = accountInformationProvider.SecoundaryColor;
                RailwayMuseumSectionNameLabel.TextColor = Xamarin.Forms.Color.White;

                RailwayMuseumSectionVintageImage.Source = null;
                RailwayMuseumSectionVintageImage.Source = FFImageLoading.Svg.Forms.SvgImageSource.FromResource("SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Assets.Images.Information-Menu-Section-Vintage-Active.svg", GetType().Assembly);
                OHCCSectionVintageImage.Source = null;
                OHCCSectionVintageImage.Source = FFImageLoading.Svg.Forms.SvgImageSource.FromResource("SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Assets.Images.Information-Menu-Section-Vintage-Inactive.svg", GetType().Assembly);

                SecoundSectionIndicatorLabel.Text = "Horarios y Servicios";
                ThirthSectionIndicatorLabel.Text = "Guía del Recorrido";
            }
            else
            {
                SectionBackgroundImage.Source = null;
                SectionBackgroundImage.Source = Xamarin.Forms.ImageSource.FromResource("SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Assets.Images.OHCC-Background.jpg", GetType().Assembly);

                OHCCSectionGrid.BackgroundColor = accountInformationProvider.SecoundaryColor;
                RailwayMuseumSectionGrid.BackgroundColor = Xamarin.Forms.Color.Transparent;

                RailwayMuseumSectionNameLabel.TextColor = accountInformationProvider.SecoundaryColor;
                OHCCSectionNameLabel.TextColor = Xamarin.Forms.Color.White;

                OHCCSectionVintageImage.Source = null;
                OHCCSectionVintageImage.Source = FFImageLoading.Svg.Forms.SvgImageSource.FromResource("SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Assets.Images.Information-Menu-Section-Vintage-Active.svg", GetType().Assembly);
                RailwayMuseumSectionVintageImage.Source = null;
                RailwayMuseumSectionVintageImage.Source = FFImageLoading.Svg.Forms.SvgImageSource.FromResource("SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Assets.Images.Information-Menu-Section-Vintage-Inactive.svg", GetType().Assembly);

                SecoundSectionIndicatorLabel.Text = "Instalaciones y Servicios";
                ThirthSectionIndicatorLabel.Text = "Programación Cultural";
            }

            Section1Image.Source = null;
            Section1Image.Source = Xamarin.Forms.ImageSource.FromResource(string.Format("SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Assets.Images.{0}-Section-Item-1.jpg", activeSection), GetType().Assembly);

            Section2Image.Source = null;
            Section2Image.Source = Xamarin.Forms.ImageSource.FromResource(string.Format("SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Assets.Images.{0}-Section-Item-2.jpg", activeSection), GetType().Assembly);

            Section3Image.Source = null;
            Section3Image.Source = Xamarin.Forms.ImageSource.FromResource(string.Format("SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Assets.Images.{0}-Section-Item-3.jpg", activeSection), GetType().Assembly);

        }

        private void OHCCSectionTapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            if (activeSection == Enumerations.InformationMenuSection.OHCC) return;

            activeSection = Enumerations.InformationMenuSection.OHCC;

            PresentActiveSection();
        }

        private void RailwayMuseumSectionTapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            if (activeSection == Enumerations.InformationMenuSection.RailwayMuseum) return;

            activeSection = Enumerations.InformationMenuSection.RailwayMuseum;

            PresentActiveSection();
        }

        private void SectionItem1TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            var title = activeSection == Enumerations.InformationMenuSection.RailwayMuseum ? "Museo Ferroviario" : "Oficnia del Historiador";

            var url = activeSection == Enumerations.InformationMenuSection.RailwayMuseum ? model.RailwayMuseumAboutUri : model.OHCCAboutUri;

            this.NavigationPushPageAsync(new InformationContentPage(title, url));
        }

        private void SectionItem2TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            var title = activeSection == Enumerations.InformationMenuSection.RailwayMuseum ? "Museo Ferroviario" : "Oficnia del Historiador";

            var url = activeSection == Enumerations.InformationMenuSection.RailwayMuseum ? model.RailwayMuseumOfferUri : model.OHCCOfferUri;

            this.NavigationPushPageAsync(new InformationContentPage(title, url));
        }

        private void SectionItem3TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            var title = activeSection == Enumerations.InformationMenuSection.RailwayMuseum ? "Museo Ferroviario" : "Oficnia del Historiador";

            var url = activeSection == Enumerations.InformationMenuSection.RailwayMuseum ? model.RailwayMuseumBillboardUri : model.OHCCBillboardUri;

            this.NavigationPushPageAsync(new InformationContentPage(title, url));
        }
    }
}