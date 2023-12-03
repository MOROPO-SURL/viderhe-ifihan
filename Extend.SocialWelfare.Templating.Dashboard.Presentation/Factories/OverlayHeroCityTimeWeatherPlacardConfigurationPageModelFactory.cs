using MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Dashboard.Presentation.Models.Page;
using MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Models.Context.Placard;

namespace MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Dashboard.Presentation.Factories
{
    public static class OverlayHeroCityTimeWeatherPlacardConfigurationPageModelFactory
    {
        public static OverlayHeroCityTimeWeatherPlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new OverlayHeroCityTimeWeatherPlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<OverlayHeroCityTimeWeatherPlacardContextModel>(placardViewModel.SerializedContext);

            var result = new OverlayHeroCityTimeWeatherPlacardConfigurationPageModel
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
                City = context.City,
                DateTimeZoneId = context.TimeZoneId
            };

            if (context.OverlayColor != null)
            {
                result.OverlayColor = Xamarin.Forms.Color.FromHex(context.OverlayColor);
            }

            return result;
        }
    }
}
