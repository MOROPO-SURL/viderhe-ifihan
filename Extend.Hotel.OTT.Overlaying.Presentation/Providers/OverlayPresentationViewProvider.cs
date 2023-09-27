namespace SmartSolucionesCuba.Viderhe.Extend.Hotel.OTT.Overlaying.Presentation.Providers
{
    public class OverlayPresentationViewProvider : Common.Overlaying.Presentation.Providers.Facade.IOverlayPresentationViewProviderFacade
    {
        public Common.Overlaying.Presentation.Views.BaseOverlayView Get()
        {
            var accountInformationProvider = Xamarin.Forms.DependencyService.Get<Common.Presentation.Providers.Facade.IAccountInformationProviderFacade>();

            if (accountInformationProvider.AccountDefaultOverlayId.Value == Descriptors.PionnerOTTHotelTVOverlayDescriptor.ID)
            {
                //var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.SimpleHighlightsContextModel>(accountInformationProvider.AccountSerializedOverlayContext);

                return new Views.PionnerOTTHotelTVOverlayView();
            }

            return null;
        }
    }
}