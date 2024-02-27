using MOROPO.VIDERHE.Cloud.Api.Common.Models;
using MOROPO.VIDERHE.Cloud.Api.Common.Models.Filter;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Api.Connect.Clients
{
    public class FramesApiConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.AbstractEntityManagementFilteredApiConnectClient<Frame, long, FrameInputModel, FrameDisplayModel, FrameFilterModel>
    {
        public FramesApiConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        public async System.Threading.Tasks.Task OrderAsync(long id, int priority)
        {
            await httpClientHelperProvider.HttpClientHelper.PutAsync(string.Format("{0}/{1}/order/{2}", TargetController, id, priority));
        }

        protected override string TargetController => "account/frames";
    }
}
