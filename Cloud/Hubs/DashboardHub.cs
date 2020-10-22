using Microsoft.AspNetCore.SignalR;
using SmartSolucionesCuba.Videre.Cloud.SignalR.Connect.Common.Enumerations;
using System.Linq;

namespace SmartSolucionesCuba.Videre.Cloud.Hubs
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Policy = Security.Authorization.Policies.ACCOUNT_ASSOCIATED)]
    public class DashboardHub : Hub<SignalR.Connect.Dashboard.Clients.IDashboardClient>, SignalR.Connect.Dashboard.Hubs.IDashboardHub
    {
        private readonly IHubContext<PlayerHub, SignalR.Connect.Player.Clients.IPlayerClient> playerHubContext;

        public DashboardHub(IHubContext<PlayerHub, SignalR.Connect.Player.Clients.IPlayerClient> playerHubContext)
        {
            this.playerHubContext = playerHubContext;
        }

        public async override System.Threading.Tasks.Task OnConnectedAsync()
        {
            var accountId = System.Guid.Parse(Context.User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value);

            await Groups.AddToGroupAsync(Context.ConnectionId, accountId.ToString());

            await base.OnConnectedAsync();
        }

        public void PlayerPresentNextFrame(string playerId)
        {
            var accountId = System.Guid.Parse(Context.User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value);

            try
            {
                var playerContext = Providers.PlayerContextsSignalRModelProvider.Instance.Contexts.First(m => m.AccountId == accountId && m.PlayerId == playerId);

                playerHubContext.Clients.Client(playerContext.ConnectionId).PresentNextFrame();
            }
            catch { }
        }

        public void PlayerPresentPreviousFrame(string playerId)
        {
            var accountId = System.Guid.Parse(Context.User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value);

            try
            {
                var playerContext = Providers.PlayerContextsSignalRModelProvider.Instance.Contexts.First(m => m.AccountId == accountId && m.PlayerId == playerId);

                playerHubContext.Clients.Client(playerContext.ConnectionId).PresentPreviousFrame();
            }
            catch { }
        }

        public void PlayerRestarScreenplay(string playerId, ScreenplayHandlingImmediacyMode immediancyMode)
        {
            var accountId = System.Guid.Parse(Context.User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value);

            try
            {
                var playerContext = Providers.PlayerContextsSignalRModelProvider.Instance.Contexts.First(m => m.AccountId == accountId && m.PlayerId == playerId);

                playerHubContext.Clients.Client(playerContext.ConnectionId).RestarScreenplay(immediancyMode);
            }
            catch { }
        }

        public void PlayerReloadScreenplay(string playerId, ScreenplayHandlingImmediacyMode immediancyMode)
        {
            var accountId = System.Guid.Parse(Context.User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value);

            try
            {
                var playerContext = Providers.PlayerContextsSignalRModelProvider.Instance.Contexts.First(m => m.AccountId == accountId && m.PlayerId == playerId);

                playerHubContext.Clients.Client(playerContext.ConnectionId).ReloadScreenplay(immediancyMode);
            }
            catch { }
        }

        public void PlayerSetAudioLevel(string playerId, int percent)
        {
            var accountId = System.Guid.Parse(Context.User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value);

            try
            {
                var playerContext = Providers.PlayerContextsSignalRModelProvider.Instance.Contexts.First(m => m.AccountId == accountId && m.PlayerId == playerId);

                playerHubContext.Clients.Client(playerContext.ConnectionId).SetAudioLevel(percent);
            }
            catch { }
        }

        public void PlayerShutdown(string playerId, bool restart = false)
        {
            var accountId = System.Guid.Parse(Context.User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value);

            try
            {
                var playerContext = Providers.PlayerContextsSignalRModelProvider.Instance.Contexts.First(m => m.AccountId == accountId && m.PlayerId == playerId);

                playerHubContext.Clients.Client(playerContext.ConnectionId).Shutdown(restart);
            }
            catch { }
        }
    }
}
