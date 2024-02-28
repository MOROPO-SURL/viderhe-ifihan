using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Descriptors;
using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Models.Context;

namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Providers
{
    public class PlacardContextDependenciesProvider : Common.Templating.Providers.Facade.IPlacardContextDependenciesProvider
    {
        public Common.Templating.Models.Context.GradientContextModel[] GetGradients(System.Guid templateId, string serializedContext)
        {
            return null;
        }

        public Common.Templating.Models.Context.ImageContextModel[] GetImages(System.Guid templateId, string serializedContext)
        {
            if (templateId == LandscapeAnonimusHeroTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<LandscapeAnonimusHeroPlacardContextModel>(serializedContext);

                return new[] { context.HeroImage };
            }

            if (templateId == LandscapeCrossStripeTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<LandscapeCrossStripePlacardContextModel>(serializedContext);

                return new[] { context.ContextedImage };
            }

            if (templateId == LandscapeFillFlyoutTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<LandscapeFillFlyoutPlacardContextModel>(serializedContext);

                return new[] { context.ContextedImage };
            }

            if (templateId == LandscapeFloatingFlyoutTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<LandscapeFloatingFlyoutPlacardContextModel>(serializedContext);

                return new[] { context.ContextedImage };
            }

            if (templateId == LandscapePennantTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<LandscapePennantPlacardContextModel>(serializedContext);

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
            if (templateId == CornerTileVideoPresentingVideoTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<CornerTileVideoPresentingVideoPlacardContextModel>(serializedContext);

                return new[] { context.PresenterTileVideo, context.PresentedVideo };
            }

            if (templateId == InfinityVideoTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<InfinityVideoPlacardContextModel>(serializedContext);

                return new[] { context.Video };
            }

            return null;
        }
    }
}
