namespace SmartSolucionesCuba.Videre.Extend.Common.Templating.Presentation.Providers.Facade
{
    public interface IPlacardPresentationViewProviderFacade
    {
        Common.Presentation.Views.BasePlacardPresentationView GetFor(Support.Presentation.Models.View.PlacardViewModel model, Common.Presentation.Providers.Facade.IAccountInformationProviderFacade accountInformationProvider, Support.Presentation.Providers.Facade.ICloudServerProviderFacade cloudServerProvider);
    }
}
