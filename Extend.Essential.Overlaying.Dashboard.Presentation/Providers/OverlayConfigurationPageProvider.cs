using MOROPO.VIDERHE.Extend.Common.Overlaying.Dashboard.Presentation.Providers.Facade;

namespace MOROPO.VIDERHE.Extend.Essential.Overlaying.Dashboard.Presentation.Providers
{
    public class OverlayConfigurationPageProvider : IOverlayConfigurationPageProviderFacade
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
