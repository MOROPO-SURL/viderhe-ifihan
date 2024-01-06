using MOROPO.VIDERHE.Cloud.Api.Common.Models;

namespace MOROPO.VIDERHE.Cloud.Api.Connect.Clients
{
    public class ComplementationsApiConnectClient
    {
        private readonly Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper httpClientHelper;

        public ComplementationsApiConnectClient(Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper httpClientHelper)
        {
            this.httpClientHelper = httpClientHelper;
        }

        public virtual async System.Threading.Tasks.Task EditAsync(ComplementationInputModel model)
        {
            await httpClientHelper.PutAsync("account/complementations", model);
        }
    }
}
