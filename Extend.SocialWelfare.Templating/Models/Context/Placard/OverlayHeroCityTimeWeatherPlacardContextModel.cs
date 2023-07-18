namespace SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Models.Context.Placard
{
    public class OverlayHeroCityTimeWeatherPlacardContextModel : WeatherDataProvisionContextModel
    {
        public BackgroundContextModel Background { get; set; }

        public string TextColor { get; set; }

        public string OverlayColor { get; set; }

        public string TimeZoneId { get; set; }
    }
}
