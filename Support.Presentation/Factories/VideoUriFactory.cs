namespace MOROPO.VIDERHE.Support.Presentation.Factories
{
    public static class VideoUriFactory
    {
        public static System.Uri BuildVideoUri(System.Guid videoId, string videoExtension)
        {
            var concreteExtension = videoExtension.ToLowerInvariant();

            if (concreteExtension.StartsWith("."))
            {
                concreteExtension = concreteExtension.Substring(1);
            }

            switch (concreteExtension)
            {
                case "mp4":
                    return new System.Uri($"http://vod.moropo.cu/videos/mp4/{videoId}.mp4");

                case "flv":
                    return new System.Uri($"http://vod.moropo.cu/videos/flv/{videoId}.flv");

                default:
                    return new System.Uri($"http://vod.moropo.cu/videos/{videoId}.{concreteExtension}");
            }

            //return new System.Uri(string.Format("rtmp://{0}/vod/{1}.{2}", Xamarin.Forms.DependencyService.Get<Providers.Facade.ICloudServerProviderFacade>().Host.Split(':')[0], videoId, concreteExtension.ToLowerInvariant()));
        }
    }
}
