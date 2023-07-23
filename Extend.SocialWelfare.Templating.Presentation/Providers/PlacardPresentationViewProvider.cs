using SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Descriptors;

namespace SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Presentation.Providers
{
    public class PlacardPresentationViewProvider : Common.Templating.Presentation.Providers.Facade.IPlacardPresentationViewProviderFacade
    {
        public Common.Presentation.Views.BasePlacardPresentationView GetFor(Support.Presentation.Models.View.PlacardViewModel model, System.Func<Xamarin.Essentials.DisplayOrientation> getOrientationFunction)
        {
            if (model.Template.Id == InmersiveCityWeatherOverviewTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.Placard.InmersiveCityWeatherOverviewPlacardContextModel>(model.SerializedContext);

                var protocol = context.IsWeatherCacheMicroServerRequireSecureConnection ? "https" : "http";

                var viewModel = new Models.View.Placard.InmersiveCityWeatherOverviewPlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    Background = context.Background,
                    TextColor = Xamarin.Forms.Color.FromHex(context.TextColor),
                    Service = context.Service,
                    City = context.City,
                    ServiceBaseUri = new System.Uri(string.Format("{0}://{1}/api/", protocol, context.WeatherCacheMicroServerHost))
                };

                if (context.OverlayColor != null)
                {
                    viewModel.OverlayColor = Xamarin.Forms.Color.FromHex(context.OverlayColor);
                }

                return new Views.InmersiveCityWeatherOverviewPlacardView(viewModel);
            }

            if (model.Template.Id == RssFeedCollageHeroTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.Placard.RssFeedCollageHeroPlacardContextModel>(model.SerializedContext);

                return new Views.RssFeedCollageHeroPlacardView(context);
            }

            if (model.Template.Id == HeroLocalNowDateTimeTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.Placard.HeroLocalNowDateTimePlacardContextModel>(model.SerializedContext);

                return new Views.HeroLocalNowDateTimePlacardView(new Models.View.Placard.HeroLocalNowDateTimePlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    Style = context.Style,
                    IsDateTimeFramed = context.IsDateTimeFramed,
                    TextColor = Xamarin.Forms.Color.FromHex(context.TextColor),
                    TextFontFamily = context.TextFontFamily,
                    Culture = context.Culture == null ? System.Globalization.CultureInfo.CurrentCulture : System.Globalization.CultureInfo.GetCultureInfo(context.Culture),
                    Background = context.Background
                });
            }

            if (model.Template.Id == OverlayHeroCityTimeWeatherTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.Placard.OverlayHeroCityTimeWeatherPlacardContextModel>(model.SerializedContext);

                var protocol = context.IsWeatherCacheMicroServerRequireSecureConnection ? "https" : "http";

                var viewModel = new Models.View.Placard.OverlayHeroCityTimeWeatherPlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    Background = context.Background,
                    TextColor = Xamarin.Forms.Color.FromHex(context.TextColor),
                    Service = context.Service,
                    City = context.City,
                    ServiceBaseUri = new System.Uri(string.Format("{0}://{1}/api/", protocol, context.WeatherCacheMicroServerHost)),
                    Now = NodaTime.Instant.FromDateTimeUtc(System.DateTime.Now.ToUniversalTime()).InZone(NodaTime.DateTimeZoneProviders.Tzdb[context.TimeZoneId]).ToDateTimeUnspecified()
                };

                if (context.OverlayColor != null)
                {
                    viewModel.OverlayColor = Xamarin.Forms.Color.FromHex(context.OverlayColor);
                }

                var orientation = getOrientationFunction.Invoke();

                if (orientation == Xamarin.Essentials.DisplayOrientation.Portrait)
                {
                    return new Views.PortraitOverlayHeroCityTimeWeatherPlacardView(viewModel);
                }

                return new Views.LandscapeOverlayHeroCityTimeWeatherPlacardView(viewModel);
            }

            return null;
        }
    }
}
