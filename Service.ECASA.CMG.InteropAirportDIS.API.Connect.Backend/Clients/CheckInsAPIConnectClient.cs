namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Connect.Backend.Clients
{
    public class CheckInsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.AbstractEntityManagementApiConnectClient<Persistence.Entities.CheckIn, int, Common.Models.CheckInInputModel, Common.Models.CheckInDisplayModel>
    {
        public CheckInsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "backend/checkins";
    }
}
