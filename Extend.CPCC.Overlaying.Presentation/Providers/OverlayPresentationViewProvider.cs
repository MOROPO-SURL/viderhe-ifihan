using MOROPO.VIDERHE.Extend.CPCC.Overlaying.Descriptors;
using MOROPO.VIDERHE.Extend.CPCC.Overlaying.Presentation.Models.Context;

namespace MOROPO.VIDERHE.Extend.CPCC.Overlaying.Presentation.Providers
{
    public class OverlayPresentationViewProvider : Common.Overlaying.Presentation.Providers.Facade.IOverlayPresentationViewProviderFacade
    {
        public Common.Overlaying.Presentation.Views.BaseOverlayView Get()
        {
            var accountInformationProvider = Xamarin.Forms.DependencyService.Get<Common.Presentation.Providers.Facade.IAccountInformationProviderFacade>();

            if (accountInformationProvider.AccountDefaultOverlayId.Value == AdvicesMarqueeOverlayDescriptor.ID)
            {
                return new Views.AdvicesMarqueeOverlayView(Newtonsoft.Json.JsonConvert.DeserializeObject<AdvicesMarqueeOverlayContextModel>(accountInformationProvider.AccountSerializedOverlayContext));
            }

            if (accountInformationProvider.AccountDefaultOverlayId.Value == NMTourOverlayDescriptor.ID)
            {
                return new Views.NMTourOverlayView(Newtonsoft.Json.JsonConvert.DeserializeObject<NMTourOverlayContextModel>(accountInformationProvider.AccountSerializedOverlayContext));
            }

            return null;
        }
    }
}
