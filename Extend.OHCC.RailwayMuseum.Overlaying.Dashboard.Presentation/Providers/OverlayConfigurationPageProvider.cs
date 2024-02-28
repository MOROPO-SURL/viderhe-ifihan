namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Overlaying.Dashboard.Presentation.Providers
{
    public class OverlayConfigurationPageProvider : Common.Overlaying.Dashboard.Presentation.Providers.Facade.IOverlayConfigurationPageProviderFacade
    {
        public Xamarin.Forms.Page GetConfigurationPageByDescriptor(Common.Overlaying.Descriptors.IOverlayDescriptor overlayDescriptor, string serializedContext, System.Action<string> successfulCompleteCallbackAction)
        {
            if (overlayDescriptor.Id == Descriptors.WindowsAppLauncherOverlayDescriptor.ID)
            {
                return new Pages.WindowsAppLauncherOverlayConfigurationPage(serializedContext, successfulCompleteCallbackAction);
            }

            if (overlayDescriptor.Id == Descriptors.WindowsAppsLauncherOverlayDescriptor.ID)
            {
                return new Pages.WindowsAppsLauncherOverlayConfigurationPage(serializedContext, successfulCompleteCallbackAction);
            }

            if (overlayDescriptor.Id == Descriptors.InformationMenuOverlayDescriptor.ID)
            {
                return new Pages.InformationMenuOverlayConfigurationPage(serializedContext, successfulCompleteCallbackAction);
            }

            return null;
        }
    }
}
