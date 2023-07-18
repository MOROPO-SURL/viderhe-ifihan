namespace SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Dashboard.Presentation.Factories
{
    public static class OverlayHeroCityTimeWeatherPlacardConfigurationPageModelFactory
    {
        public static Models.Page.OverlayHeroCityTimeWeatherPlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new Models.Page.OverlayHeroCityTimeWeatherPlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.Placard.OverlayHeroCityTimeWeatherPlacardContextModel>(placardViewModel.SerializedContext);

            var result = new Models.Page.OverlayHeroCityTimeWeatherPlacardConfigurationPageModel
            {
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                DefineBeginAt = placardViewModel.BeginAt != null,
                BeginAt = placardViewModel.BeginAt ?? System.DateTime.Now.Date,
                DefineEndAt = placardViewModel.EndAt != null,
                EndAt = placardViewModel.EndAt ?? System.DateTime.Now.Date,
                Label = placardViewModel.Label,
                ScreenPresentationTimeSecounds = System.Convert.ToInt32(context.ScreenPresentationTime.TotalSeconds),
                Background = context.Background,
                TextColor = Xamarin.Forms.Color.FromHex(context.TextColor),
                WeatherCacheMicroServerHost = context.WeatherCacheMicroServerHost,
                IsWeatherCacheMicroServerRequireSecureConnection = context.IsWeatherCacheMicroServerRequireSecureConnection,
                IsWeatherCacheMicroServerSecureConnectionStrict = context.IsWeatherCacheMicroServerSecureConnectionStrict,
                Service = context.Service,
                City = context.City,
                TimeZone = System.TimeZoneInfo.FindSystemTimeZoneById(context.TimeZoneId)
            };

            if (context.OverlayColor != null)
            {
                result.OverlayColor = Xamarin.Forms.Color.FromHex(context.OverlayColor);
            }

            return result;
        }
    }
}
