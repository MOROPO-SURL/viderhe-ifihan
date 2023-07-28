using Microsoft.AspNetCore.SignalR;
using MOROPO.SAPRESSC.Core.Persistence.Repositories;
using SmartSolucionesCuba.Viderhe.Cloud.SignalR.Connect.Common.Enumerations;
using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Cloud.Hubs
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Policy = Security.Authorization.Policies.ACCOUNT_VALIDATED_MODERATION)]
    public class DashboardHub : Hub<SignalR.Connect.Dashboard.Clients.IDashboardClient>, SignalR.Connect.Dashboard.Hubs.IDashboardHub
    {
        private readonly IHubContext<PlayerHub, SignalR.Connect.Player.Clients.IPlayerClient> playerHubContext;
        private readonly IEntityRepository<Persistence.Entities.Screenplay, System.Guid> screenplayRepository;
        private readonly IEntityRepository<Persistence.Entities.Placard, System.Guid> placardRepository;

        public DashboardHub(IEntityRepository<Persistence.Entities.Placard, System.Guid> placardRepository, IEntityRepository<Persistence.Entities.Screenplay, System.Guid> screenplayRepository, IHubContext<PlayerHub, SignalR.Connect.Player.Clients.IPlayerClient> playerHubContext)
        {
            this.playerHubContext = playerHubContext;
            this.screenplayRepository = screenplayRepository;
            this.placardRepository = placardRepository;
        }

        public async override System.Threading.Tasks.Task OnConnectedAsync()
        {
            var accountId = System.Guid.Parse(Context.User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value);

            await Groups.AddToGroupAsync(Context.ConnectionId, accountId.ToString());

            await base.OnConnectedAsync();
        }

        public void PlayerPresentNextFrame(string[] playerIds)
        {
            var accountId = System.Guid.Parse(Context.User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value);

            var caller = Clients.Caller;

            foreach (var playerId in playerIds)
            {
                try
                {
                    var playerContext = Providers.PlayerContextsSignalRModelProvider.Instance.Contexts.First(m => m.AccountId == accountId && m.PlayerId == playerId);

                    playerHubContext.Clients.Client(playerContext.ConnectionId).OnPresentNextFrameRequestAsync().ContinueWith(task =>
                    {
                        caller.OnPlayerActionRequestResultAsync(playerContext.PlayerId, !task.IsCanceled && task.Exception == null);
                    });
                }
                catch { }
            }
        }

        public void PlayerPresentPreviousFrame(string[] playerIds)
        {
            var accountId = System.Guid.Parse(Context.User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value);

            var caller = Clients.Caller;

            foreach (var playerId in playerIds)
            {
                try
                {
                    var playerContext = Providers.PlayerContextsSignalRModelProvider.Instance.Contexts.First(m => m.AccountId == accountId && m.PlayerId == playerId);

                    playerHubContext.Clients.Client(playerContext.ConnectionId).OnPresentPreviousFrameRequestAsync().ContinueWith(task =>
                    {
                        caller.OnPlayerActionRequestResultAsync(playerContext.PlayerId, !task.IsCanceled && task.Exception == null);
                    });
                }
                catch { }
            }
        }

        public void PlayerPresentInterventionScreenplay(string[] playerIds, System.Guid screenplayId)
        {
            var accountId = System.Guid.Parse(Context.User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value);

            var caller = Clients.Caller;

            var screenplay = screenplayRepository.Get(screenplayId);

            foreach (var playerId in playerIds)
            {
                try
                {
                    var playerContext = Providers.PlayerContextsSignalRModelProvider.Instance.Contexts.First(m => m.AccountId == accountId && m.PlayerId == playerId);

                    playerHubContext.Clients.Client(playerContext.ConnectionId).OnPresentInterventionPlacardsRequestAsync(screenplay.Frames.OrderBy(e => e.Priority).Where(e => e.Placard.Template.Enabled).Select((Persistence.Entities.Frame entity) =>
                    {
                        var model = new Api.Common.Models.PlacardDisplayModel();

                        model.Import(entity.Placard);

                        return model;
                    }).ToArray()).ContinueWith(task =>
                    {
                        caller.OnPlayerActionRequestResultAsync(playerContext.PlayerId, !task.IsCanceled && task.Exception == null);
                    });
                }
                catch { }
            }
        }

        public void PlayerPresentInterventionPlacard(string[] playerIds, System.Guid placardId)
        {
            var accountId = System.Guid.Parse(Context.User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value);

            var caller = Clients.Caller;

            var entity = placardRepository.Get(placardId);

            var model = new Api.Common.Models.PlacardDisplayModel();

            model.Import(entity);

            foreach (var playerId in playerIds)
            {
                try
                {
                    var playerContext = Providers.PlayerContextsSignalRModelProvider.Instance.Contexts.First(m => m.AccountId == accountId && m.PlayerId == playerId);

                    playerHubContext.Clients.Client(playerContext.ConnectionId).OnPresentInterventionPlacardsRequestAsync(new Api.Common.Models.PlacardDisplayModel[] { model }).ContinueWith(task =>
                    {
                        caller.OnPlayerActionRequestResultAsync(playerContext.PlayerId, !task.IsCanceled && task.Exception == null);
                    });
                }
                catch { }
            }
        }

        public void PlayerRestartScreenplay(string[] playerIds, ScreenplayHandlingImmediacyMode immediancyMode)
        {
            var accountId = System.Guid.Parse(Context.User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value);

            var caller = Clients.Caller;

            foreach (var playerId in playerIds)
            {
                try
                {
                    var playerContext = Providers.PlayerContextsSignalRModelProvider.Instance.Contexts.First(m => m.AccountId == accountId && m.PlayerId == playerId);

                    playerHubContext.Clients.Client(playerContext.ConnectionId).OnRestartScreenplayRequestAsync(immediancyMode).ContinueWith(task =>
                    {
                        caller.OnPlayerActionRequestResultAsync(playerContext.PlayerId, !task.IsCanceled && task.Exception == null);
                    });
                }
                catch { }
            }
        }

        public void PlayerReloadScreenplay(string[] playerIds, ScreenplayHandlingImmediacyMode immediancyMode)
        {
            var accountId = System.Guid.Parse(Context.User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value);

            var caller = Clients.Caller;

            foreach (var playerId in playerIds)
            {
                try
                {
                    var playerContext = Providers.PlayerContextsSignalRModelProvider.Instance.Contexts.First(m => m.AccountId == accountId && m.PlayerId == playerId);

                    playerHubContext.Clients.Client(playerContext.ConnectionId).OnReloadScreenplayRequestAsync(immediancyMode).ContinueWith(task =>
                    {
                        caller.OnPlayerActionRequestResultAsync(playerContext.PlayerId, !task.IsCanceled && task.Exception == null);
                    });
                }
                catch { }
            }
        }

        public void PlayerSetAudioEnabled(string[] playerIds, bool enabled)
        {
            var accountId = System.Guid.Parse(Context.User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value);

            var caller = Clients.Caller;

            foreach (var playerId in playerIds)
            {
                try
                {
                    var playerContext = Providers.PlayerContextsSignalRModelProvider.Instance.Contexts.First(m => m.AccountId == accountId && m.PlayerId == playerId);

                    playerHubContext.Clients.Client(playerContext.ConnectionId).OnSetAudioEnabledRequestAsync(enabled).ContinueWith(task =>
                    {
                        caller.OnPlayerActionRequestResultAsync(playerContext.PlayerId, !task.IsCanceled && task.Exception == null);
                    });
                }
                catch { }
            }
        }

        public void PlayerSetAudioLevel(string[] playerIds, int percent)
        {
            var accountId = System.Guid.Parse(Context.User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value);

            var caller = Clients.Caller;

            foreach (var playerId in playerIds)
            {
                try
                {
                    var playerContext = Providers.PlayerContextsSignalRModelProvider.Instance.Contexts.First(m => m.AccountId == accountId && m.PlayerId == playerId);

                    playerHubContext.Clients.Client(playerContext.ConnectionId).OnSetAudioLevelRequestAsync(percent).ContinueWith(task =>
                    {
                        caller.OnPlayerActionRequestResultAsync(playerContext.PlayerId, !task.IsCanceled && task.Exception == null);
                    });
                }
                catch { }
            }
        }

        public void PlayerClose(string[] playerIds, bool restart = false)
        {
            var accountId = System.Guid.Parse(Context.User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value);

            var caller = Clients.Caller;

            foreach (var playerId in playerIds)
            {
                try
                {
                    var playerContext = Providers.PlayerContextsSignalRModelProvider.Instance.Contexts.First(m => m.AccountId == accountId && m.PlayerId == playerId);

                    playerHubContext.Clients.Client(playerContext.ConnectionId).OnCloseRequestAsync(restart).ContinueWith(task =>
                    {
                        caller.OnPlayerActionRequestResultAsync(playerContext.PlayerId, !task.IsCanceled && task.Exception == null);
                    });
                }
                catch { }
            }
        }

        public void PlayerShutdown(string[] playerIds, bool restart = false)
        {
            var accountId = System.Guid.Parse(Context.User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value);

            var caller = Clients.Caller;

            foreach (var playerId in playerIds)
            {
                try
                {
                    var playerContext = Providers.PlayerContextsSignalRModelProvider.Instance.Contexts.First(m => m.AccountId == accountId && m.PlayerId == playerId);

                    playerHubContext.Clients.Client(playerContext.ConnectionId).OnShutdownRequestAsync(restart).ContinueWith(task =>
                    {
                        caller.OnPlayerActionRequestResultAsync(playerContext.PlayerId, !task.IsCanceled && task.Exception == null);
                    });
                }
                catch { }
            }
        }
    }
}
