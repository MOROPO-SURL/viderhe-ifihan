namespace SmartSolucionesCuba.Videre.Support.Presentation.Factories
{
    public static class VideoUriFactory
    {
        public static System.Uri BuildVideoUri(Providers.Facade.ICloudServerProviderFacade cloudServerProvider, System.Guid videoId, string videoExtension)
        {
            var concreteExtension = videoExtension;

            if (concreteExtension.StartsWith("."))
            {
                concreteExtension = concreteExtension.Substring(1);
            }

            return new System.Uri(string.Format("rtmp://{0}/vod/{1}.{2}", cloudServerProvider.CloudServerHost.Split(':')[0], videoId, concreteExtension.ToLowerInvariant()));
        }
    }
}
