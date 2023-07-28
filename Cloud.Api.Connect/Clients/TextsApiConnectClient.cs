namespace SmartSolucionesCuba.Viderhe.Cloud.Api.Connect.Clients
{
    public class TextsApiConnectClient : MOROPO.SAPRESSC.Core.Api.Connect.Clients.AbstractEntityManagementApiConnectClient<Persistence.Entities.Text, System.Guid, Common.Models.TextInputModel, Common.Models.TextDisplayModel>
    {
        public TextsApiConnectClient(MOROPO.SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "account/texts";
    }
}
