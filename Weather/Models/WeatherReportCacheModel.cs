namespace SmartSolucionesCuba.Viderhe.Weather.Models
{
    public class WeatherReportCacheModel
    {
        public System.DateTime FetchedAt { get; set; }

        public Enumerations.PorvisionService PorvisionService { get; set; }

        public Api.Common.Models.WeatherReportModel Report { get; set; }
    }
}
