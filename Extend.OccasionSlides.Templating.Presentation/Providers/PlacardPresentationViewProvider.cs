using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Models.Context.Placard;
using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Extensions;
using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Providers
{
    public class PlacardPresentationViewProvider : Common.Templating.Presentation.Providers.Facade.IPlacardPresentationViewProviderFacade
    {
        public Common.Presentation.Views.BasePlacardPresentationView GetFor(Support.Presentation.Models.View.PlacardViewModel model, System.Func<Xamarin.Essentials.DisplayOrientation> getOrientationFunction)
        {
            var orientation = getOrientationFunction.Invoke();

            if (model.Template.Id == Descriptors.TranslucentContextualOverlapForImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<TranslucentContextualOverlapForImagePlacardContextModel>(model.SerializedContext, new Newtonsoft.Json.JsonSerializerSettings { TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto });

                var targetPlacardViewModel = new Models.View.Placard.TranslucentContextualOverlapForImagePlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    ContextedImageSource = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(context.ContextedImage.Id)),
                    ContextedImageThumbnailSource = !context.ContextedImageAspectToFitAndComplementFilled ? null : Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildThumbnailUri(context.ContextedImage.ThumbnailId)),
                    ContextedImageZoomingEnabled = context.ContextedImageZoomingEnabled,
                    OverlapSize = context.OverlapSize,
                    OverlapShapeKind = context.OverlapShapeKind,
                    OverlapBackgroundColor = Xamarin.Forms.Color.FromHex(context.OverlapBackgroundColor),
                    OverlapAlignment = context.OverlapAlignment,
                    ContentBlocks = context.ContentBlocks.Select(item => item.ToViewModel()).ToArray()
                };

                if (orientation == Xamarin.Essentials.DisplayOrientation.Portrait)
                {
                    return new Views.Placard.PortraitTranslucentContextualOverlapForImagePlacardView(targetPlacardViewModel);
                }

                if (context.OverlapAlignment == Enumerations.OverlapAlignment.Start)
                {
                    return new Views.Placard.LeftLandscapeContextualTranslucentOverlapForImagePlacardView(targetPlacardViewModel);
                }

                return new Views.Placard.RightLandscapeContextualTranslucentOverlapForImagePlacardView(targetPlacardViewModel);
            }

            if (model.Template.Id == Descriptors.TranslucentContextualOverlapForImageSecuenceTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<TranslucentContextualOverlapForImageSecuencePlacardContextModel>(model.SerializedContext, new Newtonsoft.Json.JsonSerializerSettings { TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto });

                var targetPlacardViewModel = new Models.View.Placard.TranslucentContextualOverlapForImageSecuencePlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    PresentedPictureSlideSecuence = context.PresentedPictureSlideSecuence,
                    OverlapSize = context.OverlapSize,
                    OverlapShapeKind = context.OverlapShapeKind,
                    OverlapBackgroundColor = Xamarin.Forms.Color.FromHex(context.OverlapBackgroundColor),
                    OverlapAlignment = context.OverlapAlignment,
                    ContentBlocks = context.ContentBlocks.Select(item => item.ToViewModel()).ToArray()
                };

                if (orientation == Xamarin.Essentials.DisplayOrientation.Portrait)
                {
                    return new Views.Placard.PortraitTranslucentContextualOverlapForImageSecuencePlacardView(targetPlacardViewModel);
                }

                if (context.OverlapAlignment == Enumerations.OverlapAlignment.Start)
                {
                    return new Views.Placard.LeftLandscapeTranslucentContextualOverlapForImageSecuencePlacardView(targetPlacardViewModel);
                }

                return new Views.Placard.RightLandscapeTranslucentContextualOverlapForImageSecuencePlacardView(targetPlacardViewModel);
            }

            if (model.Template.Id == Descriptors.FlatContextualOverlapForImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<FlatContextualOverlapForImagePlacardContextModel>(model.SerializedContext, new Newtonsoft.Json.JsonSerializerSettings { TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto });

                var targetPlacardViewModel = new Models.View.Placard.FlatContextualOverlapForImagePlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    ContextedImageSource = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(context.ContextedImage.Id)),
                    ContextedImageThumbnailSource = !context.ContextedImageAspectToFitAndComplementFilled ? null : Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildThumbnailUri(context.ContextedImage.ThumbnailId)),
                    ContextedImageZoomingEnabled = context.ContextedImageZoomingEnabled,
                    ContextedImageCenteredAtPresentation = context.ContextedImageCenteredAtPresentation,
                    UseOverlapShadown = context.UseOverlapShadown,
                    OverlapSize = context.OverlapSize,
                    OverlapShapeKind = context.OverlapShapeKind,
                    OverlapBackgroundColor = Xamarin.Forms.Color.FromHex(context.OverlapBackgroundColor),
                    OverlapAlignment = context.OverlapAlignment,
                    ContentBlocks = context.ContentBlocks.Select(item => item.ToViewModel()).ToArray()
                };

                if (orientation == Xamarin.Essentials.DisplayOrientation.Portrait)
                {
                    return new Views.Placard.PortraitFlatContextualOverlapForImagePlacardView(targetPlacardViewModel);
                }

                if (context.OverlapAlignment == Enumerations.OverlapAlignment.Start)
                {
                    return new Views.Placard.LeftLandscapeContextualFlatOverlapForImagePlacardView(targetPlacardViewModel);
                }

                return new Views.Placard.RightLandscapeContextualFlatOverlapForImagePlacardView(targetPlacardViewModel);
            }

            if (model.Template.Id == Descriptors.TrailContextualOverlapForImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<TrailContextualOverlapForImagePlacardContextModel>(model.SerializedContext, new Newtonsoft.Json.JsonSerializerSettings
                {
                    TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto
                });

                var targetPlacardViewModel = new Models.View.Placard.TrailContextualOverlapForImagePlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    ContextedImageSource = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(context.ContextedImage.Id)),
                    ContextedImageThumbnailSource = !context.ContextedImageAspectToFitAndComplementFilled ? null : Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildThumbnailUri(context.ContextedImage.ThumbnailId)),
                    ContextedImageZoomingEnabled = context.ContextedImageZoomingEnabled,
                    ContextedImageCenteredAtPresentation = context.ContextedImageCenteredAtPresentation,
                    OverlapTrailMode = context.OverlapTrailMode,
                    OverlapSize = context.OverlapSize,
                    OverlapShapeKind = context.OverlapShapeKind,
                    OverlapBackgroundColor = Xamarin.Forms.Color.FromHex(context.OverlapBackgroundColor),
                    OverlapAlignment = context.OverlapAlignment,
                    ContentBlocks = context.ContentBlocks.Select(item => item.ToViewModel()).ToArray()
                };

                if (orientation == Xamarin.Essentials.DisplayOrientation.Portrait)
                {
                    return new Views.Placard.PortraitTrailContextualOverlapForImagePlacardView(targetPlacardViewModel);
                }

                if (context.OverlapAlignment == Enumerations.OverlapAlignment.Start)
                {
                    return new Views.Placard.LeftLandscapeContextualTrailOverlapForImagePlacardView(targetPlacardViewModel);
                }

                return new Views.Placard.RightLandscapeContextualTrailOverlapForImagePlacardView(targetPlacardViewModel);
            }

            if (model.Template.Id == Descriptors.CenteredTraslucentIntroOverImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<CenteredTraslucentIntroOverImagePlacardContextModel>(model.SerializedContext, new Newtonsoft.Json.JsonSerializerSettings { TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto });

                var targetPlacardViewModel = new Models.View.Placard.CenteredTraslucentIntroOverImagePlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    BackgroundImageSource = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(context.BackgroundImage.Id)),
                    BackgroundImageThumbnailSource = !context.BackgroundImageAspectToFitAndComplementFilled ? null : Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildThumbnailUri(context.BackgroundImage.ThumbnailId)),
                    BackgroundImageZoomingEnabled = context.BackgroundImageZoomingEnabled,
                    OverlapOpacity = context.OverlapOpacity,
                    OverlapBackgroundColor = Xamarin.Forms.Color.FromHex(context.OverlapBackgroundColor),
                    ContentBoxPresentationKind = context.ContentBoxPresentationKind,
                    ContentBlocks = context.ContentBlocks.Select(item => item.ToViewModel()).ToArray()
                };

                return new Views.Placard.CenteredTraslucentIntroOverImagePlacardView(targetPlacardViewModel);
            }

            if (model.Template.Id == Descriptors.TrailContextualOverlapForVideoTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<TrailContextualOverlapForVideoPlacardContextModel>(model.SerializedContext, new Newtonsoft.Json.JsonSerializerSettings
                {
                    TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto
                });

                var targetPlacardViewModel = new Models.View.Placard.TrailContextualOverlapForVideoPlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ContextedVideoSource = XFToolKit.Presentation.Sources.Video.VideoSource.FromUri(Support.Presentation.Factories.VideoUriFactory.BuildVideoUri(context.ContextedVideo.Id, context.ContextedVideo.Extension).AbsoluteUri),
                    IsContextedVideoFramed = context.IsContextedVideoFramed,
                    ContextedVideoCenteredAtPresentation = context.ContextedVideoCenteredAtPresentation,
                    OverlapTrailMode = context.OverlapTrailMode,
                    OverlapSize = context.OverlapSize,
                    OverlapShapeKind = context.OverlapShapeKind,
                    OverlapBackgroundColor = Xamarin.Forms.Color.FromHex(context.OverlapBackgroundColor),
                    OverlapAlignment = context.OverlapAlignment,
                    ContentBlocks = context.ContentBlocks.Select(item => item.ToViewModel()).ToArray()
                };

                if (context.OverlapAlignment == Enumerations.OverlapAlignment.Start)
                {
                    return new Views.Placard.LeftLandscapeContextualTrailOverlapForVideoPlacardView(targetPlacardViewModel);
                }

                return new Views.Placard.RightLandscapeContextualTrailOverlapForVideoPlacardView(targetPlacardViewModel);
            }

            if (model.Template.Id == Descriptors.TranslucentContextualOverlapForVideoTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<TranslucentContextualOverlapForVideoPlacardContextModel>(model.SerializedContext, new Newtonsoft.Json.JsonSerializerSettings
                {
                    TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto
                });

                var targetPlacardViewModel = new Models.View.Placard.TranslucentContextualOverlapForVideoPlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ContextedVideoSource = XFToolKit.Presentation.Sources.Video.VideoSource.FromUri(Support.Presentation.Factories.VideoUriFactory.BuildVideoUri(context.ContextedVideo.Id, context.ContextedVideo.Extension).AbsoluteUri),
                    OverlapSize = context.OverlapSize,
                    OverlapShapeKind = context.OverlapShapeKind,
                    OverlapBackgroundColor = Xamarin.Forms.Color.FromHex(context.OverlapBackgroundColor),
                    OverlapAlignment = context.OverlapAlignment,
                    ContentBlocks = context.ContentBlocks.Select(item => item.ToViewModel()).ToArray()
                };

                if (context.OverlapAlignment == Enumerations.OverlapAlignment.Start)
                {
                    return new Views.Placard.LeftLandscapeContextualTranslucentOverlapForVideoPlacardView(targetPlacardViewModel);
                }

                return new Views.Placard.RightLandscapeContextualTranslucentOverlapForVideoPlacardView(targetPlacardViewModel);
            }

            if (model.Template.Id == Descriptors.FlatContextualOverlapForVideoTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<FlatContextualOverlapForVideoPlacardContextModel>(model.SerializedContext, new Newtonsoft.Json.JsonSerializerSettings
                {
                    TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto
                });

                var targetPlacardViewModel = new Models.View.Placard.FlatContextualOverlapForVideoPlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ContextedVideoSource = XFToolKit.Presentation.Sources.Video.VideoSource.FromUri(Support.Presentation.Factories.VideoUriFactory.BuildVideoUri(context.ContextedVideo.Id, context.ContextedVideo.Extension).AbsoluteUri),
                    ContextedVideoCenteredAtPresentation = context.ContextedVideoCenteredAtPresentation,
                    OverlapSize = context.OverlapSize,
                    OverlapShapeKind = context.OverlapShapeKind,
                    OverlapBackgroundColor = Xamarin.Forms.Color.FromHex(context.OverlapBackgroundColor),
                    OverlapAlignment = context.OverlapAlignment,
                    ContentBlocks = context.ContentBlocks.Select(item => item.ToViewModel()).ToArray(),
                    UseOverlapShadown = context.UseOverlapShadown
                };

                if (context.OverlapAlignment == Enumerations.OverlapAlignment.Start)
                {
                    return new Views.Placard.LeftLandscapeContextualFlatOverlapForVideoPlacardView(targetPlacardViewModel);
                }

                return new Views.Placard.RightLandscapeContextualFlatOverlapForVideoPlacardView(targetPlacardViewModel);
            }

            return null;
        }
    }
}

