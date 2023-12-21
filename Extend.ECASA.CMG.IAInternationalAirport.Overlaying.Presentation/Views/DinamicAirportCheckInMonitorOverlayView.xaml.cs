using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Extensions;
using SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations;
using SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations;
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

            PreCheckInHeadLabel.Text = overlayContextModel.PreCheckInHeadLabel;

            PrimaryChechInNumberBackgroundBoxView.Color = PrimaryGlobalClockBackgroundBoxView.Color = Xamarin.Forms.Color.FromHex(overlayContextModel.AccentColor);
            SecoundaryChechInNumberBackgroundBoxView.Color =SecoundaryGlobalClockBackgroundBoxView.Color = Xamarin.Forms.Color.FromHex(overlayContextModel.BackgroundColor);
            
            ChechInNumberLabel.Text = overlayContextModel.Number.ToString();
            ChechInNumberLabel.TextColor = Xamarin.Forms.Color.White;
            
            PrePresentationGrid.IsVisible = false;
            
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

            Xamarin.Forms.Device.StartTimer(System.TimeSpan.FromSeconds(15), Timer_Callback);

            Timer_Callback();
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

        private bool Timer_Callback()
        {
            var now = System.DateTime.Now;

            FullNowDateLabel.Text = now.ToString("dddd dd, MMMM, \\de yyyy");

            FullNowTimeLabel.Text = GlobalNowTimeLabel.Text = now.ToString("HH:mm");

            return overlayContextModel != null;
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

                PreCheckInHeadBackgroundBoxView.TranslationY = Height / 5 / 3 * -1;
                PreCheckInHeadBackgroundBoxView.IsVisible = false;
                PreCheckInHeadLabel.Opacity = 0;
                PrePresentationGrid.TranslationY = Height / 5;
                PreOperationCarrierImageView.Scale = 0;
                PreOperationCarrierName.Opacity = 0;
                PreOperationFly.Opacity = 0;
                PreOperationDestinationStackLayout.Opacity = 0;
                PreOperationStartAtStackLayout.Opacity = 0;

                PrePresentationGrid.IsVisible = true;

                var prePresentationGridShowInAnimationStoryboard = new Storyboard { IsParallel = false };

                var prePresentationGridTranslateToYAnimation = new TranslateToYAnimation
                {
                    Target = PrePresentationGrid,
                    TranslateY = 0,
                    Duration = "350",
                    EasingType = EasingType.SinOut
                };

                prePresentationGridTranslateToYAnimation.Completed += (sender, eventArgs) => PreCheckInHeadBackgroundBoxView.IsVisible = true;

                var preOperationDataAnimationScreenplay = new Storyboard { IsParallel = true };

                preOperationDataAnimationScreenplay.Animations.Add(new ScaleToAnimation
                {
                    Target = PreOperationCarrierImageView,
                    Scale = 1,
                    Duration = "350",
                    EasingType = EasingType.BounceOut
                });
                preOperationDataAnimationScreenplay.Animations.Add(new FadeToAnimation
                {
                    Target = PreOperationCarrierName,
                    Opacity = 1,
                    Delay = "350",
                    Duration = "350"
                });
                preOperationDataAnimationScreenplay.Animations.Add(new FadeToAnimation
                {
                    Target = PreOperationFly,
                    Opacity = 1,
                    Delay = "525",
                    Duration = "350"
                });
                preOperationDataAnimationScreenplay.Animations.Add(new FadeToAnimation
                {
                    Target = PreOperationDestinationStackLayout,
                    Opacity = 1,
                    Delay = "700",
                    Duration = "350"
                });
                preOperationDataAnimationScreenplay.Animations.Add(new FadeToAnimation
                {
                    Target = PreOperationStartAtStackLayout,
                    Opacity = 1,
                    Delay = "875",
                    Duration = "350"
                });

                prePresentationGridShowInAnimationStoryboard.Animations.Add(prePresentationGridTranslateToYAnimation);
                prePresentationGridShowInAnimationStoryboard.Animations.Add(new TranslateToYAnimation
                {
                    Target = PreCheckInHeadBackgroundBoxView,
                    TranslateY = 0,
                    Duration = "300",
                    EasingType = EasingType.CubicIn
                });
                prePresentationGridShowInAnimationStoryboard.Animations.Add(new FadeInAnimation
                {
                    Target = PreCheckInHeadLabel,
                    Direction = FadeDirection.Left,
                    Duration = "350",
                    EasingType= EasingType.CubicOut
                });
                prePresentationGridShowInAnimationStoryboard.Animations.Add(preOperationDataAnimationScreenplay);

                prePresentationGridShowInAnimationStoryboard.Begin();
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

                UpdateCheckInStatus();

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

        private void UpdateCheckInStatus()
        {
            CheckInStatusLabel.Text = overlayContextModel.ClosedCheckInLabel;

            if (checkInModel == null || !checkInModel.IsOpen) return;

            CheckInStatusLabel.Text = overlayContextModel.OpenCheckInLabel;

            if (System.DateTime.Now >= checkInModel.EndAt)
            {
                CheckInStatusLabel.Text = overlayContextModel.ClosedCheckInLabel;
            }
        }

        private System.Threading.Tasks.Task UpdateFullPresentationAsync()
        {
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

                UpdateCheckInStatus();
            });

            return System.Threading.Tasks.Task.CompletedTask;
        }

        private System.Threading.Tasks.Task UpdatePrePresentationAsync()
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
            });

            return System.Threading.Tasks.Task.CompletedTask;
        }

        private async void FetchCheckIns_Callback(System.Threading.Tasks.Task<Service.ECASA.CMG.InterFIDS.API.Common.Models.CheckInDisplayModel[]> task)
        {
            if (overlayContextModel == null) return;

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            if (!task.IsCanceled && task.Exception == null)
            {
                checkInModel = task.Result.OrderBy(item => item.StartAt).FirstOrDefault();

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
                        else
                        {
                            await UpdateFullPresentationAsync();
                        }
                    }
                    else if (now >= checkInModel.StartAt - System.TimeSpan.FromMinutes(overlayContextModel.PrePresentationTime))
                    {
                        if (FullPresentationGrid.IsVisible) await HideFullPresentationAsync();

                        if (!PrePresentationGrid.IsVisible)
                        {
                            await ShowPrePresentationAsync();
                        }
                        else
                        {
                            await UpdatePrePresentationAsync();
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