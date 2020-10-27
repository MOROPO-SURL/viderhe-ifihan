using Microsoft.AspNetCore.SignalR.Client;
using SmartSolucionesCuba.Videre.Cloud.SignalR.Connect.Common.Enumerations;
using System.Linq;

namespace SmartSolucionesCuba.Videre.Terminal.Dashboard.Hubs.Client
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
                .WithUrl(string.Format("http://{0}/hubs/dashboard", Providers.CloudServerProvider.Instance.CloudServerHost), options =>
                {
                    options.AccessTokenProvider = () => System.Threading.Tasks.Task.FromResult(Managers.SessionManager.Instance.AuthorizationToken);
                })
                .WithAutomaticReconnect()
                .Build();

            connection.On<string>(nameof(PlayerConnected), PlayerConnected);
            connection.On<string>(nameof(PlayerDisconnected), PlayerDisconnected);
            connection.On<string, System.Guid>(nameof(PlayingPlacard), PlayingPlacard);
            connection.On<string, int, bool>(nameof(PlayerUpdateEnvironmentConfiguration), PlayerUpdateEnvironmentConfiguration);
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

        public async System.Threading.Tasks.Task RequestPlayerRestarScreenplayAsync(string playerId, ScreenplayHandlingImmediacyMode immediacyMode)
        {
            await connection.InvokeAsync(nameof(Cloud.SignalR.Connect.Dashboard.Hubs.IDashboardHub.PlayerRestarScreenplay), playerId, immediacyMode);
        }

        public async System.Threading.Tasks.Task RequestPlayerReloadScreenplayAsync(string playerId, ScreenplayHandlingImmediacyMode immediacyMode)
        {
            await connection.InvokeAsync(nameof(Cloud.SignalR.Connect.Dashboard.Hubs.IDashboardHub.PlayerReloadScreenplay), playerId, immediacyMode);
        }

        public System.Threading.Tasks.Task PlayerConnected(string playerId)
        {
            try
            {
                players.First(m => m.Id == playerId).IsConnected = true;
            }
            catch { }

            return System.Threading.Tasks.Task.CompletedTask;
        }

        public System.Threading.Tasks.Task PlayerDisconnected(string playerId)
        {
            try
            {
                players.First(m => m.Id == playerId).IsConnected = false;
            }
            catch { }

            return System.Threading.Tasks.Task.CompletedTask;
        }

        public System.Threading.Tasks.Task PlayerUpdateEnvironmentConfiguration(string playerId, int audioLevel, bool audioEnabled)
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

        public System.Threading.Tasks.Task PlayingPlacard(string playerId, System.Guid placardId)
        {
            System.Diagnostics.Debug.WriteLine("Hub Client Method Invoke : PlayingPlacard: {0}, {1}", playerId, placardId);

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

                connection.Remove(nameof(PlayerConnected));
                connection.Remove(nameof(PlayerDisconnected));
                connection.Remove(nameof(PlayingPlacard));
                connection.Remove(nameof(PlayerUpdateEnvironmentConfiguration));

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
