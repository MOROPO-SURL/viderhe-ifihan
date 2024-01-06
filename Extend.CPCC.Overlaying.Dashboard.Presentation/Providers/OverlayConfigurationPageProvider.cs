using MOROPO.VIDERHE.Extend.CPCC.Overlaying.Descriptors;

namespace MOROPO.VIDERHE.Extend.CPCC.Overlaying.Dashboard.Presentation.Providers
{
    public class OverlayConfigurationPageProvider : Common.Overlaying.Dashboard.Presentation.Providers.Facade.IOverlayConfigurationPageProviderFacade
    {
        public Xamarin.Forms.Page GetConfigurationPageByDescriptor(Common.Overlaying.Descriptors.IOverlayDescriptor overlayDescriptor, string serializedContext, System.Action<string> successfulCompleteCallbackAction)
        {
            if (overlayDescriptor.Id == AdvicesMarqueeOverlayDescriptor.ID)
            {
                return new Pages.AdvicesMarqueeOverlayConfigurationPage(serializedContext, successfulCompleteCallbackAction);
            }

            if (overlayDescriptor.Id == NMTourOverlayDescriptor.ID)
            {
                return new Pages.NMTourOverlayConfigurationPage(serializedContext, successfulCompleteCallbackAction);
            }

            return null;
        }
    }
}
