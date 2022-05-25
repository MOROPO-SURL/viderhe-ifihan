using SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Enumerations;

namespace SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Dashboard.Presentation.Models.Page
{
    public class InmersiveCityWeatherOverviewPlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledScreenTimedPlacardConfigurationPageModel
    {
        private Support.Presentation.Models.View.ImageViewModel backgroundCityImage;
        private string weatherCacheMicroServerHost;
        private bool isWeatherCacheMicroServerRequireSecureConnection;
        private bool isWeatherCacheMicroServerSecureConnectionStrict;
        private WeatherDataProvisionService service;
        private Weather.Api.Common.Models.CityModel city;
        private Weather.Api.Common.Models.CityModel[] availableCities;

        public InmersiveCityWeatherOverviewPlacardConfigurationPageModel()
        {
            ScreenPresentationTimeSecounds = 15;

            AvailableServices = new WeatherDataProvisionService[]
            {
                WeatherDataProvisionService.OpenWeatherMap
            };
        }

        public Support.Presentation.Models.View.ImageViewModel BackgroundCityImage { get => backgroundCityImage; set => SetProperty(ref backgroundCityImage, value); }

        public string WeatherCacheMicroServerHost { get => weatherCacheMicroServerHost; set => SetProperty(ref weatherCacheMicroServerHost, value); }

        public bool IsWeatherCacheMicroServerRequireSecureConnection { get => isWeatherCacheMicroServerRequireSecureConnection; set => SetProperty(ref isWeatherCacheMicroServerRequireSecureConnection, value); }

        public bool IsWeatherCacheMicroServerSecureConnectionStrict { get => isWeatherCacheMicroServerSecureConnectionStrict; set => SetProperty(ref isWeatherCacheMicroServerSecureConnectionStrict, value); }

        public WeatherDataProvisionService Service { get => service; set => SetProperty(ref service, value); }

        public WeatherDataProvisionService[] AvailableServices { get; private set; }

        public Weather.Api.Common.Models.CityModel City { get => city; set => SetProperty(ref city, value); }

        public Weather.Api.Common.Models.CityModel[] AvailableCities { get => availableCities; set => SetProperty(ref availableCities, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            backgroundCityImage = null;
        }

        public void Consolidate()
        {
            RaisePropertyChanged("Service");
            RaisePropertyChanged("City");
        }
    }
}
