namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Overlaying.Presentation.Providers
{
    public class OverlayPresentationViewProvider : Common.Overlaying.Presentation.Providers.Facade.IOverlayPresentationViewProviderFacade
    {
        public Common.Overlaying.Presentation.Views.BaseOverlayView Get()
        {
            var accountInformationProvider = Xamarin.Forms.DependencyService.Get<Common.Presentation.Providers.Facade.IAccountInformationProviderFacade>();

            if (accountInformationProvider.AccountDefaultOverlayId.Value == Descriptors.DinamicAirportCheckInMonitorOverlayDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.DinamicAirportCheckInMonitorOverlayContextModel>(accountInformationProvider.AccountSerializedOverlayContext);

                return new Views.DinamicAirportCheckInMonitorOverlayView(context);
            }

            return null;
        }
    }
}
