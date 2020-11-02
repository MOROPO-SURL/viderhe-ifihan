namespace SmartSolucionesCuba.Videre.Extend.Common.Templating.Dashboard.Presentation.Providers.Facade
{
    public interface IPlacardThumbnailViewProviderFacade
    {
        Xamarin.Forms.ContentView GetPlacardThumnailView(Support.Presentation.Models.View.PlacardViewModel model, Support.Presentation.Providers.Facade.ICloudServerProviderFacade cloudServerProvider);
    }
}
