using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.Filter;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Entities;

namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Connect.Frontend.Clients
{
    public class OperationsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.AbstractEntityConsultFilteredApiConnectClient<Operation, long, OperationDisplayModel, OperationFilterModel>
    {
        public OperationsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "frontend/operations";
    }
}
