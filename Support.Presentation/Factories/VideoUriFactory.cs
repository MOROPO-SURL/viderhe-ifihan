namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Factories
{
    public static class VideoUriFactory
    {
        public static System.Uri BuildVideoUri(System.Guid videoId, string videoExtension)
        {
            var concreteExtension = videoExtension;

            if (concreteExtension.StartsWith("."))
            {
                concreteExtension = concreteExtension.Substring(1);
            }

            return new System.Uri(string.Format("rtmp://{0}/vod/{1}.{2}", Xamarin.Forms.DependencyService.Get<Providers.Facade.ICloudServerProviderFacade>().Host.Split(':')[0], videoId, concreteExtension.ToLowerInvariant()));
        }
    }
}
