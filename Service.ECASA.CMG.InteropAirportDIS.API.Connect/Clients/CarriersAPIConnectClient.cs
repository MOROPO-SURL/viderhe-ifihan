namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Connect.Clients
{
    public class CarriersAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.AbstractEntityManagementApiConnectClient<Persistence.Entities.Carrier, string, Common.Models.CarrierInputModel, Common.Models.CarrierDisplayModel>
    {
        public CarriersAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "backend/carriers";
    }
}
