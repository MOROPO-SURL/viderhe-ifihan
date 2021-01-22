namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Factories
{
    public static class ThumbnailUriFactory
    {
        public static System.Uri BuildThumbnailUri(Providers.Facade.ICloudServerProviderFacade cloudServerProvider, System.Guid thumbnailId)
        {
            return new System.Uri(string.Format("http://{0}/media/default/thumbnail/{1}", cloudServerProvider.CloudServerHost, thumbnailId));
        }
    }
}
