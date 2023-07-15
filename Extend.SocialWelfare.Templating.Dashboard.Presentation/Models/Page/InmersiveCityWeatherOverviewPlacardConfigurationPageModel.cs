using SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Enumerations;

namespace SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Dashboard.Presentation.Models.Page
{
    public class InmersiveCityWeatherOverviewPlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledScreenTimedPlacardConfigurationPageModel
    {
        private Templating.Models.Context.BackgroundContextModel background;
        private string weatherCacheMicroServerHost;
        private bool isWeatherCacheMicroServerRequireSecureConnection;
        private bool isWeatherCacheMicroServerSecureConnectionStrict;
        private WeatherDataProvisionService service;
        private Weather.Api.Common.Models.CityModel city;
        private Weather.Api.Common.Models.CityModel[] availableCities;
        private Xamarin.Forms.Color textColor;
        private Xamarin.Forms.Color? overlayColor;

        public InmersiveCityWeatherOverviewPlacardConfigurationPageModel()
        {
            ScreenPresentationTimeSecounds = 15;
            TextColor = Xamarin.Forms.Color.White;

            AvailableServices = new WeatherDataProvisionService[]
            {
                WeatherDataProvisionService.OpenWeatherMap
            };
        }

        public Templating.Models.Context.BackgroundContextModel Background { get => background; set => SetProperty(ref background, value); }

        public string WeatherCacheMicroServerHost { get => weatherCacheMicroServerHost; set => SetProperty(ref weatherCacheMicroServerHost, value); }

        public bool IsWeatherCacheMicroServerRequireSecureConnection { get => isWeatherCacheMicroServerRequireSecureConnection; set => SetProperty(ref isWeatherCacheMicroServerRequireSecureConnection, value); }

        public bool IsWeatherCacheMicroServerSecureConnectionStrict { get => isWeatherCacheMicroServerSecureConnectionStrict; set => SetProperty(ref isWeatherCacheMicroServerSecureConnectionStrict, value); }

        public WeatherDataProvisionService Service { get => service; set => SetProperty(ref service, value); }

        public WeatherDataProvisionService[] AvailableServices { get; private set; }

        public Weather.Api.Common.Models.CityModel City { get => city; set => SetProperty(ref city, value); }

        public Weather.Api.Common.Models.CityModel[] AvailableCities { get => availableCities; set => SetProperty(ref availableCities, value); }

        public Xamarin.Forms.Color TextColor { get => textColor; set => SetProperty(ref textColor, value); }

        public Xamarin.Forms.Color? OverlayColor { get => overlayColor; set => SetProperty(ref overlayColor, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            background = null;
        }

        public void Consolidate()
        {
            RaisePropertyChanged("Service");
            RaisePropertyChanged("City");
        }
    }
}
