namespace MOROPO.VIDERHE.Service.Weather.WebOlupin.Models.OWM
{
    public class DayTemperatureSummaryModel : DayTemperatureSetModel
    {
        [Newtonsoft.Json.JsonProperty("min")]
        public float Min { get; set; }

        [Newtonsoft.Json.JsonProperty("max")]
        public float Max { get; set; }
    }
}
