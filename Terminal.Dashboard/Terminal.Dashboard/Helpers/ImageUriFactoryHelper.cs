namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Helpers
{
    public class ImageUriFactoryHelper : Support.Presentation.Helpers.Facade.IImageUriFactoryHelper
    {
        public string BuildImageUrl(Support.Presentation.Providers.Facade.ICloudServerProviderFacade cloudServerProvider, System.Guid imageId)
        {

            return string.Format("{0}://{1}/media/default/image/{2}", cloudServerProvider.UseSSL ? "https" : "http", cloudServerProvider.Host, imageId);
        }
    }
}
