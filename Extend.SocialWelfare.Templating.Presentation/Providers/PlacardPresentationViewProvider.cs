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

            return null;
        }
    }
}
