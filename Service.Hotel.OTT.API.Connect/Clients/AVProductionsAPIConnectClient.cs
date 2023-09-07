namespace MOROPO.VIDERHE.Service.Hotel.OTT.API.Connect.Clients
{
    public class AVProductionsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.AbstractEntityManagementApiConnectClient<Persistence.Entities.AVProduction, System.Guid, Common.Models.AVProductionInputModel, Common.Models.AVProductionDisplayModel>
    {
        public AVProductionsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "backend/avproductions";
    }
}
