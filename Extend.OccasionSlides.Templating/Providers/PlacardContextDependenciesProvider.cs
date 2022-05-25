using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Providers
{
    public class PlacardContextDependenciesProvider : Common.Templating.Providers.Facade.IPlacardContextDependenciesProvider
    {
        public Common.Templating.Models.Context.ImageContextModel[] GetImages(System.Guid templateId, string serializedContext)
        {
            if (templateId == Descriptors.CenteredTraslucentIntroOverImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.CenteredTraslucentIntroOverImagePlacardContextModel>(serializedContext);

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

            if (templateId == Descriptors.LandscapeContextualFlatOverlapForImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.LandscapeContextualFlatOverlapForImagePlacardContextModel>(serializedContext);

                return new[] { context.ContextedImage };
            }

            if (templateId == Descriptors.LandscapeContextualTrailOverlapForImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.LandscapeContextualTrailOverlapForImagePlacardContextModel>(serializedContext);

                return new[] { context.ContextedImage };
            }

            if (templateId == Descriptors.LandscapeContextualTranslucentOverlapForImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.LandscapeContextualTranslucentOverlapForImagePlacardContextModel>(serializedContext);

                return new[] { context.ContextedImage };
            }

            if (templateId == Descriptors.LandscapeTranslucentContextualOverlapForImageSecuenceTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.LandscapeTranslucentContextualOverlapForImageSecuencePlacardContextModel>(serializedContext);

                return context.PresentedPictureSlideSecuence.Slides.Select(item => item.Image).ToArray();
            }

            if (templateId == Descriptors.PortraitFlatContextualOverlapForImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.PortraitFlatContextualOverlapForImagePlacardContextModel>(serializedContext);

                return new[] { context.ContextedImage };
            }

            if (templateId == Descriptors.PortraitTranslucentContextualOverlapForImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.PortraitTranslucentContextualOverlapForImagePlacardContextModel>(serializedContext);

                return new[] { context.ContextedImage };
            }

            return null;
        }

        public Common.Templating.Models.Context.VideoContextModel[] GetVideos(System.Guid templateId, string serializedContext)
        {
            return null;
        }
    }
}
