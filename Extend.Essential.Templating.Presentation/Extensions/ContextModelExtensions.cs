using SmartSolucionesCuba.Videre.Extend.Essential.Templating.Presentation.Models.View;

namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Presentation.Extensions
{
    public static class ContextModelExtensions
    {
        public static SimplePicturePlacardViewModel ToViewModel(this Models.Context.SimplePicturePlacardContextModel target, Support.Presentation.Providers.Facade.ICloudServerProviderFacade cloudServerProvider)
        {
            return new SimplePicturePlacardViewModel
            {
                RequireUnobstructedPresetation = target.RequireUnobstructedPresetation,
                ScreenPresentationTime = target.ScreenPresentationTime,
                Source = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(cloudServerProvider, target.Image.Id)),
                Aspect = target.Aspect
            };
        }

        public static PhotoEventPlacardViewModel ToViewModel(this Models.Context.PhotoEventPlacardContextModel target, Support.Presentation.Providers.Facade.ICloudServerProviderFacade cloudServerProvider)
        {
            return new PhotoEventPlacardViewModel
            {
                RequireUnobstructedPresetation = target.RequireUnobstructedPresetation,
                ScreenPresentationTime = target.ScreenPresentationTime,
                Title = target.Title,
                When = target.When,
                Where = target.Where,
                About = target.About,
                ImageId = target.Image.Id,
                ImageHeight = target.Image.Height,
                ImageWidth = target.Image.Width,
                ImageSource = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(cloudServerProvider, target.Image.Id)),
                ImageAspect = target.ImageAspect,
                ImageZoomingEnabled = target.ImageZoomingEnabled
            };
        }
    }
}
