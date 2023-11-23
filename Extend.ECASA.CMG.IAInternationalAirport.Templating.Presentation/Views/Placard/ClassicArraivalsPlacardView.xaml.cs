using SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Extensions;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Views.Placard
{
    public partial class ClassicArraivalsPlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView, Facade.IInteroperablePlacardFacade, MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade
    {
        private static Thickness TABLE_ITEM_MARGIN = new Thickness(12);

        private static Common.Templating.Presentation.Converters.SizeToRelativeValueConverter SIZE_TO_RELATIVE_VALUE_CONVERTER = new Common.Templating.Presentation.Converters.SizeToRelativeValueConverter();

        private readonly Models.View.Placard.ClassicOperationsPlacardViewModel model;

        private Label timeSizeReferenceLabel;

        public ClassicArraivalsPlacardView(Models.View.Placard.ClassicOperationsPlacardViewModel model)
        {
            InitializeComponent();

            BindingContext = model;

            ArraivalsLayout.BackgroundColor = model.TableBackgroundColor;

            TableHeaderGrid.BackgroundColor = model.TableHeaderBackgroundColor;

            var tableHeaderItemFontSize = (double)SIZE_TO_RELATIVE_VALUE_CONVERTER.Convert(model.TableHeaderFontSize, typeof(double), null, System.Globalization.CultureInfo.InvariantCulture);

            TableHeaderGrid.InitializeAsTableHeader(model.Columns, MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind.Arraival, TABLE_ITEM_MARGIN, model.TableHeaderTextColor, tableHeaderItemFontSize, out timeSizeReferenceLabel);
            
            this.model = model;
        }

        public override Layout<View> WrapLayout => Wrapper;

        public override View PlacardView => ArraivalsLayout;

        public override void ConfigureLayout(View view)
        {
            Grid.SetColumn(view, 0);
            Grid.SetRow(view, 0);
        }

        public override void PerformPlacardStarup()
        {
            base.PerformPlacardStarup();

            var client = new MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Connect.Frontend.Clients.OperationsAPIConnectClient(this);

            client.FilterAsync(new MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.Filter.OperationFilterModel
            {
                Kind = MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind.Arraival
            }).ContinueWith(FetchOperations_Callback);
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            timeSizeReferenceLabel = null;
        }

        private void FetchOperations_Callback(System.Threading.Tasks.Task<MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.OperationDisplayModel[]> task)
        {
            if (BindingContext == null) return;

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            if (!task.IsCanceled && task.Exception == null)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    TableBodyStackLayout.Children.Clear();
                });

                var tableBodyItemFontSize = SIZE_TO_RELATIVE_VALUE_CONVERTER.Convert(model.RowFontSize, typeof(double), null, System.Globalization.CultureInfo.InvariantCulture);

                foreach (var item in task.Result)
                {
                    System.Threading.Thread.Sleep(System.TimeSpan.FromMilliseconds(250));

                    Device.BeginInvokeOnMainThread(() =>
                    {
                        item.AttachTo(TableBodyStackLayout, TableHeaderGrid.ColumnDefinitions, model, TABLE_ITEM_MARGIN, (double)tableBodyItemFontSize, timeSizeReferenceLabel.Width);
                    });
                }
            }

            stopwatch.Stop();

            var client = new MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Connect.Frontend.Clients.OperationsAPIConnectClient(this);

            var delay = System.TimeSpan.FromSeconds(model.UpdateInterval) - stopwatch.Elapsed;

            if (delay <= System.TimeSpan.Zero)
            {
                client.FilterAsync(new MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.Filter.OperationFilterModel
                {
                    Kind = MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind.Arraival
                }).ContinueWith(FetchOperations_Callback);
            }
            else
            {
                System.Threading.Tasks.Task.Delay(delay).ContinueWith(delayTask =>
                {
                    client.FilterAsync(new MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.Filter.OperationFilterModel
                    {
                        Kind = MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind.Arraival
                    }).ContinueWith(FetchOperations_Callback);
                });
            }
        }

        #region IInteroperablePlacardFacade implementation

        public Models.View.Placard.Contract.AbstractInteroperablePlacardViewModel GetInteroperableModel()
        {
            return BindingContext as Models.View.Placard.Contract.AbstractInteroperablePlacardViewModel;
        }

        #endregion

        #region IHttpClientHelperProviderFacade implementation

        public MOROPO.Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper HttpClientHelper
        {
            get
            {
                if (BindingContext == null) throw new System.InvalidOperationException();

                return new MOROPO.Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper(
                    string.Format("{0}://{1}/api/", model.UseSSL ? "https" : "http", model.APIServer),
                    null,
                    () => { return new KeyValuePair<string, string>[] { new KeyValuePair<string, string>(MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Constants.Authentication.API_KEY_HEADER_PROPERTY, model.APIKey) }; });
            }
        }

        #endregion
    }
}