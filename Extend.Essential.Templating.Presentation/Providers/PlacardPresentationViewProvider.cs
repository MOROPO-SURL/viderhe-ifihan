using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Providers.Facade;
using MOROPO.VIDERHE.Extend.Essential.Templating.Descriptors;
using MOROPO.VIDERHE.Extend.Essential.Templating.Enumerations;
using MOROPO.VIDERHE.Extend.Essential.Templating.Models.Context;
using MOROPO.VIDERHE.Extend.Essential.Templating.Presentation.Extensions;
using MOROPO.VIDERHE.Extend.Essential.Templating.Presentation.Views;
using MOROPO.VIDERHE.Support.Presentation.Factories;
using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace MOROPO.VIDERHE.Extend.Essential.Templating.Presentation.Providers
{
    public class PlacardPresentationViewProvider : IPlacardPresentationViewProviderFacade
    {
        public Common.Presentation.Views.BasePlacardPresentationView GetFor(PlacardViewModel model, System.Func<Xamarin.Essentials.DisplayOrientation> getOrientationFunction, double relativeSizeScaleFactor)
        {
            if (model.Template.Id == PictureSlideSecuenceTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<PictureSlideSecuencePlacardContextModel>(model.SerializedContext);

                return new PictureSlideSecuencePlacardView(context, relativeSizeScaleFactor);
            }

            if (model.Template.Id == SimpleVideoTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<SimpleVideoPlacardContextModel>(model.SerializedContext);

                return new SimpleVideoPlacardView(new Models.View.SimpleVideoPlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    //VideoSource = SmartSolucionesCuba.XFToolKit.Presentation.Sources.Video.VideoSource.FromUri(VideoUriFactory.BuildVideoUri(context.Video.Id, context.Video.Extension).AbsoluteUri),
                    VideoSource = Xamarin.CommunityToolkit.Core.MediaSource.FromUri(VideoUriFactory.BuildVideoUri(context.Video.Id, context.Video.Extension).AbsoluteUri),
                    StrechAspect = (Xamarin.Forms.Aspect)context.StrechAspectKind,
                    Muted = context.Muted
                }, relativeSizeScaleFactor);
            }

            if (model.Template.Id == SimplePictureTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<SimplePicturePlacardContextModel>(model.SerializedContext);

                if (context.LayoutMode == PictureLayoutMode.AspectFitWithOpaqueAspectFilledBySelf)
                {
                    return new SelfOpaqueFillSimplePicturePlacardView(new Models.View.SelfOpaqueFillSimplePicturePlacardViewModel
                    {
                        RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                        ScreenPresentationTime = context.ScreenPresentationTime,
                        Source = Xamarin.Forms.ImageSource.FromUri(ImageUriFactory.BuildImageUri(context.Image.Id)),
                        ThumnailSource = Xamarin.Forms.ImageSource.FromUri(ThumbnailUriFactory.BuildImageThumbnailUri(context.Image.Id)),
                        Aspect = context.LayoutMode.ToXamarinFormsAspect(),
                        ZoomingEnabled = context.IsZoomingEnabled
                    }, relativeSizeScaleFactor);
                }
                else
                {
                    return new SimplePicturePlacardView(new Models.View.SimplePicturePlacardViewModel
                    {
                        RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                        ScreenPresentationTime = context.ScreenPresentationTime,
                        Source = Xamarin.Forms.ImageSource.FromUri(ImageUriFactory.BuildImageUri(context.Image.Id)),
                        Aspect = context.LayoutMode.ToXamarinFormsAspect(),
                        ZoomingEnabled = context.IsZoomingEnabled
                    }, relativeSizeScaleFactor);
                }
            }

            if (model.Template.Id == LandscapePicturePresentingPictureTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<LandscapePicturePresentingPicturePlacardContextModel>(model.SerializedContext);

                return new LandscapePicturePresentingPicturePlacardView(new Models.View.LandscapePicturePresentingPicturePlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    PresenterSource = Xamarin.Forms.ImageSource.FromUri(ImageUriFactory.BuildImageUri(context.PresenterImage.Id)),
                    PresenterSide = context.PresenterSide,
                    PresenterImageWidth = context.PresenterImage.Width,
                    PresenterImageHeigth = context.PresenterImage.Height,
                    PresentedSource = Xamarin.Forms.ImageSource.FromUri(ImageUriFactory.BuildImageUri(context.PresentedImage.Id)),
                    PresentedImageCenteredAtPresentation = context.PresentedImageCenteredAtPresentation,
                    PresentedImageZoomingEnabled = context.PresentedImageZoomingEnabled
                }, relativeSizeScaleFactor);
            }

            if (model.Template.Id == LandscapePicturePresentingVideoTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<LandscapePicturePresentingVideoPlacardContextModel>(model.SerializedContext);

                return new LandscapePicturePresentingVideoPlacardView(new Models.View.LandscapePicturePresentingVideoPlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    PresenterSource = Xamarin.Forms.ImageSource.FromUri(ImageUriFactory.BuildImageUri(context.PresenterImage.Id)),
                    PresenterSide = context.PresenterSide,
                    PresenterImageWidth = context.PresenterImage.Width,
                    PresenterImageHeigth = context.PresenterImage.Height,
                    //PresentedSource = SmartSolucionesCuba.XFToolKit.Presentation.Sources.Video.VideoSource.FromUri(VideoUriFactory.BuildVideoUri(context.PresentedVideo.Id, context.PresentedVideo.Extension).AbsoluteUri),
                    PresentedSource = Xamarin.CommunityToolkit.Core.MediaSource.FromUri(VideoUriFactory.BuildVideoUri(context.PresentedVideo.Id, context.PresentedVideo.Extension).AbsoluteUri),
                    PresentedVideoCenteredAtPresentation = context.PresentedVideoCenteredAtPresentation,
                    PresentedVideoMuted = context.PresentedVideoMuted
                }, relativeSizeScaleFactor);
            }

            if (model.Template.Id == PortraitPicturePresentingPictureTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<PortraitPicturePresentingPicturePlacardContextModel>(model.SerializedContext);

                return new PortraitPicturePresentingPicturePlacardView(new Models.View.PortraitPicturePresentingPicturePlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    PresenterSource = Xamarin.Forms.ImageSource.FromUri(ImageUriFactory.BuildImageUri(context.PresenterImage.Id)),
                    PresenterSide = context.PresenterSide,
                    PresenterImageWidth = context.PresenterImage.Width,
                    PresenterImageHeigth = context.PresenterImage.Height,
                    PresentedSource = Xamarin.Forms.ImageSource.FromUri(ImageUriFactory.BuildImageUri(context.PresentedImage.Id)),
                    PresentedImageCenteredAtPresentation = context.PresentedImageCenteredAtPresentation,
                    PresentedImageZoomingEnabled = context.PresentedImageZoomingEnabled
                }, relativeSizeScaleFactor);
            }

            if (model.Template.Id == PortraitPicturePresentingVideoTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<PortraitPicturePresentingVideoPlacardContextModel>(model.SerializedContext);

                return new PortraitPicturePresentingVideoPlacardView(new Models.View.PortraitPicturePresentingVideoPlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    PresenterSource = Xamarin.Forms.ImageSource.FromUri(ImageUriFactory.BuildImageUri(context.PresenterImage.Id)),
                    PresenterSide = context.PresenterSide,
                    PresenterImageWidth = context.PresenterImage.Width,
                    PresenterImageHeigth = context.PresenterImage.Height,
                    //PresentedSource = SmartSolucionesCuba.XFToolKit.Presentation.Sources.Video.VideoSource.FromUri(VideoUriFactory.BuildVideoUri(context.PresentedVideo.Id, context.PresentedVideo.Extension).AbsoluteUri),
                    PresentedSource = Xamarin.CommunityToolkit.Core.MediaSource.FromUri(VideoUriFactory.BuildVideoUri(context.PresentedVideo.Id, context.PresentedVideo.Extension).AbsoluteUri),
                    PresentedVideoCenteredAtPresentation = context.PresentedVideoCenteredAtPresentation,
                    PresentedVideoMuted = context.PresentedVideoMuted
                }, relativeSizeScaleFactor);
            }

            if (model.Template.Id == LandscapePicturePresentingPictureSlideSecuenceTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<LandscapePicturePresentingPictureSlideSecuencePlacardContextModel>(model.SerializedContext);

                return new LandscapePicturePresentingPictureSlideSecuencePlacardView(new Models.View.LandscapePicturePresentingPictureSlideSecuencePlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    PresenterSource = Xamarin.Forms.ImageSource.FromUri(ImageUriFactory.BuildImageUri(context.PresenterImage.Id)),
                    PresenterSide = context.PresenterSide,
                    PresenterImageWidth = context.PresenterImage.Width,
                    PresenterImageHeigth = context.PresenterImage.Height,
                    PresentedPictureSlideSecuence = context.PresentedPictureSlideSecuence,
                    PresentedPictureSlideSecuenceCenteredAtPresentation = context.PresentedPictureSlideSecuenceCenteredAtPresentation
                }, relativeSizeScaleFactor);
            }

            if (model.Template.Id == PortraitPicturePresentingPictureSlideSecuenceTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<PortraitPicturePresentingPictureSlideSecuencePlacardContextModel>(model.SerializedContext);

                return new PortraitPicturePresentingPictureSlideSecuencePlacardView(new Models.View.PortraitPicturePresentingPictureSlideSecuencePlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    PresenterSource = Xamarin.Forms.ImageSource.FromUri(ImageUriFactory.BuildImageUri(context.PresenterImage.Id)),
                    PresenterSide = context.PresenterSide,
                    PresenterImageWidth = context.PresenterImage.Width,
                    PresenterImageHeigth = context.PresenterImage.Height,
                    PresentedPictureSlideSecuence = context.PresentedPictureSlideSecuence,
                    PresentedPictureSlideSecuenceCenteredAtPresentation = context.PresentedPictureSlideSecuenceCenteredAtPresentation
                }, relativeSizeScaleFactor);
            }

            return null;
        }
    }
}
