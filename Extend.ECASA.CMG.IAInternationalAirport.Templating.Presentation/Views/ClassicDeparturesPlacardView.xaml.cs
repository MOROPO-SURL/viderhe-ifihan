using System.Collections.Generic;

namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Views
{
    public partial class ClassicDeparturesPlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView, Facade.IInteroperablePlacardFacade, MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade
    {
        public ClassicDeparturesPlacardView(Models.View.ClassicDeparturesPlacardViewModel model)
        {
            InitializeComponent();

            BindingContext = model;
        }

        public override Xamarin.Forms.Layout<Xamarin.Forms.View> WrapLayout => Wrapper;

        public override Xamarin.Forms.View PlacardView => DeparturesLayout;

        public Models.View.ClassicDeparturesPlacardViewModel BindingContextViewModel => BindingContext as Models.View.ClassicDeparturesPlacardViewModel;

        public override void ConfigureLayout(Xamarin.Forms.View view)
        {
            Xamarin.Forms.Grid.SetColumn(view, 0);
            Xamarin.Forms.Grid.SetRow(view, 0);
        }

        public override void PerformPlacardStarup()
        {
            base.PerformPlacardStarup();

            var client = new MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Connect.Frontend.Clients.OperationsAPIConnectClient(this);

            client.FilterAsync(new MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.Filter.OperationFilterModel
            {
                Kind = MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind.Departure
            }).ContinueWith(FetchOperations_Callback);
        }

        private void FetchOperations_Callback(System.Threading.Tasks.Task<MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.OperationDisplayModel[]> task)
        {
            if (BindingContext == null) return;

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            if (!task.IsCanceled && task.Exception == null)
            {
                if (BindingContextViewModel.Items == null)
                {
                    BindingContextViewModel.Items = new System.Collections.ObjectModel.ObservableCollection<MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.OperationDisplayModel>();
                }
                else
                {
                    BindingContextViewModel.Items.Clear();

                    foreach (var item in task.Result)
                    {
                        Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                        {
                            BindingContextViewModel.Items.Add(item);
                        });

                        System.Threading.Thread.Sleep(System.TimeSpan.FromMilliseconds(750));
                    }
                }
            }

            stopwatch.Stop();

            var client = new MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Connect.Frontend.Clients.OperationsAPIConnectClient(this);

            var delay = System.TimeSpan.FromSeconds(BindingContextViewModel.UpdateInterval)  - stopwatch.Elapsed;

            if (delay <= System.TimeSpan.Zero)
            {
                client.FilterAsync(new MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.Filter.OperationFilterModel
                {
                    Kind = MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind.Departure
                }).ContinueWith(FetchOperations_Callback);
            }
            else
            {
                System.Threading.Tasks.Task.Delay(delay).ContinueWith(delayTask =>
                {
                    client.FilterAsync(new MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.Filter.OperationFilterModel
                    {
                        Kind = MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind.Departure
                    }).ContinueWith(FetchOperations_Callback);
                });
            }
        }

        #region IInteroperablePlacardFacade implementation

        public Models.View.Contract.AbstractInteroperablePlacardViewModel GetInteroperableModel()
        {
            return BindingContext as Models.View.Contract.AbstractInteroperablePlacardViewModel;
        }

        #endregion

        #region IHttpClientHelperProviderFacade implementation

        public MOROPO.Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper HttpClientHelper
        {
            get
            {
                if (BindingContext == null) throw new System.InvalidOperationException();

                var model = BindingContext as Models.View.ClassicDeparturesPlacardViewModel;

                return new MOROPO.Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper(
                    string.Format("{0}://{1}/api/", model.UseSSL ? "https" : "http", model.APIServer),
                    null,
                    () => { return new KeyValuePair<string, string>[] { new KeyValuePair<string, string>(MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Constants.Authentication.API_KEY_HEADER_PROPERTY, model.APIKey) }; });
            }
        }

        #endregion
    }
}