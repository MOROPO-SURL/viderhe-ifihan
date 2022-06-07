using Microsoft.AspNetCore.SignalR.Client;
using SmartSolucionesCuba.Viderhe.Cloud.SignalR.Connect.Common.Enumerations;
using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Hubs.Client
{
    public class DashboardHubClient : Cloud.SignalR.Connect.Dashboard.Clients.IDashboardClient, System.IDisposable
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

        public DashboardHubClient()
        {
            connection = new HubConnectionBuilder()
                .WithUrl(string.Format("http://{0}/hubs/dashboard", Support.Presentation.Managers.SessionMemoryManager.Instance.CloudServerHost), options =>
                {
                    options.AccessTokenProvider = () => System.Threading.Tasks.Task.FromResult(Managers.SessionManager.Instance.AuthorizationToken);
                })
                .WithAutomaticReconnect()
                .Build();

            connection.On<string>(nameof(OnPlayerConnectedAsync), OnPlayerConnectedAsync);
            connection.On<string>(nameof(OnPlayerDisconnectedAsync), OnPlayerDisconnectedAsync);
            connection.On<string, System.Guid>(nameof(OnPlayingPlacardAsync), OnPlayingPlacardAsync);
            connection.On<string, int, bool>(nameof(OnPlayerUpdateEnvironmentConfigurationAsync), OnPlayerUpdateEnvironmentConfigurationAsync);
        }

        public void GetReady(System.Collections.ObjectModel.ObservableCollection<Models.View.PlayerViewModel> players)
        {
            this.players = players;

            if (connection.State == HubConnectionState.Disconnected)
            {
                connection.StartAsync();
            }
        }

        public async System.Threading.Tasks.Task RequestPlayerPresentNextFrameAsync(string playerId)
        {
            await connection.InvokeAsync(nameof(Cloud.SignalR.Connect.Dashboard.Hubs.IDashboardHub.PlayerPresentNextFrame), playerId);
        }

        public async System.Threading.Tasks.Task RequestPlayerPresentPreviousFrameAsync(string playerId)
        {
            await connection.InvokeAsync(nameof(Cloud.SignalR.Connect.Dashboard.Hubs.IDashboardHub.PlayerPresentPreviousFrame), playerId);
        }

        public async System.Threading.Tasks.Task PlayerPresentInterventionScreenplayAsync(string playerId, System.Guid screenplayId)
        {
            await connection.InvokeAsync(nameof(Cloud.SignalR.Connect.Dashboard.Hubs.IDashboardHub.PlayerPresentInterventionScreenplay), playerId, screenplayId);
        }

        public async System.Threading.Tasks.Task PlayerPresentInterventionPlacardAsync(string playerId, System.Guid placardId)
        {
            await connection.InvokeAsync(nameof(Cloud.SignalR.Connect.Dashboard.Hubs.IDashboardHub.PlayerPresentInterventionPlacard), playerId, placardId);
        }

        public async System.Threading.Tasks.Task RequestPlayerRestartScreenplayAsync(string playerId, ScreenplayHandlingImmediacyMode immediacyMode)
        {
            await connection.InvokeAsync(nameof(Cloud.SignalR.Connect.Dashboard.Hubs.IDashboardHub.PlayerRestarScreenplay), playerId, immediacyMode);
        }

        public async System.Threading.Tasks.Task RequestPlayerReloadScreenplayAsync(string playerId, ScreenplayHandlingImmediacyMode immediacyMode)
        {
            await connection.InvokeAsync(nameof(Cloud.SignalR.Connect.Dashboard.Hubs.IDashboardHub.PlayerReloadScreenplay), playerId, immediacyMode);
        }

        public async System.Threading.Tasks.Task RequestPlayerSetAudioEnabledAsync(string playerId, bool enabled)
        {
            await connection.InvokeAsync(nameof(Cloud.SignalR.Connect.Dashboard.Hubs.IDashboardHub.PlayerSetAudioEnabled), playerId, enabled);
        }

        public async System.Threading.Tasks.Task RequestPlayerAudioVolumeChangeAsync(string playerId, int percent)
        {
            await connection.InvokeAsync(nameof(Cloud.SignalR.Connect.Dashboard.Hubs.IDashboardHub.PlayerSetAudioLevel), playerId, percent);
        }

        public async System.Threading.Tasks.Task RequestPlayerCloseAsync(string playerId, bool restart)
        {
            await connection.InvokeAsync(nameof(Cloud.SignalR.Connect.Dashboard.Hubs.IDashboardHub.PlayerClose), playerId, restart);
        }

        public async System.Threading.Tasks.Task RequestPlayerTerminateAsync(string playerId, bool restart)
        {
            await connection.InvokeAsync(nameof(Cloud.SignalR.Connect.Dashboard.Hubs.IDashboardHub.PlayerShutdown), playerId, restart);
        }

        public System.Threading.Tasks.Task OnPlayerConnectedAsync(string playerId)
        {
            try
            {
                players.First(m => m.Id == playerId).IsConnected = true;
            }
            catch { }

            return System.Threading.Tasks.Task.CompletedTask;
        }

        public System.Threading.Tasks.Task OnPlayerDisconnectedAsync(string playerId)
        {
            try
            {
                players.First(m => m.Id == playerId).IsConnected = false;
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
