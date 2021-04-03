namespace SmartSolucionesCuba.Viderhe.Extend.CPCC.Overlaying.Presentation.Providers
{
    public class OverlayPresentationViewProvider : Common.Overlaying.Presentation.Providers.Facade.IOverlayPresentationViewProviderFacade
    {
        public Common.Overlaying.Presentation.Views.BaseOverlayView GetFor(Common.Presentation.Providers.Facade.IAccountInformationProviderFacade accountInformationProvider)
        {
            if (accountInformationProvider.AccountDefaultOverlayId.Value == Descriptors.AdvicesMarqueeOverlayDescriptor.ID)
            {
                return new Views.AdvicesMarqueeOverlayView(Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.AdvicesMarqueeOverlayContextModel>(accountInformationProvider.AccountSerializedOverlayContext));
            }

            if (accountInformationProvider.AccountDefaultOverlayId.Value == Descriptors.NMTourOverlayDescriptor.ID)
            {
                return new Views.NMTourOverlayView(Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.NMTourOverlayContextModel>(accountInformationProvider.AccountSerializedOverlayContext));
            }

            return null;
        }
    }
}
