using MOROPO.VIDERHE.Service.Weather.WebOlupin.Enumerations;

namespace MOROPO.VIDERHE.Service.Weather.WebOlupin.Options
{
    public class OpenWeatherMapOptions
    {
        /// <summary>
        /// The unique API key obtained from OpenWeatherMap.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// The mode of operation. Defaults to <see cref="FetchMode.AlwaysUseLastMeasuredButExtendCache"/>.
        /// </summary>
        public FetchMode FetchMode { get; set; }

        /// <summary>
        /// The number of milliseconds to cache for.
        /// </summary>
        public int ApiCachePeriod { get; set; }

        /// <summary>
        /// The resiliency period in milliseconds to use if this is not passed on.
        /// </summary>
        public int ResiliencyPeriod { get; set; }

        /// <summary>
        /// The timeout in milliseconds to use if this is not passed on.
        /// </summary>
        public int Timeout { get; set; }

        public Models.OWM.CityModel[] Cities { get; set; }

        public System.Collections.Generic.Dictionary<string, string> Defaults { get; set; }
    }
}
