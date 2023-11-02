namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Connect.Clients
{
    public class TerminalsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.AbstractEntityManagementApiConnectClient<Persistence.Entities.Terminal, System.Guid, Common.Models.TerminalInputModel, Common.Models.TerminalDisplayModel>
    {
        public TerminalsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "backend/terminals";
    }
}
