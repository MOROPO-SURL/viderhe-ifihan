namespace SmartSolucionesCuba.Viderhe.Weather.Extensions
{
    internal static class ApiWeatherResultModelExtensions
    {
        internal static Models.WeatherReportCacheModel ToReportCacheModel(this Models.OWM.ApiWeatherResultModel target)
        {
            var weatherCurrentCondition = target.Current.WeatherConditions[0];

            var result = new Models.WeatherReportCacheModel
            {
                PorvisionService = Enumerations.PorvisionService.OpenWeatherMap,
                FetchedAt = System.DateTime.Now,
                Report = new Api.Common.Models.WeatherReportModel
                {
                    Overview = new Api.Common.Models.WeatherOverviewModel
                    {
                        MeasuredAt = System.DateTimeOffset.FromUnixTimeSeconds(target.Current.MeasuredAt).UtcDateTime.ToLocalTime(),
                        ConditionId = weatherCurrentCondition.Id,
                        ConditionDetail = weatherCurrentCondition.Detail,
                        Temperature = target.Current.Temperature,
                        TemperatureFeelLike = target.Current.TemperatureFeelLike,
                        SunRiseAt = System.DateTimeOffset.FromUnixTimeSeconds(target.Current.SunRiseAt).UtcDateTime.ToLocalTime(),
                        SunSetAt = System.DateTimeOffset.FromUnixTimeSeconds(target.Current.SunSetAt).UtcDateTime.ToLocalTime(),
                        CloudDensity = target.Current.CloudDensity,
                        Humidity = target.Current.Humidity,
                        Pressure = target.Current.Pressure,
                        Visibility = target.Current.Visibility,
                        UltravioletIndex = target.Current.UltravioletIndex,
                        DewPoint = target.Current.DewPoint,
                        WindSpeed = target.Current.WindSpeed,
                        WindDegrees = target.Current.WindDegrees
                    }
                }
            };

            return result;
        }
    }
}
