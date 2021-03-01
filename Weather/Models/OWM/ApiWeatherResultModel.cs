namespace SmartSolucionesCuba.Viderhe.Weather.Models.OWM
{
    public class ApiWeatherResultModel
    {
        [Newtonsoft.Json.JsonProperty("lat")]
        public double Latitude { get; set; }

        [Newtonsoft.Json.JsonProperty("lon")]
        public double Longitude { get; set; }

        [Newtonsoft.Json.JsonProperty("timezone")]
        public string TimeZoneName { get; set; }

        [Newtonsoft.Json.JsonProperty("timezone_offset")]
        public int TimeZoneOffset { get; set; }

        [Newtonsoft.Json.JsonProperty("current")]
        public CurrentWeatherModel Current { get; set; }

        [Newtonsoft.Json.JsonProperty("minutely")]
        public MinutelyWeatherModel[] Minutelys { get; set; }

        [Newtonsoft.Json.JsonProperty("hourly")]
        public HourlyWeatherModel[] Hourlys { get; set; }

        [Newtonsoft.Json.JsonProperty("daily")]
        public DailyWeatherModel[] Dailys { get; set; }

        [Newtonsoft.Json.JsonProperty("alerts")]
        public AlertWeatherModel[] Alerts { get; set; }
    }
}
