using MOROPO.VIDERHE.Extend.Hotel.OTT.Overlaying.Descriptors;

namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Overlaying.Presentation.Providers
{
    public class OverlayPresentationViewProvider : Common.Overlaying.Presentation.Providers.Facade.IOverlayPresentationViewProviderFacade
    {
        public Common.Overlaying.Presentation.Views.BaseOverlayView Get()
        {
            var accountInformationProvider = Xamarin.Forms.DependencyService.Get<Common.Presentation.Providers.Facade.IAccountInformationProviderFacade>();

            if (accountInformationProvider.AccountDefaultOverlayId.Value == AuroraOTTHotelTVOverlayDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.OTTHotelTVOverlayContextModel>(accountInformationProvider.AccountSerializedOverlayContext);

                return new Views.AuroraOTTHotelTVOverlayView(new Models.View.AuroraOTTHotelTVOverlayViewModel { Context = context });
            }

            return null;
        }
    }
}