using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Models.Context;
using SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Descriptors;
using SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Models.Context;
using System;
using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Providers
{
    public class PlacardContextDependenciesProvider : Common.Templating.Providers.Facade.IPlacardContextDependenciesProvider
    {
        public GradientContextModel[] GetGradients(Guid templateId, string serializedContext)
        {
            return null;
        }

        public ImageContextModel[] GetImages(Guid templateId, string serializedContext)
        {
            if (templateId == PictureSlideSecuenceTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<PictureSlideSecuencePlacardContextModel>(serializedContext);

                return context.Slides.Select(item => item.Image).ToArray();
            }

            if (templateId == SimplePictureTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<SimplePicturePlacardContextModel>(serializedContext);

                return new [] { context.Image };
            }

            if (templateId == LandscapePicturePresentingPictureTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<LandscapePicturePresentingPicturePlacardContextModel>(serializedContext);

                return new [] { context.PresenterImage, context.PresentedImage };
            }

            if (templateId == LandscapePicturePresentingVideoTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<LandscapePicturePresentingVideoPlacardContextModel>(serializedContext);

                return new [] { context.PresenterImage };
            }

            if (templateId == PortraitPicturePresentingPictureTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<PortraitPicturePresentingPicturePlacardContextModel>(serializedContext);

                return new [] { context.PresenterImage, context.PresentedImage };
            }

            if (templateId == PortraitPicturePresentingVideoTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<PortraitPicturePresentingVideoPlacardContextModel>(serializedContext);

                return new [] { context.PresenterImage };
            }

            if (templateId == LandscapePicturePresentingPictureSlideSecuenceTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<LandscapePicturePresentingPictureSlideSecuencePlacardContextModel>(serializedContext);

                var result = context.PresentedPictureSlideSecuence.Slides.Select(item => item.Image).ToList();

                result.Add(context.PresenterImage);

                return result.ToArray();
            }

            if (templateId == PortraitPicturePresentingPictureSlideSecuenceTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<PortraitPicturePresentingPictureSlideSecuencePlacardContextModel>(serializedContext);

                var result = context.PresentedPictureSlideSecuence.Slides.Select(item => item.Image).ToList();

                result.Add(context.PresenterImage);

                return result.ToArray();
            }

            return null;
        }

        public SoundContextModel[] GetSounds(Guid templatedId, string serializedContxt)
        {
            return null;
        }

        public VideoContextModel[] GetVideos(Guid templateId, string serializedContext)
        {
            if (templateId == SimpleVideoTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<SimpleVideoPlacardContextModel>(serializedContext);

                return new [] { context.Video };
            }

            if (templateId == LandscapePicturePresentingVideoTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<LandscapePicturePresentingVideoPlacardContextModel>(serializedContext);

                return new [] { context.PresentedVideo };
            }

            if (templateId == PortraitPicturePresentingVideoTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<PortraitPicturePresentingVideoPlacardContextModel>(serializedContext);

                return new [] { context.PresentedVideo };
            }

            return null;
        }
    }
}
