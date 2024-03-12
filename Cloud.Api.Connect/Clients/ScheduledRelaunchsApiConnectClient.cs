using MOROPO.VIDERHE.Cloud.Api.Common.Models;
using MOROPO.VIDERHE.Cloud.Api.Common.Models.Filter;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Api.Connect.Clients
{
    public class ScheduledRelaunchsApiConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.AbstractEntityManagementFilteredApiConnectClient<ScheduledRelaunch, System.Guid, ScheduledRelaunchInputModel, ScheduledRelaunchDisplayModel, ScheduledRelaunchFilterModel>
    {
        public ScheduledRelaunchsApiConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "account/scheduledrelaunchs";
    }
}
