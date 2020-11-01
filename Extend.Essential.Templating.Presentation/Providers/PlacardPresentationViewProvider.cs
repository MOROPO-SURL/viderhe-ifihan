using SmartSolucionesCuba.Videre.Extend.Essential.Templating.Descriptors;
using SmartSolucionesCuba.Videre.Extend.Essential.Templating.Presentation.Models.Context;
using SmartSolucionesCuba.Videre.Extend.Essential.Templating.Presentation.Views;

namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Presentation.Providers
{
    public class PlacardPresentationViewProvider : Common.Templating.Presentation.Providers.Facade.IPlacardPresentationViewProviderFacade
    {
        public Common.Presentation.Views.BasePlacardPresentationView GetFor(Support.Presentation.Models.View.PlacardViewModel model, Common.Presentation.Providers.Facade.IAccountInformationProviderFacade accountInformationProvider, Support.Presentation.Providers.Facade.ICloudServerProviderFacade cloudServerProvider)
        {
            if (model.Template.Id == PictureSecuenceTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<PictureSecuencePlacardContextModel>(model.SerializedContext);

                return new PictureSecuencePlacardView(context, cloudServerProvider, accountInformationProvider, XFToolKit.IoC.TinyIoCContainer.Current.Resolve<Common.Motion.Presentation.Providers.Facade.IMotionTransitionProviderFacade>());
            }

            if (model.Template.Id == SimpleVideoTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<SimpleVideoPlacardContextModel>(model.SerializedContext);

                return new SimpleVideoPlacardView(new Models.View.SimpleVideoPlacardViewModel
                {
                    RequireUnobstructedPresetation = false,
                    VideoSource = XFToolKit.Presentation.Sources.Video.VideoSource.FromUri(Support.Presentation.Factories.VideoUriFactory.BuildVideoUri(cloudServerProvider, context.VideoId, context.VideoExtension).AbsoluteUri)
                }, accountInformationProvider);
            }

            if (model.Template.Id == SimplePictureTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<SimplePicturePlacardContextModel>(model.SerializedContext);

                return new SimplePicturePlacardView(new Models.View.SimplePicturePlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    Source = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(cloudServerProvider, context.Image.Id)),
                    Aspect = context.Aspect
                });
            }

            if (model.Template.Id == ResponsivePictureTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponsivePicturePlacardContextModel>(model.SerializedContext);

                return new ResponsivePicturePlacardView(new Models.View.ResponsivePicturePlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    Source = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(cloudServerProvider, context.Image.Id))
                }, accountInformationProvider);
            }

            if (model.Template.Id == PicturePresentingPictureLandscapeTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<PicturePresentingPictureLandscapePlacardContextModel>(model.SerializedContext);

                return new PicturePresentingPictureLandscapePlacardView(new Models.View.PicturePresentingPictureLandscapePlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    PresenterSource = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(cloudServerProvider, context.PresenterImage.Id)),
                    PresenterImageWidth = context.PresenterImage.Width,
                    PresenterImageHeigth = context.PresenterImage.Height,
                    PresentedSource = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(cloudServerProvider, context.PresentedImage.Id)),
                    PresentedImageCenteredAtPresentation = context.PresentedImageCenteredAtPresentation,
                    PresentedImageZoomingEnabled = context.PresentedImageZoomingEnabled,
                    PresenterSide = context.PresenterSide
                });
            }

            return null;
        }
    }
}
