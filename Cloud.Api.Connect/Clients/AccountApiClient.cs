namespace SmartSolucionesCuba.Viderhe.Cloud.Api.Connect.Clients
{
    public class AccountApiClient : SAPRESSC.Core.Api.Connect.Clients.AbstractEntityApiManagementClient<Persistence.Entities.Account, System.Guid, Common.Models.AccountInputModel, Common.Models.AccountDisplayModel>
    {
        public AccountApiClient(SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "business/account";

        public async System.Threading.Tasks.Task<Common.Models.AccountDisplayModel> GetCurrentAsync()
        {
            return await httpClientHelperProvider.HttpClientHelper.GetAsync<Common.Models.AccountDisplayModel>(string.Format("{0}/current", TargetController));
        }
    }
}
