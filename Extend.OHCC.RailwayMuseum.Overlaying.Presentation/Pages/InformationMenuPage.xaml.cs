using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Enumerations;
using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Models.View;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Pages
{
    public partial class InformationMenuPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.ContentPage
    {
        private static System.TimeSpan INDLE_CHECK_TIME = System.TimeSpan.FromSeconds(30);
        private static System.TimeSpan INDLE_LIMIT_TIME = System.TimeSpan.FromMinutes(2);

        private InformationMenuOverlayViewModel model;

        private Common.Presentation.Providers.Facade.IAccountInformationProviderFacade accountInformationProvider;

        private InformationMenuSection activeSection;

        private System.Diagnostics.Stopwatch indleStopwatch;

        public InformationMenuPage(InformationMenuOverlayViewModel model)
        {
            InitializeComponent();

            this.model = model;

            activeSection = InformationMenuSection.RailwayMuseum;

            accountInformationProvider = Xamarin.Forms.DependencyService.Get<Common.Presentation.Providers.Facade.IAccountInformationProviderFacade>();

            SectionSeparatorBoxView.Color = accountInformationProvider.SecoundaryColor;

            Section1IconLabel.TextColor = accountInformationProvider.PrimaryColor;
            Section2IconLabel.TextColor = accountInformationProvider.PrimaryColor;
            Section3IconLabel.TextColor = accountInformationProvider.PrimaryColor;

            LogoImage.Source = FFImageLoading.Svg.Forms.SvgImageSource.FromResource("MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Assets.Images.MF-Logo.svg", GetType().Assembly);

            FirstSectionIndicatorImage.Source = FFImageLoading.Svg.Forms.SvgImageSource.FromResource("MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Assets.Images.Information-Menu-Section-Item-Indicator-Left.svg", GetType().Assembly);
            SecoundSectionIndicatorImage.Source = FFImageLoading.Svg.Forms.SvgImageSource.FromResource("MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Assets.Images.Information-Menu-Section-Item-Indicator-Right.svg", GetType().Assembly);
            ThirthSectionIndicatorImage.Source = FFImageLoading.Svg.Forms.SvgImageSource.FromResource("MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Assets.Images.Information-Menu-Section-Item-Indicator-Left.svg", GetType().Assembly);

            PresentActiveSection();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (indleStopwatch != null)
            {
                indleStopwatch.Restart();

                return;
            }

            indleStopwatch = new System.Diagnostics.Stopwatch();

            indleStopwatch.Start();

            Xamarin.Forms.Device.StartTimer(INDLE_CHECK_TIME, CheckFornIndleStatus);
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

        private void OHCCSectionTapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            ResetIndleElapsedTime();

            if (activeSection == InformationMenuSection.OHCC) return;

            activeSection = InformationMenuSection.OHCC;

            PresentActiveSection();
        }

        private void RailwayMuseumSectionTapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            ResetIndleElapsedTime();

            if (activeSection == InformationMenuSection.RailwayMuseum) return;

            activeSection = InformationMenuSection.RailwayMuseum;

            PresentActiveSection();
        }

        private void SectionItem1TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            ResetIndleElapsedTime();

            var title = activeSection == InformationMenuSection.RailwayMuseum ? "Museo Ferroviario" : "Oficina del Historiador";

            var url = activeSection == InformationMenuSection.RailwayMuseum ? model.RailwayMuseumAboutUri : model.OHCCAboutUri;

            this.NavigationPushPageAsync(new InformationContentPage(title, url, ResetIndleElapsedTime));
        }

        private void SectionItem2TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            ResetIndleElapsedTime();

            var title = activeSection == InformationMenuSection.RailwayMuseum ? "Museo Ferroviario" : "Oficina del Historiador";

            var url = activeSection == InformationMenuSection.RailwayMuseum ? model.RailwayMuseumOfferUri : model.OHCCOfferUri;

            this.NavigationPushPageAsync(new InformationContentPage(title, url, ResetIndleElapsedTime));
        }

        private void SectionItem3TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            ResetIndleElapsedTime();

            var title = activeSection == InformationMenuSection.RailwayMuseum ? "Museo Ferroviario" : "Oficina del Historiador";

            var url = activeSection == InformationMenuSection.RailwayMuseum ? model.RailwayMuseumBillboardUri : model.OHCCBillboardUri;

            this.NavigationPushPageAsync(new InformationContentPage(title, url, ResetIndleElapsedTime));
        }

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs eventArgs)
        {
            ResetIndleElapsedTime();
        }

        private bool CheckFornIndleStatus()
        {
            var endIndleCheck = INDLE_LIMIT_TIME < indleStopwatch.Elapsed;

            if (endIndleCheck)
            {
                Xamarin.Forms.Application.Current.MainPage.NavigationPopModalPageAsync();
            }

            return !endIndleCheck;
        }

        private void ResetIndleElapsedTime()
        {
            indleStopwatch.Reset();
            indleStopwatch.Start();
        }

        private void PresentActiveSection()
        {
            if (activeSection == InformationMenuSection.RailwayMuseum)
            {
                SectionBackgroundImage.Source = null;
                SectionBackgroundImage.Source = Xamarin.Forms.ImageSource.FromResource("MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Assets.Images.RailwayMuseum-Background.jpg", GetType().Assembly);

                RailwayMuseumSectionGrid.BackgroundColor = accountInformationProvider.SecoundaryColor;
                OHCCSectionGrid.BackgroundColor = Xamarin.Forms.Color.Transparent;

                OHCCSectionNameLabel.TextColor = accountInformationProvider.SecoundaryColor;
                RailwayMuseumSectionNameLabel.TextColor = Xamarin.Forms.Color.White;

                RailwayMuseumSectionVintageImage.Source = null;
                RailwayMuseumSectionVintageImage.Source = FFImageLoading.Svg.Forms.SvgImageSource.FromResource("MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Assets.Images.Information-Menu-Section-Vintage-Active.svg", GetType().Assembly);
                OHCCSectionVintageImage.Source = null;
                OHCCSectionVintageImage.Source = FFImageLoading.Svg.Forms.SvgImageSource.FromResource("MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Assets.Images.Information-Menu-Section-Vintage-Inactive.svg", GetType().Assembly);

                SecoundSectionIndicatorLabel.Text = "Horarios y Servicios";
                ThirthSectionIndicatorLabel.Text = "Guía del Recorrido";
            }
            else
            {
                SectionBackgroundImage.Source = null;
                SectionBackgroundImage.Source = Xamarin.Forms.ImageSource.FromResource("MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Assets.Images.OHCC-Background.jpg", GetType().Assembly);

                OHCCSectionGrid.BackgroundColor = accountInformationProvider.SecoundaryColor;
                RailwayMuseumSectionGrid.BackgroundColor = Xamarin.Forms.Color.Transparent;

                RailwayMuseumSectionNameLabel.TextColor = accountInformationProvider.SecoundaryColor;
                OHCCSectionNameLabel.TextColor = Xamarin.Forms.Color.White;

                OHCCSectionVintageImage.Source = null;
                OHCCSectionVintageImage.Source = FFImageLoading.Svg.Forms.SvgImageSource.FromResource("MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Assets.Images.Information-Menu-Section-Vintage-Active.svg", GetType().Assembly);
                RailwayMuseumSectionVintageImage.Source = null;
                RailwayMuseumSectionVintageImage.Source = FFImageLoading.Svg.Forms.SvgImageSource.FromResource("MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Assets.Images.Information-Menu-Section-Vintage-Inactive.svg", GetType().Assembly);

                SecoundSectionIndicatorLabel.Text = "Instalaciones y Servicios";
                ThirthSectionIndicatorLabel.Text = "Programación Cultural";
            }

            Section1Image.Source = null;
            Section1Image.Source = Xamarin.Forms.ImageSource.FromResource(string.Format("MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Assets.Images.{0}-Section-Item-1.jpg", activeSection), GetType().Assembly);

            Section2Image.Source = null;
            Section2Image.Source = Xamarin.Forms.ImageSource.FromResource(string.Format("MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Assets.Images.{0}-Section-Item-2.jpg", activeSection), GetType().Assembly);

            Section3Image.Source = null;
            Section3Image.Source = Xamarin.Forms.ImageSource.FromResource(string.Format("MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Assets.Images.{0}-Section-Item-3.jpg", activeSection), GetType().Assembly);

        }
    }
}