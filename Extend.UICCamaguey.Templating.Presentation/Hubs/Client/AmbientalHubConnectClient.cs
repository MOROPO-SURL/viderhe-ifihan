using Microsoft.AspNetCore.SignalR.Client;
using MOROPO.UIC.IoTPlatform.Interop.Sync.Receptor.API.Common.Models;

namespace MOROPO.VIDERHE.Extend.UICCamaguey.Templating.Presentation.Hubs.Client
{
    public class AmbientalHubConnectClient : UIC.IoTPlatform.Interop.Sync.Receptor.SignalR.Connect.Clients.Facade.IAmbientalClientFacade, System.IDisposable
    {
        private HubConnection connection;

        private Models.View.AmbientalDashboardPlacardViewModel viewModel;

        public AmbientalHubConnectClient(System.Uri ioTPlatformEndpointBaseUri, Models.View.AmbientalDashboardPlacardViewModel viewModel)
        {
            connection = new HubConnectionBuilder()
                .WithUrl(string.Format("{0}hubs/ambiental", ioTPlatformEndpointBaseUri))
                .WithAutomaticReconnect()
                .Build();

            connection.On<AmbientalReadingDisplayModel>(nameof(OnReadingReceiveAsync), OnReadingReceiveAsync);

            this.viewModel = viewModel;
        }

        public void Connect()
        {
            if (connection.State == HubConnectionState.Disconnected)
            {
                connection.StartAsync();
            }
        }

        public System.Threading.Tasks.Task OnReadingReceiveAsync(AmbientalReadingDisplayModel last)
        {
            if (viewModel != null)
            {
                viewModel.LastReading = last;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    string template;

                    switch (viewModel.AmbientalVariable)
                    {
                        case Enumerations.AmbientalVariable.Humidity:
                            template = "{0}%";

                            break;

                        case Enumerations.AmbientalVariable.SmogPPM:
                            template = "{0} ppm";

                            break;

                        case Enumerations.AmbientalVariable.Temperature:
                        default:
                            template = "{0}°C";

                            break;
                    }

                    var currents = new System.Collections.Generic.List<Microcharts.ChartEntry>(viewModel.Chart.Entries);

                    currents.RemoveAt(0);

                    double value;

                    switch (viewModel.AmbientalVariable)
                    {
                        case Enumerations.AmbientalVariable.Humidity:
                            value = last.Humidity;

                            break;

                        case Enumerations.AmbientalVariable.SmogPPM:
                            value = last.SmogPPM;

                            break;

                        case Enumerations.AmbientalVariable.Temperature:
                        default:
                            value = last.Temperature;

                            break;
                    }

                    currents.Add(new Microcharts.ChartEntry((float)value)
                    {
                        Label = last.CreatedAt.ToShortTimeString(),
                        ValueLabel = string.Format(template, value)
                    });

                    viewModel.Chart.Entries = currents;
                });
            }

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

                connection.Remove(nameof(OnReadingReceiveAsync));

                viewModel = null;

                connection.StopAsync().ContinueWith(task =>
                {
                    connection.DisposeAsync();

                    connection = null;
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
