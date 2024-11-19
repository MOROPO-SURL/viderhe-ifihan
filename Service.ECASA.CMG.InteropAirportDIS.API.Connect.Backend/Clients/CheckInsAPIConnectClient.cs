namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Connect.Backend.Clients
{
    public class CheckInsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.AbstractEntityManagementApiConnectClient<Persistence.Entities.CheckIn, System.Guid, Common.Models.CheckInInputModel, Common.Models.CheckInDisplayModel>
    {
        public CheckInsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "backend/checkins";

        public async System.Threading.Tasks.Task ReplaceAsync(Common.Models.CheckInInputModel[] models)
        {
            await httpClientHelperProvider.HttpClientHelper.PutAsync(string.Format("{0}/replace", TargetController), models);
        }
    }
}
