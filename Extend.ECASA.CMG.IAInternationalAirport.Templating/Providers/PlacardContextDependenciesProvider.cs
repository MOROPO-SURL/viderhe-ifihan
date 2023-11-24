using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Models.Context;

namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Templating.Providers
{
    public class PlacardContextDependenciesProvider : Common.Templating.Providers.Facade.IPlacardContextDependenciesProvider
    {
        public GradientContextModel[] GetGradients(System.Guid templateId, string serializedContext)
        {
            if (templateId == Descriptors.ClassicArraivalsTemplateDescriptor.ID ||
                templateId == Descriptors.ClassicDeparturesTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.Placard.ClassicOperationsPlacardContextModel>(serializedContext);

                if (context.Background == null || context.Background.Kind != Enumerations.BackgroundKind.Gradient) return null;

                return new[] { Newtonsoft.Json.JsonConvert.DeserializeObject<GradientContextModel>(context.Background.SerializedContext) };
            }

            return null;
        }

        public ImageContextModel[] GetImages(System.Guid templateId, string serializedContext)
        {
            if (templateId == Descriptors.ClassicArraivalsTemplateDescriptor.ID ||
                templateId == Descriptors.ClassicDeparturesTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.Placard.ClassicOperationsPlacardContextModel>(serializedContext);

                if (context.Background == null || context.Background.Kind != Enumerations.BackgroundKind.Image) return null;

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
            if (templateId == Descriptors.ClassicArraivalsTemplateDescriptor.ID ||
                templateId == Descriptors.ClassicDeparturesTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.Placard.ClassicOperationsPlacardContextModel>(serializedContext);

                if (context.Background == null || context.Background.Kind != Enumerations.BackgroundKind.Video) return null;

                return new[] { Newtonsoft.Json.JsonConvert.DeserializeObject<VideoContextModel>(context.Background.SerializedContext) };
            }

            return null;
        }
    }
}
