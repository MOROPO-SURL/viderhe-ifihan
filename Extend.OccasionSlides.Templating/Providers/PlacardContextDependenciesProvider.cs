using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Models.Context.Placard;
using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Providers
{
    public class PlacardContextDependenciesProvider : Common.Templating.Providers.Facade.IPlacardContextDependenciesProvider
    {
        public Common.Templating.Models.Context.ImageContextModel[] GetImages(System.Guid templateId, string serializedContext)
        {
            if (templateId == Descriptors.CenteredTraslucentIntroOverImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<CenteredTraslucentIntroOverImagePlacardContextModel>(serializedContext);

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
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<FlatContextualOverlapForImagePlacardContextModel>(serializedContext);

                return new[] { context.ContextedImage };
            }

            if (templateId == Descriptors.TrailContextualOverlapForImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<TrailContextualOverlapForImagePlacardContextModel>(serializedContext);

                return new[] { context.ContextedImage };
            }

            if (templateId == Descriptors.TranslucentContextualOverlapForImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<TranslucentContextualOverlapForImagePlacardContextModel>(serializedContext);

                return new[] { context.ContextedImage };
            }

            if (templateId == Descriptors.TranslucentContextualOverlapForImageSecuenceTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<TranslucentContextualOverlapForImageSecuencePlacardContextModel>(serializedContext);

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
