using MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Dashboard.Presentation.Models.Page;
using MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Models.Context.Placard;

namespace MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Dashboard.Presentation.Factories
{
    public static class InmersiveCityWeatherOverviewPlacardConfigurationPageModelFactory
    {
        public static InmersiveCityWeatherOverviewPlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new InmersiveCityWeatherOverviewPlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<InmersiveCityWeatherOverviewPlacardContextModel>(placardViewModel.SerializedContext);

            var result = new InmersiveCityWeatherOverviewPlacardConfigurationPageModel
            {
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                DefineBeginAt = placardViewModel.BeginAt != null,
                BeginAt = placardViewModel.BeginAt ?? System.DateTime.Now.Date,
                DefineEndAt = placardViewModel.EndAt != null,
                EndAt = placardViewModel.EndAt ?? System.DateTime.Now.Date,
                Label = placardViewModel.Label,
                Tags = new System.Collections.ObjectModel.ObservableCollection<Cloud.Api.Common.Models.TagDisplayModel>(placardViewModel.Tags),
                ScreenPresentationTimeSecounds = System.Convert.ToInt32(context.ScreenPresentationTime.TotalSeconds),
                Background = context.Background,
                TextColor = Xamarin.Forms.Color.FromHex(context.TextColor),
                WeatherCacheMicroServerHost = context.WeatherCacheMicroServerHost,
                IsWeatherCacheMicroServerRequireSecureConnection = context.IsWeatherCacheMicroServerRequireSecureConnection,
                IsWeatherCacheMicroServerSecureConnectionStrict = context.IsWeatherCacheMicroServerSecureConnectionStrict,
                Service = context.Service,
                City = context.City
            };

            if (context.OverlayColor != null)
            {
                result.OverlayColor = Xamarin.Forms.Color.FromHex(context.OverlayColor);
            }

            return result;
        }
    }
}
