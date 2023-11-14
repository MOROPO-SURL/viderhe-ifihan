namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Connect.Backend.Clients
{
    public class OperationsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.AbstractEntityManagementApiConnectClient<Persistence.Entities.Operation, long, Common.Models.OperationInputModel, Common.Models.OperationDisplayModel>
    {
        public OperationsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "backend/operations";
    }
}
