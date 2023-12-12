using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Overlaying.Presentation.Views
{
    public partial class DinamicAirportCheckInMonitorOverlayView : Common.Overlaying.Presentation.Views.BaseOverlayView, Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade
    {
        private Models.Context.DinamicAirportCheckInMonitorOverlayContextModel overlayContextModel;

        private Service.ECASA.CMG.InterFIDS.API.Common.Models.CheckInDisplayModel checkInModel;

        public DinamicAirportCheckInMonitorOverlayView(Models.Context.DinamicAirportCheckInMonitorOverlayContextModel overlayContextModel)
        {
            InitializeComponent();

            this.overlayContextModel = overlayContextModel;

            PrimaryChechInNumberBackgroundBoxView.Color = Xamarin.Forms.Color.FromHex(overlayContextModel.AccentColor);
            SecoundaryChechInNumberBackgroundBoxView.Color = Xamarin.Forms.Color.FromHex(overlayContextModel.BackgroundColor);
            
            ChechInNumberLabel.Text = overlayContextModel.Number.ToString();
            ChechInNumberLabel.TextColor = Xamarin.Forms.Color.White;
            
            PrePresentationGrid.IsVisible = false;
            PrePresentationGrid.BackgroundColor = Xamarin.Forms.Color.White;
            
            FullPresentationGrid.IsVisible = false;
            FullPresentationGrid.BackgroundColor = Xamarin.Forms.Color.FromHex(overlayContextModel.AccentColor);

            var client = new Service.ECASA.CMG.InterFIDS.API.Connect.Frontend.Clients.CheckInsAPIConnectClient(this);

            System.Threading.Tasks.Task.Delay(System.TimeSpan.FromSeconds(10)).ContinueWith(delayTask =>
            {
                client.FilterAsync(new Service.ECASA.CMG.InterFIDS.API.Common.Models.Filter.CheckInFilterModel
                {
                    KioskNumber = overlayContextModel.Number,
                }).ContinueWith(FetchCheckIns_Callback);
            });

            if (Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.Android)
            {
                BindingContext = overlayContextModel.Number >= 10 ? 168 : 192;
            }
            else
            {
                BindingContext = overlayContextModel.Number >= 10 ? 168 : 216;
            }

            // TODO Remove block!!
            NowDateLabel.Text = System.DateTime.Now.ToString("dddd dd, MMMM \\de yyyy");

            NowTimeLabel.Text = System.DateTime.Now.ToString("HH:mm");
        } 

        public override void ShowOut()
        {
            // Allways visible!
        }

        public override void ShowIn()
        {            
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            overlayContextModel = null;
            checkInModel = null;
            PreOperationCarrierImageView.Source = null;
            FullOperationCarrierImageView.Source = null;
        }

        private System.Threading.Tasks.Task ShowPrePresentationAsync()
        {
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                PrePresentationGrid.BindingContext = checkInModel;

                if (checkInModel.Operation.Carrier.Image != null)
                {
                    PreOperationCarrierImageView.Source = checkInModel.Operation.Carrier.Image.ToImageSource(overlayContextModel);
                }
                else
                {
                    PreOperationCarrierImageView.Source = Xamarin.Forms.ImageSource.FromUri(new System.Uri(string.Format("{0}://{1}/images/default-carrier.jpg", "http", overlayContextModel.APIServer)));
                }

                PrePresentationGrid.IsVisible = true;
            });

            return System.Threading.Tasks.Task.CompletedTask;
        }

        private System.Threading.Tasks.Task HidePrePresentationAsync()
        {
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                PrePresentationGrid.BindingContext = null;

                PreOperationCarrierImageView.Source = null;

                PrePresentationGrid.IsVisible = false;
            });

            return System.Threading.Tasks.Task.CompletedTask;
        }

        private async System.Threading.Tasks.Task ShowFullPresentationAsync()
        {
            if (PrePresentationGrid.IsVisible) await HidePrePresentationAsync();

            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                FullPresentationGrid.BindingContext = checkInModel;

                if (checkInModel.Operation.Carrier.Image != null)
                {
                    FullOperationCarrierImageView.Source = checkInModel.Operation.Carrier.Image.ToImageSource(overlayContextModel);
                }
                else
                {
                    FullOperationCarrierImageView.Source = Xamarin.Forms.ImageSource.FromUri(new System.Uri(string.Format("{0}://{1}/images/default-carrier.jpg", "http", overlayContextModel.APIServer)));
                }

                FullPresentationGrid.IsVisible = true;
            });
        }

        private System.Threading.Tasks.Task HideFullPresentationAsync()
        {
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                FullPresentationGrid.BindingContext = null;

                FullOperationCarrierImageView.Source = null;

                FullPresentationGrid.IsVisible = false;
            });

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
            if (overlayContextModel == null) return;

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            if (!task.IsCanceled && task.Exception == null)
            {
                checkInModel = task.Result.OrderBy(item => item.StartAt).FirstOrDefault();

                //Xamarin.Forms.Device.BeginInvokeOnMainThread(() => BindingContext = checkInModel);

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
                        if (FullPresentationGrid.IsVisible) await HideFullPresentationAsync();

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