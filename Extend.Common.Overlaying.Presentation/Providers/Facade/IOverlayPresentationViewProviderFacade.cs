namespace SmartSolucionesCuba.Videre.Extend.Common.Overlaying.Presentation.Providers.Facade
{
    public interface IOverlayPresentationViewProviderFacade
    {
        Views.BaseOverlayView GetFor(Common.Presentation.Providers.Facade.IAccountInformationProviderFacade accountInformationProvider);
    }
}
