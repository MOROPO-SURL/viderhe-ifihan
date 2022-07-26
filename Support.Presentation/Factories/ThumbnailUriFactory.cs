namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Factories
{
    public static class ThumbnailUriFactory
    {
        public static System.Uri BuildThumbnailUri(System.Guid thumbnailId)
        {
            var cloudServerProvider = Xamarin.Forms.DependencyService.Get<Providers.Facade.ICloudServerProviderFacade>();

            return new System.Uri(string.Format("{0}://{1}/media/default/thumbnail/{2}", cloudServerProvider.UseSSL ? "https" : "http", cloudServerProvider.Host, thumbnailId));
        }
    }
}
