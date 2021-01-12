namespace SmartSolucionesCuba.Videre.Extend.CPCC.Overlaying.Dashboard.Presentation.Providers
{
    public sealed class OverlayDefaultSerializedContextProvider : Common.Overlaying.Dashboard.Presentation.Providers.Facade.IOverlayDefaultSerializedContextProviderFacade
    {
        public string GetOverlayDefaultSerializedContext(Common.Overlaying.Descriptors.IOverlayDescriptor descriptor, Common.Presentation.Providers.Facade.IAccountInformationProviderFacade accountInformationProvider)
        {
            if (descriptor.Id == Descriptors.AdvicesMarqueeOverlayDescriptor.ID)
            {
                var model = new Overlaying.Presentation.Models.Context.AdvicesMarqueeOverlayContextModel
                {
                    ServerName = "sgc.elcallejon.net",
                    IsSecureServer = false,
                    Tail = accountInformationProvider.Name,
                    AdviseSeparator = "|"
                };

                return Newtonsoft.Json.JsonConvert.SerializeObject(model);
            }

            return null;
        }
    }
}
