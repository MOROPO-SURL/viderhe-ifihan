namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Providers
{
    public class PlacardContextDependenciesProvider : Common.Templating.Providers.Facade.IPlacardContextDependenciesProvider
    {
        public Common.Templating.Models.Context.GradientContextModel[] GetGradients(System.Guid templateId, string serializedContext)
        {
            return null;
        }

        public Common.Templating.Models.Context.ImageContextModel[] GetImages(System.Guid templateId, string serializedContext)
        {
            if (templateId == Descriptors.LandscapeAnonimusHeroTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.LandscapeAnonimusHeroPlacardContextModel>(serializedContext);

                return new[] { context.HeroImage };
            }

            if (templateId == Descriptors.LandscapeCrossStripeTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.LandscapeCrossStripePlacardContextModel>(serializedContext);

                return new[] { context.ContextedImage };
            }

            if (templateId == Descriptors.LandscapeFillFlyoutTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.LandscapeFillFlyoutPlacardContextModel>(serializedContext);

                return new[] { context.ContextedImage };
            }

            if (templateId == Descriptors.LandscapeFloatingFlyoutTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.LandscapeFloatingFlyoutPlacardContextModel>(serializedContext);

                return new[] { context.ContextedImage };
            }

            if (templateId == Descriptors.LandscapePennantTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.LandscapePennantPlacardContextModel>(serializedContext);

                return new[] { context.ContextedImage };
            }

            return null;
        }

        public Common.Templating.Models.Context.SoundContextModel[] GetSounds(System.Guid templatedId, string serializedContxt)
        {
            return null;
        }

        public Common.Templating.Models.Context.VideoContextModel[] GetVideos(System.Guid templateId, string serializedContext)
        {
            if (templateId == Descriptors.CornerTileVideoPresentingVideoTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.CornerTileVideoPresentingVideoPlacardContextModel>(serializedContext);

                return new[] { context.PresenterTileVideo, context.PresentedVideo };
            }

            if (templateId == Descriptors.InfinityVideoTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.InfinityVideoPlacardContextModel>(serializedContext);

                return new[] { context.Video };
            }

            return null;
        }
    }
}
