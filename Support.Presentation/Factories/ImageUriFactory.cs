namespace SmartSolucionesCuba.Videre.Support.Presentation.Factories
{
    public static class ImageUriFactory
    {
        public static System.Uri BuildImageUri(Providers.Facade.ICloudServerProviderFacade cloudServerProvider, System.Guid imageId)
        {
            return new System.Uri(string.Format("http://{0}/media/default/image/{1}", cloudServerProvider.CloudServerHost, imageId));
        }
    }
}
