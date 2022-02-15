namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Factories
{
    public static class ThumbnailUriFactory
    {
        public static System.Uri BuildThumbnailUri(System.Guid thumbnailId)
        {
            return new System.Uri(string.Format("http://{0}/media/default/thumbnail/{1}", Xamarin.Forms.DependencyService.Get<Providers.Facade.ICloudServerProviderFacade>().CloudServerHost, thumbnailId));
        }
    }
}
