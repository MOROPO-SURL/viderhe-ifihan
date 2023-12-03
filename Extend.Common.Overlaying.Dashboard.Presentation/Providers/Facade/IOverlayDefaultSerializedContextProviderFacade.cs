namespace MOROPO.VIDERHE.Extend.Common.Overlaying.Dashboard.Presentation.Providers.Facade
{
    public interface IOverlayDefaultSerializedContextProviderFacade
    {
        string GetOverlayDefaultSerializedContext(Descriptors.IOverlayDescriptor descriptor, Common.Presentation.Providers.Facade.IAccountInformationProviderFacade accountInformationProvider);
    }
}
