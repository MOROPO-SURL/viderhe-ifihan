namespace MOROPO.VIDERHE.Service.Weather.WebOlupin.Models.OWM
{
    public class CoordenateModel
    {
        [Newtonsoft.Json.JsonProperty("lat")]
        public double Lat { get; set; }

        [Newtonsoft.Json.JsonProperty("lon")]
        public double Lon { get; set; }
    }
}
