using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Descriptors;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Enumerations;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Models.Context.Placard;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Extensions;
using System.Linq;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Providers
{
    public class PlacardPresentationViewProvider : Common.Templating.Presentation.Providers.Facade.IPlacardPresentationViewProviderFacade
    {
        public Common.Presentation.Views.BasePlacardPresentationView GetFor(Support.Presentation.Models.View.PlacardViewModel model, System.Func<Xamarin.Essentials.DisplayOrientation> getOrientationFunction, double relativeSizeScaleFactor)
        {
            var orientation = getOrientationFunction.Invoke();

            if (model.Template.Id == TranslucentContextualOverlapForImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<TranslucentContextualOverlapForImagePlacardContextModel>(model.SerializedContext, new Newtonsoft.Json.JsonSerializerSettings { TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto });

                var targetPlacardViewModel = new Models.View.Placard.TranslucentContextualOverlapForImagePlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    ContextedImageSource = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(context.ContextedImage.Id)),
                    ContextedImageThumbnailSource = !context.ContextedImageAspectToFitAndComplementFilled ? null : Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildImageThumbnailUri(context.ContextedImage.ThumbnailId)),
                    ContextedImageZoomingEnabled = context.ContextedImageZoomingEnabled,
                    OverlapSize = context.OverlapSize,
                    OverlapShapeKind = context.OverlapShapeKind,
                    OverlapBackgroundColor = Xamarin.Forms.Color.FromHex(context.OverlapBackgroundColor),
                    OverlapAlignment = context.OverlapAlignment,
                    ContentBlocks = context.ContentBlocks.Select(item => item.ToViewModel()).ToArray()
                };

                if (orientation == Xamarin.Essentials.DisplayOrientation.Portrait)
                {
                    return new Views.Placard.PortraitTranslucentContextualOverlapForImagePlacardView(targetPlacardViewModel, relativeSizeScaleFactor);
                }

                if (context.OverlapAlignment == OverlapAlignment.Start)
                {
                    return new Views.Placard.LeftLandscapeContextualTranslucentOverlapForImagePlacardView(targetPlacardViewModel, relativeSizeScaleFactor);
                }

                return new Views.Placard.RightLandscapeContextualTranslucentOverlapForImagePlacardView(targetPlacardViewModel, relativeSizeScaleFactor);
            }

            if (model.Template.Id == TranslucentContextualOverlapForImageSecuenceTemplateDescriptor.ID)
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
                    return new Views.Placard.PortraitTranslucentContextualOverlapForImageSecuencePlacardView(targetPlacardViewModel, relativeSizeScaleFactor);
                }

                if (context.OverlapAlignment == OverlapAlignment.Start)
                {
                    return new Views.Placard.LeftLandscapeTranslucentContextualOverlapForImageSecuencePlacardView(targetPlacardViewModel, relativeSizeScaleFactor);
                }

                return new Views.Placard.RightLandscapeTranslucentContextualOverlapForImageSecuencePlacardView(targetPlacardViewModel, relativeSizeScaleFactor);
            }

            if (model.Template.Id == FlatContextualOverlapForImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<FlatContextualOverlapForImagePlacardContextModel>(model.SerializedContext, new Newtonsoft.Json.JsonSerializerSettings { TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto });

                var targetPlacardViewModel = new Models.View.Placard.FlatContextualOverlapForImagePlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    ContextedImageSource = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(context.ContextedImage.Id)),
                    ContextedImageThumbnailSource = !context.ContextedImageAspectToFitAndComplementFilled ? null : Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildImageThumbnailUri(context.ContextedImage.ThumbnailId)),
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
                    return new Views.Placard.PortraitFlatContextualOverlapForImagePlacardView(targetPlacardViewModel, relativeSizeScaleFactor);
                }

                if (context.OverlapAlignment == OverlapAlignment.Start)
                {
                    return new Views.Placard.LeftLandscapeContextualFlatOverlapForImagePlacardView(targetPlacardViewModel, relativeSizeScaleFactor);
                }

                return new Views.Placard.RightLandscapeContextualFlatOverlapForImagePlacardView(targetPlacardViewModel, relativeSizeScaleFactor);
            }

            if (model.Template.Id == FlatContextualOverlapForImageSecuenceTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<FlatContextualOverlapForImageSecuencePlacardContextModel>(model.SerializedContext, new Newtonsoft.Json.JsonSerializerSettings { TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto });

                var targetPlacardViewModel = new Models.View.Placard.FlatContextualOverlapForImageSecuencePlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    PresentedPictureSlideSecuence = context.PresentedPictureSlideSecuence,
                    ContextedImageSecuenceCenteredAtPresentation = context.ContextedImageSecuenceCenteredAtPresentation,
                    UseOverlapShadown = context.UseOverlapShadown,
                    OverlapSize = context.OverlapSize,
                    OverlapShapeKind = context.OverlapShapeKind,
                    OverlapBackgroundColor = Xamarin.Forms.Color.FromHex(context.OverlapBackgroundColor),
                    OverlapAlignment = context.OverlapAlignment,
                    ContentBlocks = context.ContentBlocks.Select(item => item.ToViewModel()).ToArray()
                };

                if (context.OverlapAlignment == OverlapAlignment.Start)
                {
                    return new Views.Placard.LeftLandscapeContextualFlatOverlapForImageSecuencePlacardView(targetPlacardViewModel, relativeSizeScaleFactor);
                }

                return new Views.Placard.RightLandscapeContextualFlatOverlapForImageSecuencePlacardView(targetPlacardViewModel, relativeSizeScaleFactor);
            }

            if (model.Template.Id == TrailContextualOverlapForImageTemplateDescriptor.ID)
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
                    ContextedImageThumbnailSource = !context.ContextedImageAspectToFitAndComplementFilled ? null : Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildImageThumbnailUri(context.ContextedImage.ThumbnailId)),
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
                    return new Views.Placard.PortraitTrailContextualOverlapForImagePlacardView(targetPlacardViewModel, relativeSizeScaleFactor);
                }

                if (context.OverlapAlignment == OverlapAlignment.Start)
                {
                    return new Views.Placard.LeftLandscapeContextualTrailOverlapForImagePlacardView(targetPlacardViewModel, relativeSizeScaleFactor);
                }

                return new Views.Placard.RightLandscapeContextualTrailOverlapForImagePlacardView(targetPlacardViewModel, relativeSizeScaleFactor);
            }

            if (model.Template.Id == TrailContextualOverlapForImageSecuenceTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<TrailContextualOverlapForImageSecuencePlacardContextModel>(model.SerializedContext, new Newtonsoft.Json.JsonSerializerSettings
                {
                    TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto
                });

                var targetPlacardViewModel = new Models.View.Placard.TrailContextualOverlapForImageSecuencePlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    PresentedPictureSlideSecuence = context.PresentedPictureSlideSecuence,
                    ContextedImageSecuenceCenteredAtPresentation = context.ContextedImageSecuenceCenteredAtPresentation,
                    OverlapTrailMode = context.OverlapTrailMode,
                    OverlapSize = context.OverlapSize,
                    OverlapShapeKind = context.OverlapShapeKind,
                    OverlapBackgroundColor = Xamarin.Forms.Color.FromHex(context.OverlapBackgroundColor),
                    OverlapAlignment = context.OverlapAlignment,
                    ContentBlocks = context.ContentBlocks.Select(item => item.ToViewModel()).ToArray()
                };

                if (context.OverlapAlignment == OverlapAlignment.Start)
                {
                    return new Views.Placard.LeftLandscapeContextualTrailOverlapForImageSecuencePlacardView(targetPlacardViewModel, relativeSizeScaleFactor);
                }

                return new Views.Placard.RightLandscapeContextualTrailOverlapForImageSecuencePlacardView(targetPlacardViewModel, relativeSizeScaleFactor);
            }

            if (model.Template.Id == CenteredTraslucentIntroOverImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<CenteredTraslucentIntroOverImagePlacardContextModel>(model.SerializedContext, new Newtonsoft.Json.JsonSerializerSettings { TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto });

                var targetPlacardViewModel = new Models.View.Placard.CenteredTraslucentIntroOverImagePlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    BackgroundImageSource = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(context.BackgroundImage.Id)),
                    BackgroundImageThumbnailSource = !context.BackgroundImageAspectToFitAndComplementFilled ? null : Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildImageThumbnailUri(context.BackgroundImage.ThumbnailId)),
                    BackgroundImageZoomingEnabled = context.BackgroundImageZoomingEnabled,
                    OverlapOpacity = context.OverlapOpacity,
                    OverlapBackgroundColor = Xamarin.Forms.Color.FromHex(context.OverlapBackgroundColor),
                    ContentBoxPresentationKind = context.ContentBoxPresentationKind,
                    ContentBlocks = context.ContentBlocks.Select(item => item.ToViewModel()).ToArray()
                };

                return new Views.Placard.CenteredTraslucentIntroOverImagePlacardView(targetPlacardViewModel, relativeSizeScaleFactor);
            }

            if (model.Template.Id == TrailContextualOverlapForVideoTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<TrailContextualOverlapForVideoPlacardContextModel>(model.SerializedContext, new Newtonsoft.Json.JsonSerializerSettings
                {
                    TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto
                });

                var targetPlacardViewModel = new Models.View.Placard.TrailContextualOverlapForVideoPlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ContextedVideoSource = SmartSolucionesCuba.XFToolKit.Presentation.Sources.Video.VideoSource.FromUri(Support.Presentation.Factories.VideoUriFactory.BuildVideoUri(context.ContextedVideo.Id, context.ContextedVideo.Extension).AbsoluteUri),
                    IsContextedVideoFramed = context.IsContextedVideoFramed,
                    ContextedVideoCenteredAtPresentation = context.ContextedVideoCenteredAtPresentation,
                    OverlapTrailMode = context.OverlapTrailMode,
                    OverlapSize = context.OverlapSize,
                    OverlapShapeKind = context.OverlapShapeKind,
                    OverlapBackgroundColor = Xamarin.Forms.Color.FromHex(context.OverlapBackgroundColor),
                    OverlapAlignment = context.OverlapAlignment,
                    ContentBlocks = context.ContentBlocks.Select(item => item.ToViewModel()).ToArray()
                };

                if (context.OverlapAlignment == OverlapAlignment.Start)
                {
                    return new Views.Placard.LeftLandscapeContextualTrailOverlapForVideoPlacardView(targetPlacardViewModel, relativeSizeScaleFactor);
                }

                return new Views.Placard.RightLandscapeContextualTrailOverlapForVideoPlacardView(targetPlacardViewModel, relativeSizeScaleFactor);
            }

            if (model.Template.Id == TranslucentContextualOverlapForVideoTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<TranslucentContextualOverlapForVideoPlacardContextModel>(model.SerializedContext, new Newtonsoft.Json.JsonSerializerSettings
                {
                    TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto
                });

                var targetPlacardViewModel = new Models.View.Placard.TranslucentContextualOverlapForVideoPlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ContextedVideoSource = SmartSolucionesCuba.XFToolKit.Presentation.Sources.Video.VideoSource.FromUri(Support.Presentation.Factories.VideoUriFactory.BuildVideoUri(context.ContextedVideo.Id, context.ContextedVideo.Extension).AbsoluteUri),
                    OverlapSize = context.OverlapSize,
                    OverlapShapeKind = context.OverlapShapeKind,
                    OverlapBackgroundColor = Xamarin.Forms.Color.FromHex(context.OverlapBackgroundColor),
                    OverlapAlignment = context.OverlapAlignment,
                    ContentBlocks = context.ContentBlocks.Select(item => item.ToViewModel()).ToArray()
                };

                if (context.OverlapAlignment == OverlapAlignment.Start)
                {
                    return new Views.Placard.LeftLandscapeContextualTranslucentOverlapForVideoPlacardView(targetPlacardViewModel, relativeSizeScaleFactor);
                }

                return new Views.Placard.RightLandscapeContextualTranslucentOverlapForVideoPlacardView(targetPlacardViewModel, relativeSizeScaleFactor);
            }

            if (model.Template.Id == FlatContextualOverlapForVideoTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<FlatContextualOverlapForVideoPlacardContextModel>(model.SerializedContext, new Newtonsoft.Json.JsonSerializerSettings
                {
                    TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto
                });

                var targetPlacardViewModel = new Models.View.Placard.FlatContextualOverlapForVideoPlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ContextedVideoSource = SmartSolucionesCuba.XFToolKit.Presentation.Sources.Video.VideoSource.FromUri(Support.Presentation.Factories.VideoUriFactory.BuildVideoUri(context.ContextedVideo.Id, context.ContextedVideo.Extension).AbsoluteUri),
                    ContextedVideoCenteredAtPresentation = context.ContextedVideoCenteredAtPresentation,
                    OverlapSize = context.OverlapSize,
                    OverlapShapeKind = context.OverlapShapeKind,
                    OverlapBackgroundColor = Xamarin.Forms.Color.FromHex(context.OverlapBackgroundColor),
                    OverlapAlignment = context.OverlapAlignment,
                    ContentBlocks = context.ContentBlocks.Select(item => item.ToViewModel()).ToArray(),
                    UseOverlapShadown = context.UseOverlapShadown
                };

                if (context.OverlapAlignment == OverlapAlignment.Start)
                {
                    return new Views.Placard.LeftLandscapeContextualFlatOverlapForVideoPlacardView(targetPlacardViewModel, relativeSizeScaleFactor);
                }

                return new Views.Placard.RightLandscapeContextualFlatOverlapForVideoPlacardView(targetPlacardViewModel, relativeSizeScaleFactor);
            }

            if (model.Template.Id == GradientContextualOverlapForImageTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<GradientContextualOverlapForImagePlacardContextModel>(model.SerializedContext, new Newtonsoft.Json.JsonSerializerSettings { TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto });

                var targetPlacardViewModel = new Models.View.Placard.GradientContextualOverlapForImagePlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    ContextedImageSource = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(context.ContextedImage.Id)),
                    ContextedImageThumbnailSource = !context.ContextedImageAspectToFitAndComplementFilled ? null : Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildImageThumbnailUri(context.ContextedImage.ThumbnailId)),
                    ContextedImageZoomingEnabled = context.ContextedImageZoomingEnabled,
                    ContextedImageCenteredAtPresentation = context.ContextedImageCenteredAtPresentation,
                    OverlapSize = context.OverlapSize,
                    GradientColor = Xamarin.Forms.Color.FromHex(context.GradientColor),
                    OverlapAlignment = context.OverlapAlignment,
                    ContentBlocks = context.ContentBlocks.Select(item => item.ToViewModel()).ToArray()
                };

                if (orientation == Xamarin.Essentials.DisplayOrientation.Portrait || context.IsOverlapAnchoredAtVertical)
                {
                    return new Views.Placard.PortraitGradientContextualOverlapForImagePlacardView(targetPlacardViewModel, relativeSizeScaleFactor);
                }

                if (context.OverlapAlignment == OverlapAlignment.Start)
                {
                    return new Views.Placard.LeftLandscapeContextualGradientOverlapForImagePlacardView(targetPlacardViewModel, relativeSizeScaleFactor);
                }

                return new Views.Placard.RightLandscapeContextualGradientOverlapForImagePlacardView(targetPlacardViewModel, relativeSizeScaleFactor);
            }

            return null;
        }
    }
}

