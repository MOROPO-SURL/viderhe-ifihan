using MOROPO.VIDERHE.Extend.Common.Templating.Models.Context;
using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Descriptors;
using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Enumerations;
using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Models.Context.Placard;

namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Providers
{
    public class PlacardContextDependenciesProvider : Common.Templating.Providers.Facade.IPlacardContextDependenciesProvider
    {
        public GradientContextModel[] GetGradients(System.Guid templateId, string serializedContext)
        {
            if (templateId == ClassicArraivalsTemplateDescriptor.ID ||
                templateId == ClassicDeparturesTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<ClassicOperationsPlacardContextModel>(serializedContext);

                if (context.Background == null || context.Background.Kind != BackgroundKind.Gradient) return null;

                return new[] { Newtonsoft.Json.JsonConvert.DeserializeObject<GradientContextModel>(context.Background.SerializedContext) };
            }

            return null;
        }

        public ImageContextModel[] GetImages(System.Guid templateId, string serializedContext)
        {
            if (templateId == ClassicArraivalsTemplateDescriptor.ID ||
                templateId == ClassicDeparturesTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<ClassicOperationsPlacardContextModel>(serializedContext);

                if (context.Background == null || context.Background.Kind != BackgroundKind.Image) return null;

                return new[] { Newtonsoft.Json.JsonConvert.DeserializeObject<ImageContextModel>(context.Background.SerializedContext) };
            }

            return null;
        }

        public SoundContextModel[] GetSounds(System.Guid templatedId, string serializedContxt)
        {
            return null;
        }

        public VideoContextModel[] GetVideos(System.Guid templateId, string serializedContext)
        {
            if (templateId == ClassicArraivalsTemplateDescriptor.ID ||
                templateId == ClassicDeparturesTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<ClassicOperationsPlacardContextModel>(serializedContext);

                if (context.Background == null || context.Background.Kind != BackgroundKind.Video) return null;

                return new[] { Newtonsoft.Json.JsonConvert.DeserializeObject<VideoContextModel>(context.Background.SerializedContext) };
            }

            return null;
        }
    }
}
