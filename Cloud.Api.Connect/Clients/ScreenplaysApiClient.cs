namespace SmartSolucionesCuba.Videre.Cloud.Api.Connect.Clients
{
    public class ScreenplaysApiClient : SAPRESSC.Core.Api.Connect.Clients.AbstractEntityApiManagementClient<Persistence.Entities.Screenplay, System.Guid, Common.Models.ScreenplayInputModel, Common.Models.ScreenplayDisplayModel>
    {
        public ScreenplaysApiClient(SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "business/screenplays";
    }
}
