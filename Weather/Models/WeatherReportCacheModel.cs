using MOROPO.VIDERHE.Service.Weather.Enumerations;

namespace MOROPO.VIDERHE.Service.Weather.Models
{
    public class WeatherReportCacheModel
    {
        public PorvisionService PorvisionService { get; set; }

        public Api.Common.Models.WeatherReportModel Report { get; set; }
    }
}