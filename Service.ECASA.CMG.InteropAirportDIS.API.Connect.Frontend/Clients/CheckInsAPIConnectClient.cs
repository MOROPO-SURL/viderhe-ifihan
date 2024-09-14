using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.Filter;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Entities;

namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Connect.Frontend.Clients
{
    public class CheckInsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.AbstractEntityConsultFilteredApiConnectClient<CheckIn, int, CheckInDisplayModel, CheckInFilterModel>
    {
        public CheckInsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "frontend/checkins";
    }
}
