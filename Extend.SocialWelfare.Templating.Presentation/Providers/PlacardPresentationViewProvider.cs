using SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Descriptors;
using SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Presentation.Views;

namespace SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Presentation.Providers
{
    public class PlacardPresentationViewProvider : Common.Templating.Presentation.Providers.Facade.IPlacardPresentationViewProviderFacade
    {
        public Common.Presentation.Views.BasePlacardPresentationView GetFor(Support.Presentation.Models.View.PlacardViewModel model)
        {
            if (model.Template.Id == InmersiveCityWeatherOverviewTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.InmersiveCityWeatherOverviewContextModel>(model.SerializedContext);

                var protocol = context.IsWeatherCacheMicroServerRequireSecureConnection ? "https" : "http";

                return new InmersiveCityWeatherOverviewPlacardView(new Models.View.InmersiveCityWeatherOverviewPlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    BackgroundCityImageSource = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(context.BackgroundCityImage.Id)),
                    Service = context.Service,
                    City = context.City,
                    ServiceBaseUri = new System.Uri(string.Format("{0}://{1}/api/", protocol, context.WeatherCacheMicroServerHost))
                });
            }

            if (model.Template.Id == RssFeedCollageHeroTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.RssFeedCollageHeroContextModel>(model.SerializedContext);

                return new RssFeedCollageHeroPlacardView(context);
            }

            return null;
        }
    }
}
