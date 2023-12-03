using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Descriptors;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Models.Context.Block;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Models.Context.Placard;
using System.Linq;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Providers
{
    public class PlacardContextDependenciesProvider : Common.Templating.Providers.Facade.IPlacardContextDependenciesProvider
    {
        public Common.Templating.Models.Context.GradientContextModel[] GetGradients(System.Guid templateId, string serializedContext)
        {
            return null;
        }

        public Common.Templating.Models.Context.ImageContextModel[] GetImages(System.Guid templateId, string serializedContext)
        {
            // TODO Register images in ImageSet blocks!!

            if (templateId == CenteredTraslucentIntroOverImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<CenteredTraslucentIntroOverImagePlacardContextModel>(serializedContext, new Newtonsoft.Json.JsonSerializerSettings
                {
                    TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto
                });

                var result = new System.Collections.Generic.List<Common.Templating.Models.Context.ImageContextModel>
                {
                    context.BackgroundImage
                };

                foreach (var item in context.ContentBlocks)
                {
                    if (!(item is ImageContentBlockContextModel)) continue;

                    result.Add((item as ImageContentBlockContextModel).Image);
                }

                return result.ToArray();
            }

            if (templateId == FlatContextualOverlapForImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<FlatContextualOverlapForImagePlacardContextModel>(serializedContext, new Newtonsoft.Json.JsonSerializerSettings
                {
                    TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto
                });

                var result = new System.Collections.Generic.List<Common.Templating.Models.Context.ImageContextModel>
                {
                    context.ContextedImage
                };

                foreach (var item in context.ContentBlocks)
                {
                    if (!(item is ImageContentBlockContextModel)) continue;

                    result.Add((item as ImageContentBlockContextModel).Image);
                }

                return result.ToArray();
            }

            if (templateId == TrailContextualOverlapForImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<TrailContextualOverlapForImagePlacardContextModel>(serializedContext, new Newtonsoft.Json.JsonSerializerSettings
                {
                    TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto
                });

                var result = new System.Collections.Generic.List<Common.Templating.Models.Context.ImageContextModel>
                {
                    context.ContextedImage
                };

                foreach (var item in context.ContentBlocks)
                {
                    if (!(item is ImageContentBlockContextModel)) continue;

                    result.Add((item as ImageContentBlockContextModel).Image);
                }

                return result.ToArray();
            }

            if (templateId == TranslucentContextualOverlapForImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<TranslucentContextualOverlapForImagePlacardContextModel>(serializedContext, new Newtonsoft.Json.JsonSerializerSettings
                {
                    TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto
                });

                var result = new System.Collections.Generic.List<Common.Templating.Models.Context.ImageContextModel>
                {
                    context.ContextedImage
                };

                foreach (var item in context.ContentBlocks)
                {
                    if (!(item is ImageContentBlockContextModel)) continue;

                    result.Add((item as ImageContentBlockContextModel).Image);
                }

                return result.ToArray();
            }

            if (templateId == FlatContextualOverlapForImageSecuenceTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<FlatContextualOverlapForImageSecuencePlacardContextModel>(serializedContext, new Newtonsoft.Json.JsonSerializerSettings
                {
                    TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto
                });

                var result = context.PresentedPictureSlideSecuence.Slides.Select(item => item.Image).ToList();

                foreach (var item in context.ContentBlocks)
                {
                    if (!(item is ImageContentBlockContextModel)) continue;

                    result.Add((item as ImageContentBlockContextModel).Image);
                }

                return result.ToArray();
            }

            if (templateId == TrailContextualOverlapForImageSecuenceTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<TrailContextualOverlapForImageSecuencePlacardContextModel>(serializedContext, new Newtonsoft.Json.JsonSerializerSettings
                {
                    TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto
                });

                var result = context.PresentedPictureSlideSecuence.Slides.Select(item => item.Image).ToList();

                foreach (var item in context.ContentBlocks)
                {
                    if (!(item is ImageContentBlockContextModel)) continue;

                    result.Add((item as ImageContentBlockContextModel).Image);
                }

                return result.ToArray();
            }

            if (templateId == TranslucentContextualOverlapForImageSecuenceTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<TranslucentContextualOverlapForImageSecuencePlacardContextModel>(serializedContext, new Newtonsoft.Json.JsonSerializerSettings
                {
                    TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto
                });

                var result = context.PresentedPictureSlideSecuence.Slides.Select(item => item.Image).ToList();

                foreach (var item in context.ContentBlocks)
                {
                    if (!(item is ImageContentBlockContextModel)) continue;

                    result.Add((item as ImageContentBlockContextModel).Image);
                }

                return result.ToArray();
            }

            return null;
        }

        public Common.Templating.Models.Context.SoundContextModel[] GetSounds(System.Guid templatedId, string serializedContxt)
        {
            return null;
        }

        public Common.Templating.Models.Context.VideoContextModel[] GetVideos(System.Guid templateId, string serializedContext)
        {
            if (templateId == TrailContextualOverlapForVideoTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<TrailContextualOverlapForVideoPlacardContextModel>(serializedContext, new Newtonsoft.Json.JsonSerializerSettings
                {
                    TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto
                });

                return new[] { context.ContextedVideo };
            }

            if (templateId == TranslucentContextualOverlapForVideoTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<TranslucentContextualOverlapForVideoPlacardContextModel>(serializedContext, new Newtonsoft.Json.JsonSerializerSettings
                {
                    TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto
                });

                return new[] { context.ContextedVideo };
            }

            if (templateId == FlatContextualOverlapForVideoTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<FlatContextualOverlapForVideoPlacardContextModel>(serializedContext, new Newtonsoft.Json.JsonSerializerSettings
                {
                    TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto
                });

                return new[] { context.ContextedVideo };
            }

            return null;
        }
    }
}
