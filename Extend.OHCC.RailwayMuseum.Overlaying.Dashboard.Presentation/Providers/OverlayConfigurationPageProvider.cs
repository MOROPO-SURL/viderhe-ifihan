namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Overlaying.Dashboard.Presentation.Providers
{
    public class OverlayConfigurationPageProvider : Common.Overlaying.Dashboard.Presentation.Providers.Facade.IOverlayConfigurationPageProviderFacade
    {
        public Xamarin.Forms.Page GetConfigurationPageByDescriptor(Common.Overlaying.Descriptors.IOverlayDescriptor overlayDescriptor, string serializedContext, System.Action<string> successfulCompleteCallbackAction)
        {
            if (overlayDescriptor.Id == Descriptors.WindowsAppLauncherOverlayDescriptor.ID)
            {
                return new Pages.WindowsAppLauncherOverlayConfigurationPage(serializedContext, successfulCompleteCallbackAction);
            }

            return null;
        }
    }
}
