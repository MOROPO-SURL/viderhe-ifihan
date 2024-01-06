using MOROPO.VIDERHE.Extend.CPCC.Overlaying.Descriptors;

namespace MOROPO.VIDERHE.Extend.CPCC.Overlaying.Dashboard.Presentation.Providers
{
    public sealed class OverlayDefaultSerializedContextProvider : Common.Overlaying.Dashboard.Presentation.Providers.Facade.IOverlayDefaultSerializedContextProviderFacade
    {
        public string GetOverlayDefaultSerializedContext(Common.Overlaying.Descriptors.IOverlayDescriptor descriptor, Common.Presentation.Providers.Facade.IAccountInformationProviderFacade accountInformationProvider)
        {
            if (descriptor.Id == AdvicesMarqueeOverlayDescriptor.ID)
            {
                var model = new Overlaying.Presentation.Models.Context.AdvicesMarqueeOverlayContextModel
                {
                    ServerName = "sgc.elcallejon.net",
                    IsSecureServer = false,
                    Tail = accountInformationProvider.Name,
                    Separator = "|"
                };

                return Newtonsoft.Json.JsonConvert.SerializeObject(model);
            }

            if (descriptor.Id == NMTourOverlayDescriptor.ID)
            {
                var model = new Overlaying.Presentation.Models.Context.NMTourOverlayContextModel
                {
                    ServerName = "sgc.elcallejon.net",
                    IsSecureServer = false,
                    Tail = accountInformationProvider.Name,
                    Separator = "|"
                };

                return Newtonsoft.Json.JsonConvert.SerializeObject(model);
            }

            return null;
        }
    }
}
