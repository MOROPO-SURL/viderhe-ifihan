using Microsoft.AspNetCore.SignalR.Client;
using MOROPO.VIDERHE.Cloud.SignalR.Connect.Common.Enumerations;
using MOROPO.VIDERHE.Cloud.SignalR.Connect.Dashboard.Clients;
using MOROPO.VIDERHE.Cloud.SignalR.Connect.Dashboard.Hubs;
using MOROPO.VIDERHE.Support.Presentation.Managers;
using System.Linq;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Hubs.Client
{
    public class DashboardHubClient : IDashboardClient, System.IDisposable
    {
        private static DashboardHubClient instance;

        public static DashboardHubClient Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DashboardHubClient();
                }

                return instance;
            }
        }

        private HubConnection connection;

        private System.Collections.ObjectModel.ObservableCollection<Models.View.PlayerViewModel> players;

        private System.Action playerConnectionStatusChangeCallbackAction;

        public DashboardHubClient()
        {
            connection = new HubConnectionBuilder()
                .WithUrl(string.Format("{0}://{1}/hubs/dashboard", SessionMemoryManager.Instance.UseSSL ? "https" : "http", SessionMemoryManager.Instance.Host), options =>
                {
                    options.AccessTokenProvider = () => System.Threading.Tasks.Task.FromResult(Managers.SessionManager.Instance.AuthorizationToken);
                })
                .WithAutomaticReconnect()
                .Build();

            connection.On<string>(nameof(OnPlayerConnectedAsync), OnPlayerConnectedAsync);
            connection.On<string>(nameof(OnPlayerDisconnectedAsync), OnPlayerDisconnectedAsync);
            connection.On<string, System.Guid>(nameof(OnPlayingPlacardAsync), OnPlayingPlacardAsync);
            connection.On<string, int, bool>(nameof(OnPlayerUpdateEnvironmentConfigurationAsync), OnPlayerUpdateEnvironmentConfigurationAsync);
            connection.On<string, bool>(nameof(OnPlayerActionRequestResultAsync), OnPlayerActionRequestResultAsync);
        }

        public void GetReady(System.Collections.ObjectModel.ObservableCollection<Models.View.PlayerViewModel> players, System.Action playerConnectionStatusChangeCallbackAction)
        {
            this.players = players;
            this.playerConnectionStatusChangeCallbackAction = playerConnectionStatusChangeCallbackAction;

            if (connection.State == HubConnectionState.Disconnected)
            {
                connection.StartAsync();
            }
        }

        public async System.Threading.Tasks.Task RequestPlayerPresentNextFrameAsync(Models.View.PlayerViewModel[] players)
        {
            DisablePlayers(players);

            await connection.InvokeAsync(nameof(IDashboardHub.PlayerPresentNextFrame), players.Select(item => item.Id).ToArray());
        }

        public async System.Threading.Tasks.Task RequestPlayerPresentPreviousFrameAsync(Models.View.PlayerViewModel[] players)
        {
            DisablePlayers(players);

            await connection.InvokeAsync(nameof(IDashboardHub.PlayerPresentPreviousFrame), players.Select(item => item.Id).ToArray());
        }

        public async System.Threading.Tasks.Task PlayerPresentInterventionScreenplayAsync(Models.View.PlayerViewModel[] players, System.Guid screenplayId)
        {
            DisablePlayers(players);

            await connection.InvokeAsync(nameof(IDashboardHub.PlayerPresentInterventionScreenplay), players.Select(item => item.Id).ToArray(), screenplayId);
        }

        public async System.Threading.Tasks.Task PlayerPresentInterventionPlacardAsync(Models.View.PlayerViewModel[] players, System.Guid placardId)
        {
            DisablePlayers(players);

            await connection.InvokeAsync(nameof(IDashboardHub.PlayerPresentInterventionPlacard), players.Select(item => item.Id).ToArray(), placardId);
        }

        public async System.Threading.Tasks.Task RequestPlayerRestartScreenplayAsync(Models.View.PlayerViewModel[] players, ScreenplayHandlingImmediacyMode immediacyMode)
        {
            DisablePlayers(players);

            await connection.InvokeAsync(nameof(IDashboardHub.PlayerRestartScreenplay), players.Select(item => item.Id).ToArray(), immediacyMode);
        }

        public async System.Threading.Tasks.Task RequestPlayerReloadScreenplayAsync(Models.View.PlayerViewModel[] players, ScreenplayHandlingImmediacyMode immediacyMode)
        {
            DisablePlayers(players);

            await connection.InvokeAsync(nameof(IDashboardHub.PlayerReloadScreenplay), players.Select(item => item.Id).ToArray(), immediacyMode);
        }

        public async System.Threading.Tasks.Task RequestPlayerSetAudioEnabledAsync(Models.View.PlayerViewModel[] players, bool enabled)
        {
            DisablePlayers(players);

            await connection.InvokeAsync(nameof(IDashboardHub.PlayerSetAudioEnabled), players.Select(item => item.Id).ToArray(), enabled);
        }

        public async System.Threading.Tasks.Task RequestPlayerAudioVolumeChangeAsync(Models.View.PlayerViewModel[] players, int percent)
        {
            DisablePlayers(players);

            await connection.InvokeAsync(nameof(IDashboardHub.PlayerSetAudioLevel), players.Select(item => item.Id).ToArray(), percent);
        }

        public async System.Threading.Tasks.Task RequestPlayerCloseAsync(Models.View.PlayerViewModel[] players, bool restart)
        {
            DisablePlayers(players);

            await connection.InvokeAsync(nameof(IDashboardHub.PlayerClose), players.Select(item => item.Id).ToArray(), restart);
        }

        public async System.Threading.Tasks.Task RequestPlayerTerminateAsync(Models.View.PlayerViewModel[] players, bool restart)
        {
            DisablePlayers(players);

            await connection.InvokeAsync(nameof(IDashboardHub.PlayerShutdown), players.Select(item => item.Id).ToArray(), restart);
        }

        public System.Threading.Tasks.Task OnPlayerConnectedAsync(string playerId)
        {
            try
            {
                var player = players.First(m => m.Id == playerId);

                player.IsConnected = true;

                System.Threading.Tasks.Task.Delay(System.TimeSpan.FromSeconds(1)).ContinueWith(_ =>
                {
                    player.IsEnabled = true;

                    Xamarin.Forms.Device.BeginInvokeOnMainThread(playerConnectionStatusChangeCallbackAction);
                });
            }
            catch { }

            return System.Threading.Tasks.Task.CompletedTask;
        }

        public System.Threading.Tasks.Task OnPlayerDisconnectedAsync(string playerId)
        {
            try
            {
                var player = players.First(m => m.Id == playerId);

                player.IsConnected = false;
                player.IsEnabled = false;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(playerConnectionStatusChangeCallbackAction);
            }
            catch { }

            return System.Threading.Tasks.Task.CompletedTask;
        }

        public System.Threading.Tasks.Task OnPlayerUpdateEnvironmentConfigurationAsync(string playerId, int audioLevel, bool audioEnabled)
        {
            try
            {
                var player = players.First(m => m.Id == playerId);

                player.AudioLevel = audioLevel;
                player.AudioEnabled = audioEnabled;
            }
            catch { }

            return System.Threading.Tasks.Task.CompletedTask;
        }

        public System.Threading.Tasks.Task OnPlayingPlacardAsync(string playerId, System.Guid placardId)
        {
            return System.Threading.Tasks.Task.CompletedTask;
        }


        public System.Threading.Tasks.Task OnPlayerActionRequestResultAsync(string playerId, bool success)
        {
            try
            {
                players.First(m => m.Id == playerId).IsEnabled = true;
            }
            catch { }

            return System.Threading.Tasks.Task.CompletedTask;
        }

        private void DisablePlayers(Models.View.PlayerViewModel[] players)
        {
            foreach (var item in players)
            {
                item.IsEnabled = false;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // Para detectar llamadas redundantes

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: elimine el estado administrado (objetos administrados).
                }

                // TODO: libere los recursos no administrados (objetos no administrados) y reemplace el siguiente finalizador.
                // TODO: configure los campos grandes en nulos.

                playerConnectionStatusChangeCallbackAction = null;

                connection.Remove(nameof(OnPlayerConnectedAsync));
                connection.Remove(nameof(OnPlayerDisconnectedAsync));
                connection.Remove(nameof(OnPlayingPlacardAsync));
                connection.Remove(nameof(OnPlayerUpdateEnvironmentConfigurationAsync));

                connection.StopAsync().ContinueWith(task =>
                {
                    connection.DisposeAsync();
                });

                disposedValue = true;
            }
        }

        // TODO: reemplace un finalizador solo si el anterior Dispose(bool disposing) tiene código para liberar los recursos no administrados.
        // ~DashboardHubClient() {
        //   // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
        //   Dispose(false);
        // }

        // Este código se agrega para implementar correctamente el patrón descartable.
        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
