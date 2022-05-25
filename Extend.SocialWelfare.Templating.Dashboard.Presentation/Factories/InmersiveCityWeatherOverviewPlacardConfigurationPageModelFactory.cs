using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Dashboard.Presentation.Factories
{
    public static class InmersiveCityWeatherOverviewPlacardConfigurationPageModelFactory
    {
        public static Models.Page.InmersiveCityWeatherOverviewPlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new Models.Page.InmersiveCityWeatherOverviewPlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.InmersiveCityWeatherOverviewContextModel>(placardViewModel.SerializedContext);

            return new Models.Page.InmersiveCityWeatherOverviewPlacardConfigurationPageModel
            {
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                Label = placardViewModel.Label,
                ScreenPresentationTimeSecounds = System.Convert.ToInt32(context.ScreenPresentationTime.TotalSeconds),
                BackgroundCityImage = context.BackgroundCityImage.ToViewModel(),
                WeatherCacheMicroServerHost = context.WeatherCacheMicroServerHost,
                IsWeatherCacheMicroServerRequireSecureConnection = context.IsWeatherCacheMicroServerRequireSecureConnection,
                IsWeatherCacheMicroServerSecureConnectionStrict = context.IsWeatherCacheMicroServerSecureConnectionStrict,
                Service = context.Service,
                City = context.City
            };
        }
    }
}
