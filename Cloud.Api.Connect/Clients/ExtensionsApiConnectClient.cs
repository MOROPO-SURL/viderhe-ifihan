using MOROPO.VIDERHE.Cloud.Api.Common.Models;

namespace MOROPO.VIDERHE.Cloud.Api.Connect.Clients
{
    public class ExtensionsApiConnectClient
    {
        private readonly Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper httpClientHelper;

        public ExtensionsApiConnectClient(Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper httpClientHelper)
        {
            this.httpClientHelper = httpClientHelper;
        }

        public async System.Threading.Tasks.Task<ExtensionBundleModuleModel[]> GetDashboardBundleModulesAsync(System.Guid id)
        {
            return await httpClientHelper.GetAsync<ExtensionBundleModuleModel[]>(string.Format("account/extensions/{0}/dashboard/bundle/modules", id));
        }

        public async System.Threading.Tasks.Task<ExtensionBundleModuleModel[]> GetPlayerBundleModulesAsync(System.Guid id)
        {
            return await httpClientHelper.GetAsync<ExtensionBundleModuleModel[]>(string.Format("account/extensions/{0}/player/bundle/modules", id));
        }
    }
}
