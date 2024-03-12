using MOROPO.VIDERHE.Extend.UICCamaguey.Templating.Presentation.Hubs.Client;
using MOROPO.VIDERHE.Extend.UICCamaguey.Templating.Presentation.Models.View;
using System.Linq;

namespace MOROPO.VIDERHE.Extend.UICCamaguey.Templating.Presentation.Views
{
    public partial class AmbientalDashboardPlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        private AmbientalHubConnectClient ambientalHubConnectClient;
        private MOROPO.UIC.IoTPlatform.Interop.Sync.Receptor.API.Connect.Clients.AmbientalReadingsApiConnectClient ambientalReadingsApiConnectClient;

        public AmbientalDashboardPlacardView(AmbientalDashboardPlacardViewModel model, System.Uri ioTPlatformEndpointBaseUri, double relativeSizeScaleFactor) : base(relativeSizeScaleFactor)
        {
            InitializeComponent();

            ambientalHubConnectClient = new Hubs.Client.AmbientalHubConnectClient(ioTPlatformEndpointBaseUri, model);
            ambientalReadingsApiConnectClient = new MOROPO.UIC.IoTPlatform.Interop.Sync.Receptor.API.Connect.Clients.AmbientalReadingsApiConnectClient(new Providers.IoTSyncReceptorApiHttpClientHelperProvider(new System.Uri(string.Format("{0}api/", ioTPlatformEndpointBaseUri))));

            BindingContext = model;
        }

        public override Xamarin.Forms.Layout<Xamarin.Forms.View> WrapLayout => Wrapper;

        public override Xamarin.Forms.View PlacardView => PlacardLayout;

        public override void ConfigureLayout(Xamarin.Forms.View view)
        {
            Xamarin.Forms.Grid.SetColumn(view, 0);
            Xamarin.Forms.Grid.SetRow(view, 0);
        }

        public override void PerformPlacardStarup()
        {
            base.PerformPlacardStarup();

            ambientalReadingsApiConnectClient.GetPaginateAsync().ContinueWith(task =>
            {
                if (task.IsFaulted || task.IsCanceled)
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(EndPresentation);

                    return;
                }

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    var contreteBindingContext = BindingContext as AmbientalDashboardPlacardViewModel;

                    if (task.Result.MaxPageCount > 0)
                    {
                        contreteBindingContext.LastReading = task.Result.List.Last();
                    }

                    string template;
                    
                    switch (contreteBindingContext.AmbientalVariable)
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

                    contreteBindingContext.Chart.Entries = new System.Collections.Generic.List<Microcharts.ChartEntry>(task.Result.List.Select(item =>
                    {
                        double value;

                        switch (contreteBindingContext.AmbientalVariable)
                        {
                            case Enumerations.AmbientalVariable.Humidity:
                                value = item.Humidity;

                                break;

                            case Enumerations.AmbientalVariable.SmogPPM:
                                value = item.SmogPPM;

                                break;

                            case Enumerations.AmbientalVariable.Temperature:
                            default:
                                value = item.Temperature;

                                break;
                        }

                        return new Microcharts.ChartEntry((float)value)
                        {
                            Label = item.CreatedAt.ToShortTimeString(),
                            ValueLabel = string.Format(template, value)
                        };
                    }));

                    ambientalHubConnectClient.Connect();
                });
            });
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            ambientalHubConnectClient.Dispose();

            ambientalHubConnectClient = null;
            ambientalReadingsApiConnectClient = null;
        }
    }
}