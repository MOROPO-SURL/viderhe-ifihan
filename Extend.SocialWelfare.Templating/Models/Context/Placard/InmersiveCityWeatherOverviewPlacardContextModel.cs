namespace MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Models.Context.Placard
{
    public class InmersiveCityWeatherOverviewPlacardContextModel : WeatherDataProvisionContextModel
    {
        public BackgroundContextModel Background { get; set; }

        public string TextColor { get; set; }

        public string OverlayColor { get; set; }
    }
}
