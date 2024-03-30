using MOROPO.VIDERHE.Service.Weather.WebOlupin.Enumerations;

namespace MOROPO.VIDERHE.Service.Weather.WebOlupin.Models
{
    public class WeatherReportCacheModel
    {
        public PorvisionService PorvisionService { get; set; }

        public Api.Common.Models.WeatherReportModel Report { get; set; }
    }
}