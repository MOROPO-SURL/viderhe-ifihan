namespace MOROPO.VIDERHE.Support.Presentation.Factories
{
    public static class SoundUriFactory
    {
        public static System.Uri BuildUri(System.Guid id, string extension)
        {
            var concreteExtension = extension;

            if (concreteExtension.StartsWith("."))
            {
                concreteExtension = concreteExtension.Substring(1);
            }

            return new System.Uri(string.Format("http://{0}:5080/oflaDemo/{1}.{2}", Xamarin.Forms.DependencyService.Get<Providers.Facade.ICloudServerProviderFacade>().Host.Split(':')[0], id, concreteExtension.ToLowerInvariant()));
        }
    }
}
