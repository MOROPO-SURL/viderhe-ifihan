using Microsoft.AspNetCore.SignalR.Client;
using SmartSolucionesCuba.Videre.Cloud.SignalR.Connect.Common.Enumerations;
using System.Linq;

namespace SmartSolucionesCuba.Videre.Terminal.Player.Hubs.Client
{
    public class PlayerHubClient : Cloud.SignalR.Connect.Player.Clients.IPlayerClient, System.IDisposable
    {
        private static PlayerHubClient instance;

        public static PlayerHubClient Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlayerHubClient();
                }

                return instance;
            }
        }

        private HubConnection connection;

        public PlayerHubClient()
        {
            connection = new HubConnectionBuilder()
                .WithUrl(string.Format("http://{0}/hubs/player", Managers.ConfigurationManager.Instance.CloudServerHost), options =>
                {
                    options.Headers = new System.Collections.Generic.Dictionary<string, string>();

                    var securityHeaders = Managers.SessionManager.Instance.ExtraHeaders;

                    foreach (var header in securityHeaders)
                    {
                        options.Headers.Add(header);
                    }
                })
                .WithAutomaticReconnect()
                .Build();

            connection.On(nameof(PresentNextFrame), PresentNextFrame);
            connection.On(nameof(PresentPreviousFrame), PresentPreviousFrame);
            connection.On<ScreenplayHandlingImmediacyMode>(nameof(RestarScreenplay), RestarScreenplay);
            connection.On<ScreenplayHandlingImmediacyMode>(nameof(ReloadScreenplay), ReloadScreenplay);
            connection.On<bool>(nameof(SetAudioEnabled), SetAudioEnabled);
            connection.On<int>(nameof(SetAudioLevel), SetAudioLevel);
            connection.On<bool>(nameof(Shutdown), Shutdown);

            connection.Closed += Connection_ClosedAsync;
        }

        private async System.Threading.Tasks.Task Connection_ClosedAsync(System.Exception arg)
        {
            var randomizer = new System.Random();

            await System.Threading.Tasks.Task.Delay(System.TimeSpan.FromSeconds(randomizer.Next(0, 5)));

            await connection.StartAsync();
        }

        public void GetReady()
        {
            if (connection.State == HubConnectionState.Disconnected)
            {
                connection.StartAsync().ContinueWith(task =>
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        var platformControlHelper = Xamarin.Forms.DependencyService.Get<Helpers.Facade.IPlatformControlHelperFacade>();

                        UpdateEnvironmentConfiguration(platformControlHelper.AudioLevel, platformControlHelper.IsAudioEnabled);
                    });
                });
            }
        }

        public void UpdateEnvironmentConfiguration(int audioLevel, bool isAudioEnabled)
        {
            connection.InvokeAsync(nameof(Cloud.SignalR.Connect.Player.Hubs.IPlayerHub.UpdateEnvironmentConfiguration), audioLevel, isAudioEnabled);
        }

        public void NotifyPlayingPlacard(System.Guid placardId)
        {
            connection.InvokeAsync(nameof(Cloud.SignalR.Connect.Player.Hubs.IPlayerHub.NotifyPlayingPlacard), placardId);
        }

        public System.Threading.Tasks.Task PresentNextFrame()
        {
            if (Xamarin.Forms.Application.Current.MainPage.Navigation.ModalStack.Count > 0)
            {
                var screenplayPlayerPage = Xamarin.Forms.Application.Current.MainPage.Navigation.ModalStack.First() as Support.Presentation.Player.Pages.ScreenplayPlayerPage;

                screenplayPlayerPage.RequestPresentNextFrame();
            }

            return System.Threading.Tasks.Task.CompletedTask;
        }

        public System.Threading.Tasks.Task PresentPreviousFrame()
        {
            if (Xamarin.Forms.Application.Current.MainPage.Navigation.ModalStack.Count > 0)
            {
                var screenplayPlayerPage = Xamarin.Forms.Application.Current.MainPage.Navigation.ModalStack.First() as Support.Presentation.Player.Pages.ScreenplayPlayerPage;

                screenplayPlayerPage.RequestPresentPreviousFrame();
            }

            return System.Threading.Tasks.Task.CompletedTask;
        }

        public System.Threading.Tasks.Task RestarScreenplay(ScreenplayHandlingImmediacyMode immediacyMode)
        {
            if (Xamarin.Forms.Application.Current.MainPage.Navigation.ModalStack.Count > 0)
            {
                var screenplayPlayerPage = Xamarin.Forms.Application.Current.MainPage.Navigation.ModalStack.First() as Support.Presentation.Player.Pages.ScreenplayPlayerPage;

                screenplayPlayerPage.RequestRestar(immediacyMode);
            }

            return System.Threading.Tasks.Task.CompletedTask;
        }

        public System.Threading.Tasks.Task ReloadScreenplay(ScreenplayHandlingImmediacyMode immediacyMode)
        {
            if (Xamarin.Forms.Application.Current.MainPage.Navigation.ModalStack.Count > 0)
            {
                var screenplayPlayerPage = Xamarin.Forms.Application.Current.MainPage.Navigation.ModalStack.First() as Support.Presentation.Player.Pages.ScreenplayPlayerPage;

                screenplayPlayerPage.RequestReload(immediacyMode);
            }

            return System.Threading.Tasks.Task.CompletedTask;
        }

        public System.Threading.Tasks.Task SetAudioLevel(int percent)
        {
            Xamarin.Forms.DependencyService.Get<Helpers.Facade.IPlatformControlHelperFacade>().SetAudioLevel(percent);

            return System.Threading.Tasks.Task.CompletedTask;
        }

        public System.Threading.Tasks.Task SetAudioEnabled(bool enabled)
        {
            Xamarin.Forms.DependencyService.Get<Helpers.Facade.IPlatformControlHelperFacade>().SetAudioEnabled(enabled);

            return System.Threading.Tasks.Task.CompletedTask;
        }

        public System.Threading.Tasks.Task Shutdown(bool restart)
        {
            return Xamarin.Forms.DependencyService.Get<Helpers.Facade.IPlatformControlHelperFacade>().ShutdownAsync(restart);
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

                connection.Closed -= Connection_ClosedAsync;

                connection.Remove(nameof(PresentNextFrame));
                connection.Remove(nameof(PresentPreviousFrame));
                connection.Remove(nameof(RestarScreenplay));
                connection.Remove(nameof(ReloadScreenplay));

                connection.StopAsync().ContinueWith(task =>
                {
                    connection.DisposeAsync();
                });

                disposedValue = true;
            }
        }

        // TODO: reemplace un finalizador solo si el anterior Dispose(bool disposing) tiene código para liberar los recursos no administrados.
        // ~PlayerHubClient() {
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
