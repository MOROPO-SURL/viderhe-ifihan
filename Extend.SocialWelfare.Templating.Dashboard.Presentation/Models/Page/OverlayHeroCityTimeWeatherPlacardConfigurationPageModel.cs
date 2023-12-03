using MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Enumerations;
using MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Models.Context;

namespace MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Dashboard.Presentation.Models.Page
{
    public class OverlayHeroCityTimeWeatherPlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledScreenTimedPlacardConfigurationPageModel
    {
        private BackgroundContextModel background;
        private string weatherCacheMicroServerHost;
        private bool isWeatherCacheMicroServerRequireSecureConnection;
        private bool isWeatherCacheMicroServerSecureConnectionStrict;
        private WeatherDataProvisionService service;
        private Service.Weather.Api.Common.Models.CityModel city;
        private Service.Weather.Api.Common.Models.CityModel[] availableCities;
        private Xamarin.Forms.Color textColor;
        private Xamarin.Forms.Color? overlayColor;
        private string dateTimeZoneId;

        public OverlayHeroCityTimeWeatherPlacardConfigurationPageModel()
        {
            ScreenPresentationTimeSecounds = 15;
            TextColor = Xamarin.Forms.Color.White;

            AvailableServices = new WeatherDataProvisionService[]
            {
                WeatherDataProvisionService.OpenWeatherMap
            };
        }

        public BackgroundContextModel Background { get => background; set => SetProperty(ref background, value); }

        public string WeatherCacheMicroServerHost { get => weatherCacheMicroServerHost; set => SetProperty(ref weatherCacheMicroServerHost, value); }

        public bool IsWeatherCacheMicroServerRequireSecureConnection { get => isWeatherCacheMicroServerRequireSecureConnection; set => SetProperty(ref isWeatherCacheMicroServerRequireSecureConnection, value); }

        public bool IsWeatherCacheMicroServerSecureConnectionStrict { get => isWeatherCacheMicroServerSecureConnectionStrict; set => SetProperty(ref isWeatherCacheMicroServerSecureConnectionStrict, value); }

        public WeatherDataProvisionService Service { get => service; set => SetProperty(ref service, value); }

        public WeatherDataProvisionService[] AvailableServices { get; private set; }

        public Service.Weather.Api.Common.Models.CityModel City { get => city; set => SetProperty(ref city, value); }

        public Service.Weather.Api.Common.Models.CityModel[] AvailableCities { get => availableCities; set => SetProperty(ref availableCities, value); }

        public Xamarin.Forms.Color TextColor { get => textColor; set => SetProperty(ref textColor, value); }

        public Xamarin.Forms.Color? OverlayColor { get => overlayColor; set => SetProperty(ref overlayColor, value); }

        public string DateTimeZoneId { get => dateTimeZoneId; set => dateTimeZoneId = value; }

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
