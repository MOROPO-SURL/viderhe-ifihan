using Microsoft.AspNetCore.SignalR;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.VIDERHE.Cloud.Api.Common.Models;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;
using MOROPO.VIDERHE.Cloud.Providers;
using MOROPO.VIDERHE.Cloud.Security.Authorization;
using MOROPO.VIDERHE.Cloud.SignalR.Connect.Common.Enumerations;
using System.Linq;

namespace MOROPO.VIDERHE.Cloud.Hubs
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Policy = Policies.ACCOUNT_VALIDATED_MODERATION)]
    public class DashboardHub : Hub<SignalR.Connect.Dashboard.Clients.IDashboardClient>, SignalR.Connect.Dashboard.Hubs.IDashboardHub
    {
        private readonly IHubContext<PlayerHub, SignalR.Connect.Player.Clients.IPlayerClient> playerHubContext;
        private readonly IEntityRepository<Screenplay, System.Guid> screenplayRepository;
        private readonly IEntityRepository<Placard, System.Guid> placardRepository;

        public DashboardHub(IEntityRepository<Placard, System.Guid> placardRepository, IEntityRepository<Screenplay, System.Guid> screenplayRepository, IHubContext<PlayerHub, SignalR.Connect.Player.Clients.IPlayerClient> playerHubContext)
        {
            this.playerHubContext = playerHubContext;
            this.screenplayRepository = screenplayRepository;
            this.placardRepository = placardRepository;
        }

        public async override System.Threading.Tasks.Task OnConnectedAsync()
        {
            var accountId = System.Guid.Parse(Context.User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value);

            await Groups.AddToGroupAsync(Context.ConnectionId, accountId.ToString());

            await base.OnConnectedAsync();
        }

        public void PlayerPresentNextFrame(string[] playerIds)
        {
            var accountId = System.Guid.Parse(Context.User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value);

            var caller = Clients.Caller;

            foreach (var playerId in playerIds)
            {
                try
                {
                    var playerContext = PlayerContextsSignalRModelProvider.Instance.Contexts.First(m => m.AccountId == accountId && m.PlayerId == playerId);

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
            var accountId = System.Guid.Parse(Context.User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value);

            var caller = Clients.Caller;

            foreach (var playerId in playerIds)
            {
                try
                {
                    var playerContext = PlayerContextsSignalRModelProvider.Instance.Contexts.First(m => m.AccountId == accountId && m.PlayerId == playerId);

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
            var accountId = System.Guid.Parse(Context.User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value);

            var caller = Clients.Caller;

            var screenplay = screenplayRepository.Get(screenplayId);

            foreach (var playerId in playerIds)
            {
                try
                {
                    var playerContext = PlayerContextsSignalRModelProvider.Instance.Contexts.First(m => m.AccountId == accountId && m.PlayerId == playerId);

                    playerHubContext.Clients.Client(playerContext.ConnectionId).OnPresentInterventionPlacardsRequestAsync(screenplay.Frames.OrderBy(e => e.Priority).Where(e => e.Placard.Template.Enabled).Select((Frame entity) =>
                    {
                        var model = new PlacardDisplayModel();

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
            var accountId = System.Guid.Parse(Context.User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value);

            var caller = Clients.Caller;

            var entity = placardRepository.Get(placardId);

            var model = new PlacardDisplayModel();

            model.Import(entity);

            foreach (var playerId in playerIds)
            {
                try
                {
                    var playerContext = PlayerContextsSignalRModelProvider.Instance.Contexts.First(m => m.AccountId == accountId && m.PlayerId == playerId);

                    playerHubContext.Clients.Client(playerContext.ConnectionId).OnPresentInterventionPlacardsRequestAsync(new PlacardDisplayModel[] { model }).ContinueWith(task =>
                    {
                        caller.OnPlayerActionRequestResultAsync(playerContext.PlayerId, !task.IsCanceled && task.Exception == null);
                    });
                }
                catch { }
            }
        }

        public void PlayerRestartScreenplay(string[] playerIds, ScreenplayHandlingImmediacyMode immediancyMode)
        {
            var accountId = System.Guid.Parse(Context.User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value);

            var caller = Clients.Caller;

            foreach (var playerId in playerIds)
            {
                try
                {
                    var playerContext = PlayerContextsSignalRModelProvider.Instance.Contexts.First(m => m.AccountId == accountId && m.PlayerId == playerId);

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
            var accountId = System.Guid.Parse(Context.User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value);

            var caller = Clients.Caller;

            foreach (var playerId in playerIds)
            {
                try
                {
                    var playerContext = PlayerContextsSignalRModelProvider.Instance.Contexts.First(m => m.AccountId == accountId && m.PlayerId == playerId);

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
            var accountId = System.Guid.Parse(Context.User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value);

            var caller = Clients.Caller;

            foreach (var playerId in playerIds)
            {
                try
                {
                    var playerContext = PlayerContextsSignalRModelProvider.Instance.Contexts.First(m => m.AccountId == accountId && m.PlayerId == playerId);

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
            var accountId = System.Guid.Parse(Context.User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value);

            var caller = Clients.Caller;

            foreach (var playerId in playerIds)
            {
                try
                {
                    var playerContext = PlayerContextsSignalRModelProvider.Instance.Contexts.First(m => m.AccountId == accountId && m.PlayerId == playerId);

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
            var accountId = System.Guid.Parse(Context.User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value);

            var caller = Clients.Caller;

            foreach (var playerId in playerIds)
            {
                try
                {
                    var playerContext = PlayerContextsSignalRModelProvider.Instance.Contexts.First(m => m.AccountId == accountId && m.PlayerId == playerId);

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
            var accountId = System.Guid.Parse(Context.User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value);

            var caller = Clients.Caller;

            foreach (var playerId in playerIds)
            {
                try
                {
                    var playerContext = PlayerContextsSignalRModelProvider.Instance.Contexts.First(m => m.AccountId == accountId && m.PlayerId == playerId);

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
