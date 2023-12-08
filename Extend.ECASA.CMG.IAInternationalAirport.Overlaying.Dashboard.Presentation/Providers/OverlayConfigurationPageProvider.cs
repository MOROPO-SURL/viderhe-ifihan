namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Overlaying.Dashboard.Presentation.Providers
{
    public class OverlayConfigurationPageProvider : Common.Overlaying.Dashboard.Presentation.Providers.Facade.IOverlayConfigurationPageProviderFacade
    {
        public Xamarin.Forms.Page GetConfigurationPageByDescriptor(Common.Overlaying.Descriptors.IOverlayDescriptor overlayDescriptor, string serializedContext, System.Action<string> successfulCompleteCallbackAction)
        {
            if (overlayDescriptor.Id == Descriptors.DinamicAirportCheckInMonitorOverlayDescriptor.ID)
            {
                return new Pages.DinamicAirportCheckInMonitorOverlayConfigurationPage(serializedContext, successfulCompleteCallbackAction);
            }

            return null;
        }
    }
}
