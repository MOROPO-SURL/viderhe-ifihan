namespace MOROPO.VIDERHE.Service.Hotel.OTT.API.Connect.Clients
{
    public class AVProducerHousesAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.AbstractEntityManagementApiConnectClient<Persistence.Entities.AVProducerHouse, System.Guid, Common.Models.AVProducerHouseInputModel, Common.Models.AVProducerHouseDisplayModel>
    {
        public AVProducerHousesAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "backend/avproducerhouses";
    }
}
