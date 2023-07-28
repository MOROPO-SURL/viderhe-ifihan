namespace SmartSolucionesCuba.Viderhe.Cloud.Api.Connect.Clients
{
    public class GradientsApiConnectClient : MOROPO.SAPRESSC.Core.Api.Connect.Clients.AbstractEntityManagementApiConnectClient<Persistence.Entities.Gradient, System.Guid, Common.Models.GradientInputModel, Common.Models.GradientDisplayModel>
    {
        public GradientsApiConnectClient(MOROPO.SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "account/gradients";
    }
}
