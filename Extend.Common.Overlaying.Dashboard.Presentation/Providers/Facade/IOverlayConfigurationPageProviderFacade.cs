namespace MOROPO.VIDERHE.Extend.Common.Overlaying.Dashboard.Presentation.Providers.Facade
{
    public interface IOverlayConfigurationPageProviderFacade
    {
        Xamarin.Forms.Page GetConfigurationPageByDescriptor(Descriptors.IOverlayDescriptor overlayDescriptor, string serializedContext, System.Action<string> successfulCompleteCallbackAction);
    }
}
