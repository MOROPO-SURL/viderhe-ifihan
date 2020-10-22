namespace SmartSolucionesCuba.Videre.Cloud.Api.Connect.Clients
{
    public class PlayersApiClient : SAPRESSC.Core.Api.Connect.Clients.AbstractEntityApiManagementClient<Persistence.Entities.Player, string, Common.Models.PlayerInputModel, Common.Models.PlayerDisplayModel>
    {
        public PlayersApiClient(SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "business/players";

        public async System.Threading.Tasks.Task<Common.Models.AccountDisplayModel> GetAccountAsync()
        {
            return await httpClientHelperProvider.HttpClientHelper.GetAsync<Common.Models.AccountDisplayModel>(string.Format("{0}/account", TargetController));
        }

        public async System.Threading.Tasks.Task<Common.Models.PlacardDisplayModel[]> GetScreenplayPlacardsAsync()
        {
            return await httpClientHelperProvider.HttpClientHelper.GetAsync<Common.Models.PlacardDisplayModel[]>(string.Format("{0}/screenplayplacards", TargetController));
        }
    }
}
