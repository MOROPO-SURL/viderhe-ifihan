namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Connect.Clients
{
    public class ApiKeysAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.AbstractEntityManagementApiConnectClient<Persistence.Entities.ApiKey, System.Guid, Common.Models.ApiKeyInputModel, Common.Models.ApiKeyDisplayModel>
    {
        public ApiKeysAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "backend/apikeys";
    }
}