namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Overlaying.Dashboard.Presentation.Providers
{
    public class OverlayConfigurationPageProvider : Common.Overlaying.Dashboard.Presentation.Providers.Facade.IOverlayConfigurationPageProviderFacade
    {
        public Xamarin.Forms.Page GetConfigurationPageByDescriptor(Common.Overlaying.Descriptors.IOverlayDescriptor overlayDescriptor, string serializedContext, System.Action<string> successfulCompleteCallbackAction)
        {
            if (overlayDescriptor.Id == Descriptors.SimpleHighlightsOverlayDescriptor.ID)
            {
                return new Pages.SimpleHighlightsOverlayConfigurationPage(serializedContext, successfulCompleteCallbackAction);
            }

            return null;
        }
    }
}
