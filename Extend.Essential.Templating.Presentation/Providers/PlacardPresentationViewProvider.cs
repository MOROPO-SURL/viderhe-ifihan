using SmartSolucionesCuba.Videre.Extend.Essential.Templating.Descriptors;
using SmartSolucionesCuba.Videre.Extend.Essential.Templating.Presentation.Extensions;
using SmartSolucionesCuba.Videre.Extend.Essential.Templating.Presentation.Models.Context;
using SmartSolucionesCuba.Videre.Extend.Essential.Templating.Presentation.Views;

namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Presentation.Providers
{
    public class PlacardPresentationViewProvider : Common.Templating.Presentation.Providers.Facade.IPlacardPresentationViewProviderFacade
    {
        public Common.Presentation.Views.BasePlacardPresentationView GetFor(Support.Presentation.Models.View.PlacardViewModel model)
        {
            var cloudServerProvider = XFToolKit.IoC.TinyIoCContainer.Current.Resolve<Support.Presentation.Providers.Facade.ICloudServerProviderFacade>();
            var accountInformationProvider = XFToolKit.IoC.TinyIoCContainer.Current.Resolve<Common.Presentation.Providers.Facade.IAccountInformationProviderFacade>();

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

                return new SimplePicturePlacardView(context.ToViewModel(cloudServerProvider));
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

            if (model.Template.Id == FloatLeftDetailedPhotoEventTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<PhotoEventPlacardContextModel>(model.SerializedContext);

                if (context.Image.Width > context.Image.Height)
                {
                    return new FloatLeftDetailedHorizontalPhotoEventPlacardView(context.ToViewModel(cloudServerProvider), accountInformationProvider);
                }
                else
                {
                    return new FloatLeftDetailedVerticalPhotoEventPlacardView(context.ToViewModel(cloudServerProvider), accountInformationProvider);
                }
            }

            return null;
        }
    }
}
