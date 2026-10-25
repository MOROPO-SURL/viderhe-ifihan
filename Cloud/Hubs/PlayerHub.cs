using Microsoft.AspNetCore.SignalR;
using MOROPO.VIDERHE.Cloud.Api.Common.Providers.Constant;
using MOROPO.VIDERHE.Cloud.Providers;
using System.Linq;

namespace MOROPO.VIDERHE.Cloud.Hubs
{
    public class PlayerHub : Hub<SignalR.Connect.Player.Clients.IPlayerClient>, SignalR.Connect.Player.Hubs.IPlayerHub
    {
        private readonly IHubContext<DashboardHub, SignalR.Connect.Dashboard.Clients.IDashboardClient> dashboardHubContext;

        public PlayerHub(IHubContext<DashboardHub, SignalR.Connect.Dashboard.Clients.IDashboardClient> dashboardHubContext)
        {
            this.dashboardHubContext = dashboardHubContext;
        }

        public async override System.Threading.Tasks.Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();

            var accountId = httpContext.Request.Headers[SecurityConstantProvider.ACCOUNT_ID_HEADER_KEY];

            var protectedPlayerId = Context.GetHttpContext().Request.Headers[SecurityConstantProvider.PROTECTED_PLAYER_ID_HEADER_KEY];

            var playerId = Helpers.Security.PlayerSecurityHelper.UnprotectPlayerId(protectedPlayerId);

            await dashboardHubContext.Clients.Group(accountId).OnPlayerConnectedAsync(playerId);

            await Groups.AddToGroupAsync(Context.ConnectionId, accountId.ToString());

            PlayerContextsSignalRModelProvider.Instance.Contexts.Add(new Models.SignalR.PlayerContextSignalRModel
            {
                ConnectionId = Context.ConnectionId,
                AccountId = System.Guid.Parse(accountId),
                PlayerId = playerId
            });

            await base.OnConnectedAsync();
        }

        public async override System.Threading.Tasks.Task OnDisconnectedAsync(System.Exception exception)
        {
            var playerContext = PlayerContextsSignalRModelProvider.Instance.Contexts.First(m => m.ConnectionId == Context.ConnectionId);

            PlayerContextsSignalRModelProvider.Instance.Contexts.Remove(playerContext);

            await dashboardHubContext.Clients.Group(playerContext.AccountId.ToString()).OnPlayerDisconnectedAsync(playerContext.PlayerId);

            await base.OnDisconnectedAsync(exception);
        }

        public void NotifyPlayingPlacard(System.Guid placardId)
        {
            var playerContext = PlayerContextsSignalRModelProvider.Instance.Contexts.First(m => m.ConnectionId == Context.ConnectionId);

            dashboardHubContext.Clients.Group(playerContext.AccountId.ToString()).OnPlayingPlacardAsync(playerContext.PlayerId, placardId);
        }

        public void UpdateEnvironmentConfiguration(int audioLevel, bool audioEnabled)
        {
            var playerContext = PlayerContextsSignalRModelProvider.Instance.Contexts.First(m => m.ConnectionId == Context.ConnectionId);

            playerContext.AudioEnabled = audioEnabled;
            playerContext.AudioLevel = audioLevel;

            dashboardHubContext.Clients.Group(playerContext.AccountId.ToString()).OnPlayerUpdateEnvironmentConfigurationAsync(playerContext.PlayerId, playerContext.AudioLevel, playerContext.AudioEnabled);
        }
    }
}
