namespace SmartSolucionesCuba.Viderhe.Terminal.Player.Helpers
{
    public class ImageUriFactoryHelper : Support.Presentation.Helpers.Facade.IImageUriFactoryHelper
    {
        public string BuildImageUrl(Support.Presentation.Providers.Facade.ICloudServerProviderFacade cloudServerProvider, System.Guid imageId)
        {
            return string.Format("{0}://{1}/media/image/{2}/w/{3}/h/{4}", cloudServerProvider.UseSSL ? "https" : "http", cloudServerProvider.Host, imageId, (int)Xamarin.Forms.Application.Current.MainPage.Width, (int)Xamarin.Forms.Application.Current.MainPage.Height);
        }
    }
}
