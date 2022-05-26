namespace SmartSolucionesCuba.Viderhe.Extend.CPCC.Templating.Providers
{
    public class PlacardContextDependenciesProvider : Common.Templating.Providers.Facade.IPlacardContextDependenciesProvider
    {
        public Common.Templating.Models.Context.ImageContextModel[] GetImages(System.Guid templateId, string serializedContext)
        {
            if (templateId == Descriptors.PortraitPosterVideoEventPromotionTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.PortraitPosterVideoEventPromotionPlacardContextModel>(serializedContext);

                return new[] { context.Poster };
            }

            return null;
        }

        public Common.Templating.Models.Context.VideoContextModel[] GetVideos(System.Guid templateId, string serializedContext)
        {
            if (templateId == Descriptors.PortraitPosterVideoEventPromotionTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.PortraitPosterVideoEventPromotionPlacardContextModel>(serializedContext);

                return new[] { context.Video };
            }

            return null;
        }
    }
}
