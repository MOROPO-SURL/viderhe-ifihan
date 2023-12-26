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

        public static System.Uri BuildLogoThumbnailUri(System.Guid discriminator)
        {
            var cloudServerProvider = Xamarin.Forms.DependencyService.Get<Providers.Facade.ICloudServerProviderFacade>();

            return new System.Uri(string.Format("{0}://{1}/media/thumbnail/logo?nocache={2}", cloudServerProvider.UseSSL ? "https" : "http", cloudServerProvider.Host, discriminator));
        }

        public static System.Uri BuildSplashVerticalThumbnailUri(System.Guid discriminator)
        {
            var cloudServerProvider = Xamarin.Forms.DependencyService.Get<Providers.Facade.ICloudServerProviderFacade>();

            return new System.Uri(string.Format("{0}://{1}/media/thumbnail/splash/vertical?nocache={2}", cloudServerProvider.UseSSL ? "https" : "http", cloudServerProvider.Host, discriminator));
        }

        public static System.Uri BuildSplashHorizontalThumbnailUri(System.Guid discriminator)
        {
            var cloudServerProvider = Xamarin.Forms.DependencyService.Get<Providers.Facade.ICloudServerProviderFacade>();

            return new System.Uri(string.Format("{0}://{1}/media/thumbnail/splash/horizontal?nocache={2}", cloudServerProvider.UseSSL ? "https" : "http", cloudServerProvider.Host, discriminator));
        }
    }
}
