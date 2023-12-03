using MOROPO.VIDERHE.Service.Weather.Api.Common.Models;

namespace MOROPO.VIDERHE.Service.Weather.Api.Connect.Clients
{
    public sealed class OpenWeatherMapApiConnectClient
    {
        private const string TARGET_CONTROLLER = "openweathermap";

        private readonly Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper httpClientHelper;

        public OpenWeatherMapApiConnectClient(Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper httpClientHelper)
        {
            this.httpClientHelper = httpClientHelper;
        }

        public async System.Threading.Tasks.Task<CityModel[]> GetCitiesAsync()
        {
            return await httpClientHelper.GetAsync<CityModel[]>(string.Format("{0}/cities", TARGET_CONTROLLER));
        }

        public async System.Threading.Tasks.Task<WeatherOverviewModel> GetOverviewByCityAsync(int key)
        {
            return await httpClientHelper.GetAsync<WeatherOverviewModel>(string.Format("{0}/overview/city/{1}", TARGET_CONTROLLER, key));
        }

        public async System.Threading.Tasks.Task<WeatherReportModel> GetReportByCityAsync(int key)
        {
            return await httpClientHelper.GetAsync<WeatherReportModel>(string.Format("{0}/report/city/{1}", TARGET_CONTROLLER, key));
        }

        public async System.Threading.Tasks.Task<WeatherOverviewModel> GetOverviewByLocationAsync(double latitude, double longitude)
        {
            return await httpClientHelper.GetAsync<WeatherOverviewModel>(string.Format("{0}/overview/lat/{1}/lon/{2}", TARGET_CONTROLLER, latitude, longitude));
        }

        public async System.Threading.Tasks.Task<WeatherReportModel> GetReportByLocationAsync(double latitude, double longitude)
        {
            return await httpClientHelper.GetAsync<WeatherReportModel>(string.Format("{0}/report/lat/{1}/lon/{2}", TARGET_CONTROLLER, latitude, longitude));
        }
    }
}
