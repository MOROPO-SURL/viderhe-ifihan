using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Models.Context.Placard;
using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Providers
{
    public class PlacardContextDependenciesProvider : Common.Templating.Providers.Facade.IPlacardContextDependenciesProvider
    {
        public Common.Templating.Models.Context.ImageContextModel[] GetImages(System.Guid templateId, string serializedContext)
        {
            // TODO Register images in blocks!!

            if (templateId == Descriptors.CenteredTraslucentIntroOverImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<CenteredTraslucentIntroOverImagePlacardContextModel>(serializedContext, new Newtonsoft.Json.JsonSerializerSettings
                {
                    TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto
                });

                var result = new System.Collections.Generic.List<Common.Templating.Models.Context.ImageContextModel>
                {
                    context.BackgroundImage
                };

                if (context.HeadImage != null)
                {
                    result.Add(context.HeadImage);
                }

                return result.ToArray();
            }

            if (templateId == Descriptors.FlatContextualOverlapForImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<FlatContextualOverlapForImagePlacardContextModel>(serializedContext, new Newtonsoft.Json.JsonSerializerSettings
                {
                    TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto
                });

                return new[] { context.ContextedImage };
            }

            if (templateId == Descriptors.TrailContextualOverlapForImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<TrailContextualOverlapForImagePlacardContextModel>(serializedContext, new Newtonsoft.Json.JsonSerializerSettings
                {
                    TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto
                });

                return new[] { context.ContextedImage };
            }

            if (templateId == Descriptors.TranslucentContextualOverlapForImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<TranslucentContextualOverlapForImagePlacardContextModel>(serializedContext, new Newtonsoft.Json.JsonSerializerSettings
                {
                    TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto
                });

                return new[] { context.ContextedImage };
            }

            if (templateId == Descriptors.TranslucentContextualOverlapForImageSecuenceTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<TranslucentContextualOverlapForImageSecuencePlacardContextModel>(serializedContext, new Newtonsoft.Json.JsonSerializerSettings
                {
                    TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto
                });

                return context.PresentedPictureSlideSecuence.Slides.Select(item => item.Image).ToArray();
            }

            return null;
        }

        public Common.Templating.Models.Context.VideoContextModel[] GetVideos(System.Guid templateId, string serializedContext)
        {
            return null;
        }
    }
}
