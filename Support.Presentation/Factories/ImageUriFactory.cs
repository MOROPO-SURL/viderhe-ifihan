using MOROPO.VIDERHE.Support.Presentation.Helpers;
using MOROPO.VIDERHE.Support.Presentation.Providers.Facade;

namespace MOROPO.VIDERHE.Support.Presentation.Factories
{
    public static class ImageUriFactory
    {
        public static System.Uri BuildImageUri(System.Guid imageId, bool original = false)
        {
            return new System.Uri(ImageUriFactoryHelper.Instance.BuildImageUrl(Xamarin.Forms.DependencyService.Get<ICloudServerProviderFacade>(), imageId, original));
        }

        public static System.Uri BuildLogoUri()
        {
            var cloudServerProvider = Xamarin.Forms.DependencyService.Get<ICloudServerProviderFacade>();

            return new System.Uri(string.Format("{0}://{1}/media/logo", cloudServerProvider.UseSSL ? "https" : "http", cloudServerProvider.Host));
        }

        public static System.Uri BuildSplashVerticalUri(bool original = false)
        {
            return new System.Uri(ImageUriFactoryHelper.Instance.BuildSplashVerticalUri(Xamarin.Forms.DependencyService.Get<ICloudServerProviderFacade>(), original));
        }

        public static System.Uri BuildSplashHorizontalUri(bool original = false)
        {
            return new System.Uri(ImageUriFactoryHelper.Instance.BuildSplashHorizontalUri(Xamarin.Forms.DependencyService.Get<ICloudServerProviderFacade>(), original));
        }
    }
}
