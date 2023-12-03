using MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Enumerations;
using MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Models.Context;

namespace MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Presentation.Models.View.Placard
{
    public class InmersiveCityWeatherOverviewPlacardViewModel : Common.Templating.Presentation.Models.View.AbstractScreenTimedPlacardViewModel
    {
        private bool isBusy;

        private Service.Weather.Api.Common.Models.WeatherOverviewModel weatherOverview;

        public InmersiveCityWeatherOverviewPlacardViewModel()
        {
            Now = System.DateTime.Now;
        }

        public System.Uri ServiceBaseUri { get; set; }

        public System.DateTime Now { get; set; }

        public WeatherDataProvisionService Service { get; set; }

        public Service.Weather.Api.Common.Models.CityModel City { get; set; }

        public Service.Weather.Api.Common.Models.WeatherOverviewModel WeatherOverview { get => weatherOverview; set => SetProperty(ref weatherOverview, value); }

        public BackgroundContextModel Background { get; set; }

        public Xamarin.Forms.Color TextColor { get; set; }

        public Xamarin.Forms.Color? OverlayColor { get; set; }

        public bool IsBusy { get => isBusy; set => SetProperty(ref isBusy, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Background = null;
            WeatherOverview = null;
        }
    }
}
