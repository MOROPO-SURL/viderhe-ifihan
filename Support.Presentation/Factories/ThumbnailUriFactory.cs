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

        public static System.Uri BuildLogoThumbnailUri(System.Guid accountId)
        {
            var cloudServerProvider = Xamarin.Forms.DependencyService.Get<Providers.Facade.ICloudServerProviderFacade>();

            return new System.Uri(string.Format("{0}://{1}/media/thumbnail/logo/{2}", cloudServerProvider.UseSSL ? "https" : "http", cloudServerProvider.Host, accountId));
        }

        public static System.Uri BuildSplashVerticalThumbnailUri(System.Guid accountId)
        {
            var cloudServerProvider = Xamarin.Forms.DependencyService.Get<Providers.Facade.ICloudServerProviderFacade>();

            return new System.Uri(string.Format("{0}://{1}/media/thumbnail/splash/vertical/{2}", cloudServerProvider.UseSSL ? "https" : "http", cloudServerProvider.Host, accountId));
        }

        public static System.Uri BuildSplashHorizontalThumbnailUri(System.Guid accountId)
        {
            var cloudServerProvider = Xamarin.Forms.DependencyService.Get<Providers.Facade.ICloudServerProviderFacade>();

            return new System.Uri(string.Format("{0}://{1}/media/thumbnail/splash/horizontal/{2}", cloudServerProvider.UseSSL ? "https" : "http", cloudServerProvider.Host, accountId));
        }
    }
}
