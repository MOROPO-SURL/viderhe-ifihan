namespace SmartSolucionesCuba.Viderhe.Cloud.Api.Connect.Clients
{
    public class PlacardsApiClient : SAPRESSC.Core.Api.Connect.Clients.AbstractEntityApiManagementClient<Persistence.Entities.Placard, System.Guid, Common.Models.PlacardInputModel, Common.Models.PlacardDisplayModel>
    {
        public PlacardsApiClient(SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "business/placards";
    }
}
