namespace SmartSolucionesCuba.Viderhe.Cloud.Api.Connect.Clients
{
    public class FramesApiConnectClient : SAPRESSC.Core.Api.Connect.Clients.AbstractEntityApiManagementFilteredClient<Persistence.Entities.Frame, long, Common.Models.FrameInputModel, Common.Models.FrameDisplayModel, Common.Models.Filter.FrameFilterModel>
    {
        public FramesApiConnectClient(SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        public async System.Threading.Tasks.Task OrderUpAsync(long id)
        {
            await httpClientHelperProvider.HttpClientHelper.PutAsync(string.Format("{0}/orderup/{1}", TargetController, id));
        }

        public async System.Threading.Tasks.Task OrderDownAsync(long id)
        {
            await httpClientHelperProvider.HttpClientHelper.PutAsync(string.Format("{0}/orderdown/{1}", TargetController, id));
        }

        protected override string TargetController => "business/frames";
    }
}
