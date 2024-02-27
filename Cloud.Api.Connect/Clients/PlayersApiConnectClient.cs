using MOROPO.VIDERHE.Cloud.Api.Common.Models;
using MOROPO.VIDERHE.Cloud.Api.Common.Models.Filter;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Api.Connect.Clients
{
    public class PlayersApiConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.AbstractEntityManagementFilteredApiConnectClient<Player, string, PlayerInputModel, PlayerDisplayModel, PlayerFilterModel>
    {
        public PlayersApiConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "account/players";

        public async System.Threading.Tasks.Task<AccountDisplayModel> GetAccountAsync()
        {
            return await httpClientHelperProvider.HttpClientHelper.GetAsync<AccountDisplayModel>(string.Format("{0}/owner", TargetController));
        }

        public async System.Threading.Tasks.Task<PlayerPlaybackConfigurationModel> GetPlaybackConfigurationAsync()
        {
            return await httpClientHelperProvider.HttpClientHelper.GetAsync<PlayerPlaybackConfigurationModel>(string.Format("{0}/playbackconfiguration", TargetController));
        }
    }
}
