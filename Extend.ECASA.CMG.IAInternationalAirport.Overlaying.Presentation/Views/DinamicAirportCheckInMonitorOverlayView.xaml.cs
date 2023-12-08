using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Overlaying.Presentation.Views
{
    public partial class DinamicAirportCheckInMonitorOverlayView : Common.Overlaying.Presentation.Views.BaseOverlayView, Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade
    {
        private static Common.Templating.Presentation.Converters.SizeToRelativeValueConverter SIZE_TO_RELATIVE_VALUE_CONVERTER = new Common.Templating.Presentation.Converters.SizeToRelativeValueConverter();

        private Models.Context.DinamicAirportCheckInMonitorOverlayContextModel overlayContextModel;

        private Service.ECASA.CMG.InterFIDS.API.Common.Models.CheckInDisplayModel checkInModel;

        public DinamicAirportCheckInMonitorOverlayView(Models.Context.DinamicAirportCheckInMonitorOverlayContextModel overlayContextModel)
        {
            InitializeComponent();

            this.overlayContextModel = overlayContextModel;

            var expectedWidth = Xamarin.Forms.Application.Current.MainPage.Width / 5;

            CallToActionMessageWrapGrid.WidthRequest = expectedWidth;
            CallToActionMessageWrapGrid.HeightRequest = expectedWidth;

            CallToActionMessageBackgroundBoxView.Color = Xamarin.Forms.Color.FromHex(overlayContextModel.AccentColor);
            CallToActionMessageBackgroundBoxView.CornerRadius = new Xamarin.Forms.CornerRadius(0, expectedWidth * 0.85, 0, 0);

            var labelPaddingComponent = expectedWidth * 2d / 3d * 0.2;

            CallToActionMessageLabel.Text = overlayContextModel.Number.ToString();
            CallToActionMessageLabel.TextColor = Xamarin.Forms.Color.White;
            CallToActionMessageLabel.FontAttributes = Xamarin.Forms.FontAttributes.Bold;
            CallToActionMessageLabel.FontSize = overlayContextModel.Number >= 10 ? (double)SIZE_TO_RELATIVE_VALUE_CONVERTER.Convert(210, typeof(double), null, CultureInfo.InvariantCulture) : (double)SIZE_TO_RELATIVE_VALUE_CONVERTER.Convert(280, typeof(double), null, CultureInfo.InvariantCulture);
            CallToActionMessageLabel.Padding = new Xamarin.Forms.Thickness(labelPaddingComponent / 2, 0, 0, labelPaddingComponent * 1.5);

            PrePresentationGrid.IsVisible = false;
            PrePresentationGrid.BackgroundColor = Xamarin.Forms.Color.FromHex(overlayContextModel.BackgroundColor);
            PrePresentationGrid.VerticalOptions = Xamarin.Forms.LayoutOptions.End;
            PrePresentationGrid.HeightRequest = expectedWidth * 0.85;

            FullPresentationGrid.IsVisible = false;
            FullPresentationGrid.BackgroundColor = Xamarin.Forms.Color.FromHex(overlayContextModel.AccentColor);

            IsEnabled = false;
        }

        public override void ShowOut()
        {
            // Allways visible!
        }

        public override void ShowIn()
        {
            if (!IsEnabled)
            {
                IsEnabled = true;

                return;
            }

            var client = new Service.ECASA.CMG.InterFIDS.API.Connect.Frontend.Clients.CheckInsAPIConnectClient(this);

            client.FilterAsync(new Service.ECASA.CMG.InterFIDS.API.Common.Models.Filter.CheckInFilterModel
            {
                KioskNumber = overlayContextModel.Number,
            }).ContinueWith(FetchCheckIns_Callback);
        }

        private System.Threading.Tasks.Task ShowPrePresentationAsync()
        {
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() => PrePresentationGrid.IsVisible = true);

            return System.Threading.Tasks.Task.CompletedTask;
        }

        private System.Threading.Tasks.Task HidePrePresentationAsync()
        {
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() => PrePresentationGrid.IsVisible = false);

            return System.Threading.Tasks.Task.CompletedTask;
        }

        private async System.Threading.Tasks.Task ShowFullPresentationAsync()
        {
            if (PrePresentationGrid.IsVisible) await HidePrePresentationAsync();

            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                PrePresentationGrid.IsVisible = false;

                FullPresentationGrid.IsVisible = true;
            });
        }

        private System.Threading.Tasks.Task HideFullPresentationAsync()
        {
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() => FullPresentationGrid.IsVisible = false);

            return System.Threading.Tasks.Task.CompletedTask;
        }

        //private System.Threading.Tasks.Task UpdateFullPresentationAsync()
        //{
        //    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
        //    {

        //    });

        //    return System.Threading.Tasks.Task.CompletedTask;
        //}
        
        //private System.Threading.Tasks.Task UpdatePrePresentationAsync()
        //{
        //    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
        //    {

        //    });

        //    return System.Threading.Tasks.Task.CompletedTask;
        //}

        private async void FetchCheckIns_Callback(System.Threading.Tasks.Task<Service.ECASA.CMG.InterFIDS.API.Common.Models.CheckInDisplayModel[]> task)
        {
            if (BindingContext == null) return;

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            if (!task.IsCanceled && task.Exception == null)
            {
                checkInModel = task.Result.OrderBy(item => item.StartAt).FirstOrDefault();

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() => BindingContext = checkInModel);

                if (checkInModel != null)
                {
                    var now = System.DateTime.Now;

                    if (now > checkInModel.EndAt + System.TimeSpan.FromMinutes(overlayContextModel.PostPresentationTime))
                    {
                        if (FullPresentationGrid.IsVisible)
                        {
                            await HideFullPresentationAsync();
                        }
                    }
                    else if (now >= checkInModel.StartAt)
                    {
                        if (!FullPresentationGrid.IsVisible)
                        {
                            await ShowFullPresentationAsync();
                        }
                    }
                    else if (now >= checkInModel.StartAt - System.TimeSpan.FromMinutes(overlayContextModel.PrePresentationTime))
                    {
                        if (!PrePresentationGrid.IsVisible)
                        {
                            await ShowPrePresentationAsync();
                        }
                    }
                    else
                    {
                        if (FullPresentationGrid.IsVisible) await HideFullPresentationAsync();

                        if (PrePresentationGrid.IsVisible) await HidePrePresentationAsync();
                    }
                }
            }

            stopwatch.Stop();

            var client = new Service.ECASA.CMG.InterFIDS.API.Connect.Frontend.Clients.CheckInsAPIConnectClient(this);

            var delay = System.TimeSpan.FromSeconds(overlayContextModel.UpdateInterval) - stopwatch.Elapsed;

#pragma warning disable CS4014 // Dado que no se esperaba esta llamada, la ejecución del método actual continuará antes de que se complete la llamada
            if (delay <= System.TimeSpan.Zero)
            {
                client.FilterAsync(new Service.ECASA.CMG.InterFIDS.API.Common.Models.Filter.CheckInFilterModel
                {
                    KioskNumber = overlayContextModel.Number,
                }).ContinueWith(FetchCheckIns_Callback);
            }
            else
            {
                System.Threading.Tasks.Task.Delay(delay).ContinueWith(delayTask =>
                {
                    client.FilterAsync(new Service.ECASA.CMG.InterFIDS.API.Common.Models.Filter.CheckInFilterModel
                    {
                        KioskNumber = overlayContextModel.Number,
                    }).ContinueWith(FetchCheckIns_Callback);
                });
            }
#pragma warning restore CS4014 // Dado que no se esperaba esta llamada, la ejecución del método actual continuará antes de que se complete la llamada
        }

        #region IHttpClientHelperProviderFacade implementation

        public Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper HttpClientHelper
        {
            get
            {
                if (BindingContext == null) throw new System.InvalidOperationException();

                return new Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper(
                    string.Format("{0}://{1}/api/", overlayContextModel.UseSSL ? "https" : "http", overlayContextModel.APIServer),
                    null,
                    () => { return new KeyValuePair<string, string>[] { new KeyValuePair<string, string>(Service.ECASA.CMG.InterFIDS.API.Common.Constants.Authentication.API_KEY_HEADER_PROPERTY, overlayContextModel.APIKey) }; });
            }
        }

        #endregion
    }
}