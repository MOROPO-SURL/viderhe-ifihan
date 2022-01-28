using SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Descriptors;
using SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Presentation.Models.Context;
using SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Presentation.Views;

namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Presentation.Providers
{
    public class PlacardPresentationViewProvider : Common.Templating.Presentation.Providers.Facade.IPlacardPresentationViewProviderFacade
    {
        public Common.Presentation.Views.BasePlacardPresentationView GetFor(Support.Presentation.Models.View.PlacardViewModel model, Common.Presentation.Providers.Facade.IAccountInformationProviderFacade accountInformationProvider, Support.Presentation.Providers.Facade.ICloudServerProviderFacade cloudServerProvider)
        {
            if (model.Template.Id == InfinityVideoTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<InfinityVideoPlacardContextModel>(model.SerializedContext);

                return new InfinityVideoPlacardView(new Models.View.InfinityVideoPlacardViewModel
                {
                    RequireUnobstructedPresetation = false,
                    VideoSource = XFToolKit.Presentation.Sources.Video.VideoSource.FromUri(Support.Presentation.Factories.VideoUriFactory.BuildVideoUri(cloudServerProvider, context.VideoId, context.VideoExtension).AbsoluteUri),
                    VideoThumbnailImageSource = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildThumbnailUri(cloudServerProvider, context.ThumbnailId))
                });
            }

            if (model.Template.Id == CornerTileVideoPresentingVideoTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<CornerTileVideoPresentingVideoPlacardContextModel>(model.SerializedContext);

                return new CornerTileVideoPresentingVideoPlacardView(new Models.View.CornerTileVideoPresentingVideoPlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    PresenterTileVideoSource = XFToolKit.Presentation.Sources.Video.VideoSource.FromUri(Support.Presentation.Factories.VideoUriFactory.BuildVideoUri(cloudServerProvider, context.PresenterTileVideo.Id, context.PresenterTileVideo.Extension).AbsoluteUri),
                    PresenterTileVideoPlayDelay = context.PresenterTileVideoPlayDelay,
                    PresenterTileVideoScreenCorner = context.PresenterTileVideoScreenCorner,
                    PresentedVideoSource = XFToolKit.Presentation.Sources.Video.VideoSource.FromUri(Support.Presentation.Factories.VideoUriFactory.BuildVideoUri(cloudServerProvider, context.PresentedVideo.Id, context.PresentedVideo.Extension).AbsoluteUri)
                });
            }

            if (model.Template.Id == LandscapeCrossStripeTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<LandscapeCrossStripePlacardContextModel>(model.SerializedContext);

                var viewModel = new Models.View.LandscapeCrossStripePlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    ContextedImageSource = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(cloudServerProvider, context.ContextedImage.Id)),
                    ContextedImageZoomingEnabled = context.ContextedImageZoomingEnabled,
                    StripeBackgroundColor = context.StripeColorBackgroundMode == Enumerations.BackgroundColorMode.Primary ? accountInformationProvider.PrimaryColor : accountInformationProvider.SecoundaryColor,
                    Header = context.Header,
                    HeaderFontSize = context.HeaderFontSize,
                    Content = context.Content,
                    ContentFontSize = context.ContentFontSize
                };

                if (context.IsStripeBackgroundTranslucent)
                {
                    viewModel.StripeBackgroundColor = viewModel.StripeBackgroundColor.MultiplyAlpha(0.85);
                }

                return new LandscapeCrossStripePlacardView(viewModel);
            }

            if (model.Template.Id == LandscapeFramedTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<LandscapeFramedPlacardContextModel>(model.SerializedContext);

                return new LandscapeFramedPlacardView(new Models.View.LandscapeFramedPlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    Header = context.Header,
                    HeaderFontSize = context.HeaderFontSize,
                    Content = context.Content,
                    ContentFontSize = context.ContentFontSize,
                    FrameStyle = context.FrameStyle,
                    BackgroundMode = context.BackgroundMode
                });
            }

            if (model.Template.Id == LandscapePennantTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<LandscapePennantPlacardContextModel>(model.SerializedContext);

                return new LandscapePennantPlacardView(new Models.View.LandscapePennantPlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    Header = context.Header,
                    HeaderFontSize = context.HeaderFontSize,
                    Content = context.Content,
                    ContentFontSize = context.ContentFontSize,
                    ContextedImageSource = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(cloudServerProvider, context.ContextedImage.Id)),
                    ContextedImageZoomingEnabled = context.ContextedImageZoomingEnabled,
                    FlyoutShapeKind = context.FlyoutShapeKind,
                    FlyoutBackgroundColorMode = context.FlyoutBackgroundColorMode,
                    PennantVerticalOrientation = context.PennantVerticalOrientation
                });
            }

            return null;
        }
    }
}
