namespace MOROPO.VIDERHE.Support.Presentation.Factories
{
    public static class ThumbnailUriFactory
    {
        public static System.Uri BuildImageThumbnailUri(System.Guid thumbnailId)
        {
            var cloudServerProvider = Xamarin.Forms.DependencyService.Get<Providers.Facade.ICloudServerProviderFacade>();

            return new System.Uri(string.Format("{0}://{1}/media/thumbnail/image/{2}", cloudServerProvider.UseSSL ? "https" : "http", cloudServerProvider.Host, thumbnailId));
        }

        public static System.Uri BuildVideoThumbnailUri(System.Guid thumbnailId)
        {
            var cloudServerProvider = Xamarin.Forms.DependencyService.Get<Providers.Facade.ICloudServerProviderFacade>();

            return new System.Uri(string.Format("{0}://{1}/media/thumbnail/video/{2}", cloudServerProvider.UseSSL ? "https" : "http", cloudServerProvider.Host, thumbnailId));
        }

        public static System.Uri BuildLogoThumbnailUri()
        {
            var cloudServerProvider = Xamarin.Forms.DependencyService.Get<Providers.Facade.ICloudServerProviderFacade>();

            return new System.Uri(string.Format("{0}://{1}/media/thumbnail/logo", cloudServerProvider.UseSSL ? "https" : "http", cloudServerProvider.Host));
        }

        public static System.Uri BuildSplashVerticalThumbnailUri()
        {
            var cloudServerProvider = Xamarin.Forms.DependencyService.Get<Providers.Facade.ICloudServerProviderFacade>();

            return new System.Uri(string.Format("{0}://{1}/media/thumbnail/splash/vertical", cloudServerProvider.UseSSL ? "https" : "http", cloudServerProvider.Host));
        }

        public static System.Uri BuildSplashHorizontalThumbnailUri()
        {
            var cloudServerProvider = Xamarin.Forms.DependencyService.Get<Providers.Facade.ICloudServerProviderFacade>();

            return new System.Uri(string.Format("{0}://{1}/media/thumbnail/splash/horizontal/", cloudServerProvider.UseSSL ? "https" : "http", cloudServerProvider.Host));
        }
    }
}
