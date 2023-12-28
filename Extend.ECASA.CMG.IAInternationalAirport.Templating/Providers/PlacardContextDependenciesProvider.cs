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
                var list = new System.Collections.Generic.List<GradientContextModel>();

                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<ClassicOperationsPlacardContextModel>(serializedContext);

                if (context.Background != null && context.Background.Kind == BackgroundKind.Gradient)
                {
                    list.Add(Newtonsoft.Json.JsonConvert.DeserializeObject<GradientContextModel>(context.Background.SerializedContext));
                };

                if (context.HeaderBackground != null && context.HeaderBackground.Kind == BackgroundKind.Gradient)
                {
                    list.Add(Newtonsoft.Json.JsonConvert.DeserializeObject<GradientContextModel>(context.HeaderBackground.SerializedContext));
                };

                if (list.Count > 0) return list.ToArray();
            }

            return null;
        }

        public ImageContextModel[] GetImages(System.Guid templateId, string serializedContext)
        {
            if (templateId == ClassicArraivalsTemplateDescriptor.ID ||
                templateId == ClassicDeparturesTemplateDescriptor.ID)
            {
                var list = new System.Collections.Generic.List<ImageContextModel>();

                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<ClassicOperationsPlacardContextModel>(serializedContext);

                if (context.Background != null && context.Background.Kind == BackgroundKind.Image)
                {
                    list.Add(Newtonsoft.Json.JsonConvert.DeserializeObject<ImageContextModel>(context.Background.SerializedContext));
                };

                if (context.HeaderBackground != null && context.HeaderBackground.Kind == BackgroundKind.Image)
                {
                    list.Add(Newtonsoft.Json.JsonConvert.DeserializeObject<ImageContextModel>(context.HeaderBackground.SerializedContext));
                };

                if (list.Count > 0) return list.ToArray();
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
                var list = new System.Collections.Generic.List<VideoContextModel>();

                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<ClassicOperationsPlacardContextModel>(serializedContext);

                if (context.Background != null && context.Background.Kind == BackgroundKind.Video)
                {
                    list.Add(Newtonsoft.Json.JsonConvert.DeserializeObject<VideoContextModel>(context.Background.SerializedContext));
                };

                if (context.HeaderBackground != null && context.HeaderBackground.Kind == BackgroundKind.Video)
                {
                    list.Add(Newtonsoft.Json.JsonConvert.DeserializeObject<VideoContextModel>(context.HeaderBackground.SerializedContext));
                };

                if (list.Count > 0) return list.ToArray();
            }

            return null;
        }
    }
}
