namespace SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Dashboard.Presentation.Models.Page
{
    public class InmersiveCityWeatherOverviewConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledScreenTimedPlacardConfigurationPageModel
    {
        private Support.Presentation.Models.View.ImageViewModel backgroundCityImage;
        private System.Uri weatherCacheMicroServerUri;
        private Templating.Presentation.Enumerations.WeatherDataProvisionService service;
        private Weather.Api.Common.Models.CityModel city;
        private Weather.Api.Common.Models.CityModel[] availableCities;

        public InmersiveCityWeatherOverviewConfigurationPageModel()
        {
            ScreenPresentationTimeSecounds = 15;
        }

        public Support.Presentation.Models.View.ImageViewModel BackgroundCityImage { get => backgroundCityImage; set => SetProperty(ref backgroundCityImage, value); }

        public System.Uri WeatherCacheMicroServerUri { get => weatherCacheMicroServerUri; set => SetProperty(ref weatherCacheMicroServerUri, value); }

        public Templating.Presentation.Enumerations.WeatherDataProvisionService Service { get => service; set => SetProperty(ref service, value); }

        public string[] AvailableServices { get => System.Enum.GetNames(typeof(Templating.Presentation.Enumerations.WeatherDataProvisionService)); }

        public Weather.Api.Common.Models.CityModel City { get => city; set => SetProperty(ref city, value); }

        public Weather.Api.Common.Models.CityModel[] AvailableCities { get => availableCities; set => SetProperty(ref availableCities, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            backgroundCityImage = null;
        }
    }
}
