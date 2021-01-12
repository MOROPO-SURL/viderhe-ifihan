namespace SmartSolucionesCuba.Videre.Extend.CPCC.Overlaying.Presentation.Providers
{
    public class OverlayPresentationViewProvider : Common.Overlaying.Presentation.Providers.Facade.IOverlayPresentationViewProviderFacade
    {
        public Common.Overlaying.Presentation.Views.BaseOverlayView GetFor(Common.Presentation.Providers.Facade.IAccountInformationProviderFacade accountInformationProvider)
        {
            if (accountInformationProvider.AccountDefaultOverlayId.Value == Descriptors.AdvicesMarqueeOverlayDescriptor.ID)
            {
                return new Views.AdvicesMarqueeOverlayView(Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.AdvicesMarqueeOverlayContextModel>(accountInformationProvider.AccountSerializedOverlayContext));
            }

            return null;
        }
    }
}
