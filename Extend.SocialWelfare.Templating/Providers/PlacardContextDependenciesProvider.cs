namespace SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Providers
{
    public class PlacardContextDependenciesProvider : Common.Templating.Providers.Facade.IPlacardContextDependenciesProvider
    {
        public Common.Templating.Models.Context.ImageContextModel[] GetImages(System.Guid templateId, string serializedContext)
        {
            if (templateId == Descriptors.InmersiveCityWeatherOverviewTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.InmersiveCityWeatherOverviewContextModel>(serializedContext);

                return new[] { context.BackgroundCityImage };
            }

            return null;
        }

        public Common.Templating.Models.Context.VideoContextModel[] GetVideos(System.Guid templateId, string serializedContext)
        {
            return null;
        }
    }
}
