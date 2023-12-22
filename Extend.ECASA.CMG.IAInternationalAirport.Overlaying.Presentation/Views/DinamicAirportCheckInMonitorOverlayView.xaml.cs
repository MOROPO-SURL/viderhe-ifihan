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

            FullNowDateLabel.Text = now.ToString("dddd dd, MMMM, yyyy");

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

                var showInAnimationStoryboard = new Storyboard { IsParallel = false };

                var prePresentationGridTranslateToYAnimation = new TranslateToYAnimation
                {
                    Target = PrePresentationGrid,
                    TranslateY = 0,
                    Duration = "350",
                    EasingType = EasingType.CubicInOut
                };

                prePresentationGridTranslateToYAnimation.Completed += (sender, eventArgs) => PreCheckInHeadBackgroundBoxView.IsVisible = true;

                var preOperationDataAnimationScreenplay = new Storyboard { IsParallel = true };

                preOperationDataAnimationScreenplay.Animations.Add(new ScaleToAnimation
                {
                    Target = PreOperationCarrierImageView,
                    Scale = 1,
                    Duration = "350",
                    EasingType = EasingType.SpringOut
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

                showInAnimationStoryboard.Animations.Add(prePresentationGridTranslateToYAnimation);
                showInAnimationStoryboard.Animations.Add(new TranslateToYAnimation
                {
                    Target = PreCheckInHeadBackgroundBoxView,
                    TranslateY = 0,
                    Duration = "300",
                    EasingType = EasingType.CubicIn
                });
                showInAnimationStoryboard.Animations.Add(new FadeInAnimation
                {
                    Target = PreCheckInHeadLabel,
                    Direction = FadeDirection.Left,
                    Duration = "350",
                    EasingType= EasingType.CubicOut
                });
                showInAnimationStoryboard.Animations.Add(preOperationDataAnimationScreenplay);

                showInAnimationStoryboard.Begin();
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

                FullPresentationGrid.TranslationY = Height * -1;
                FullPresentationCheckInSymbolLabel.Opacity = 0;
                FullPresentationCheckInLabel.Opacity = 0;
                FullPresentationCheckInDeskNumberLabel.Scale = 0;
                CheckInStatusBackgroundBoxView.Scale = 0;
                CheckInStatusLabel.Opacity = 0;
                FullOperationCarrierImageView.Scale = 0;
                FullOperationCarrierNameLabel.Opacity = 0;
                FullOperationFlyCaptionLabel.Opacity = 0;
                FullOperationFlyLabel.Opacity = 0;
                FullOperationDestinationCaptionLabel.Opacity = 0;
                FullOperationDestinationLabel.Opacity = 0;
                FullOperationStartAtCaptionLabel.Opacity = 0;
                FullOperationStartAtLabel.Opacity = 0;
                FullOperationEndAtCaptionLabel.Opacity = 0;
                FullOperationEndAtLabel.Opacity = 0;
                FullPresentationFooterSeparationBoxView.Opacity = 0;
                FullPresentationFooterStackLayout.Opacity = 0;

                FullPresentationGrid.IsVisible = true;

                var showInContinueAnimationStoryboard = new Storyboard { IsParallel = true };

                showInContinueAnimationStoryboard.Animations.Add(new FadeInAnimation
                {
                    Target = FullPresentationCheckInSymbolLabel,
                    Direction = FadeDirection.Down,
                    Duration = "400",
                    EasingType = EasingType.SpringOut
                });
                showInContinueAnimationStoryboard.Animations.Add(new FadeInAnimation
                {
                    Target = FullPresentationCheckInLabel,
                    Direction = FadeDirection.Down,
                    Duration = "400",
                    EasingType = EasingType.SpringOut,
                    Delay = "200"
                });
                showInContinueAnimationStoryboard.Animations.Add(new ScaleToAnimation
                {
                    Target = FullPresentationCheckInDeskNumberLabel,
                    Scale = 1,
                    Duration = "400",
                    EasingType = EasingType.SpringOut,
                    Delay = "100"
                });
                showInContinueAnimationStoryboard.Animations.Add(new ScaleToAnimation
                {
                    Target = CheckInStatusBackgroundBoxView,
                    Scale = 1,
                    Duration = "200",
                    EasingType = EasingType.SpringOut,
                    Delay = "400"
                });
                showInContinueAnimationStoryboard.Animations.Add(new FadeToAnimation
                {
                    Target = CheckInStatusLabel,
                    Opacity = 1,
                    Duration = "400",
                    Delay = "800"
                });
                showInContinueAnimationStoryboard.Animations.Add(new ScaleToAnimation
                {
                    Target = FullOperationCarrierImageView,
                    Scale = 1,
                    Duration = "400",
                    EasingType = EasingType.SpringOut,
                    Delay = "1200"
                });
                showInContinueAnimationStoryboard.Animations.Add(new FadeToAnimation
                {
                    Target = FullOperationCarrierNameLabel,
                    Opacity = 1,
                    Duration = "400",
                    Delay = "1600"
                });
                showInContinueAnimationStoryboard.Animations.Add(new FadeInAnimation
                {
                    Target = FullPresentationFooterSeparationBoxView,
                    Direction = FadeDirection.Up,
                    Duration = "400",
                    Delay = "800"
                });
                showInContinueAnimationStoryboard.Animations.Add(new FadeInAnimation
                {
                    Target = FullPresentationFooterStackLayout,
                    Direction = FadeDirection.Up,
                    Duration = "400",
                    Delay = "800"
                });
                showInContinueAnimationStoryboard.Animations.Add(new FadeToAnimation
                {
                    Target = FullOperationFlyLabel,
                    Opacity = 1,
                    Duration = "400",
                    Delay = "1800"
                });
                showInContinueAnimationStoryboard.Animations.Add(new FadeInAnimation
                {
                    Target = FullOperationDestinationCaptionLabel,
                    Direction = FadeDirection.Up,
                    Duration = "400",
                    Delay = "1900"
                });
                showInContinueAnimationStoryboard.Animations.Add(new FadeInAnimation
                {
                    Target = FullOperationDestinationLabel,
                    Direction = FadeDirection.Up,
                    Duration = "400",
                    Delay = "1900"
                });
                showInContinueAnimationStoryboard.Animations.Add(new FadeInAnimation
                {
                    Target = FullOperationStartAtCaptionLabel,
                    Direction = FadeDirection.Right,
                    Duration = "400",
                    Delay = "2000"
                });
                showInContinueAnimationStoryboard.Animations.Add(new FadeInAnimation
                {
                    Target = FullOperationStartAtLabel,
                    Direction = FadeDirection.Right,
                    Duration = "400",
                    Delay = "2000"
                });
                showInContinueAnimationStoryboard.Animations.Add(new FadeInAnimation
                {
                    Target = FullOperationEndAtCaptionLabel,
                    Direction = FadeDirection.Right,
                    Duration = "400",
                    Delay = "2100"
                });
                showInContinueAnimationStoryboard.Animations.Add(new FadeInAnimation
                {
                    Target = FullOperationEndAtLabel,
                    Direction = FadeDirection.Right,
                    Duration = "400",
                    Delay = "2100"
                });

                var showInAnimationStoryboard = new Storyboard { IsParallel = false };

                showInAnimationStoryboard.Animations.Add(new TranslateToYAnimation
                {
                    Target = FullPresentationGrid,
                    TranslateY = 0,
                    Duration = "500",
                    EasingType = EasingType.BounceOut
                });
                showInAnimationStoryboard.Animations.Add(showInContinueAnimationStoryboard);

                showInAnimationStoryboard.Begin();
            });
        }

        private System.Threading.Tasks.Task HideFullPresentationAsync()
        {
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                var lastAnimation = new TranslateToYAnimation
                {
                    Target = FullPresentationGrid,
                    TranslateY = Height * -1,
                    Duration = "500",
                    EasingType = EasingType.SpringOut,
                    Delay = "750"
                };

                lastAnimation.Completed += (sender, eventArgs) =>
                {
                    FullPresentationGrid.BindingContext = null;

                    FullOperationCarrierImageView.Source = null;

                    checkInModel = null;

                    FullPresentationGrid.IsVisible = false;
                };

                var showOutAnimationStoryboard = new Storyboard { IsParallel = true };

                showOutAnimationStoryboard.Animations.Add(new FadeOutAnimation
                {
                    Target = FullPresentationCheckInSymbolLabel,
                    Direction = FadeDirection.Up,
                    Duration = "200",
                    EasingType = EasingType.SpringOut,
                    Delay = "300"
                });
                showOutAnimationStoryboard.Animations.Add(new FadeOutAnimation
                {
                    Target = FullPresentationCheckInLabel,
                    Direction = FadeDirection.Up,
                    Duration = "200",
                    EasingType = EasingType.SpringOut,
                    Delay = "275"
                });
                showOutAnimationStoryboard.Animations.Add(new ScaleToAnimation
                {
                    Target = FullPresentationCheckInDeskNumberLabel,
                    Scale = 0,
                    Duration = "200",
                    EasingType = EasingType.SpringOut,
                    Delay = "350"
                });
                showOutAnimationStoryboard.Animations.Add(new ScaleToAnimation
                {
                    Target = CheckInStatusBackgroundBoxView,
                    Scale = 0,
                    Duration = "200",
                    EasingType = EasingType.SpringOut,
                    Delay = "250"
                });
                showOutAnimationStoryboard.Animations.Add(new FadeToAnimation
                {
                    Target = CheckInStatusLabel,
                    Opacity = 0,
                    Duration = "200",
                    Delay = "50"
                });
                showOutAnimationStoryboard.Animations.Add(new ScaleToAnimation
                {
                    Target = FullOperationCarrierImageView,
                    Scale = 0,
                    Duration = "200",
                    EasingType = EasingType.SpringOut,
                    Delay = "100"
                });
                showOutAnimationStoryboard.Animations.Add(new FadeToAnimation
                {
                    Target = FullOperationCarrierNameLabel,
                    Opacity = 0,
                    Duration = "200",
                    Delay = "175"
                });
                showOutAnimationStoryboard.Animations.Add(new FadeToAnimation
                {
                    Target = FullOperationFlyLabel,
                    Opacity = 0,
                    Duration = "200",
                    Delay = "175"
                });
                showOutAnimationStoryboard.Animations.Add(new FadeOutAnimation
                {
                    Target = FullPresentationFooterSeparationBoxView,
                    Direction = FadeDirection.Down,
                    Duration = "200",
                    Delay = "150"
                });
                showOutAnimationStoryboard.Animations.Add(new FadeOutAnimation
                {
                    Target = FullPresentationFooterStackLayout,
                    Direction = FadeDirection.Down,
                    Duration = "200",
                    Delay = "150"
                });
                showOutAnimationStoryboard.Animations.Add(new FadeOutAnimation
                {
                    Target = FullOperationDestinationCaptionLabel,
                    Direction = FadeDirection.Down,
                    Duration = "200",
                    Delay = "50"
                });
                showOutAnimationStoryboard.Animations.Add(new FadeOutAnimation
                {
                    Target = FullOperationDestinationLabel,
                    Direction = FadeDirection.Down,
                    Duration = "200",
                    Delay = "50"
                });
                showOutAnimationStoryboard.Animations.Add(new FadeOutAnimation
                {
                    Target = FullOperationStartAtCaptionLabel,
                    Direction = FadeDirection.Right,
                    Duration = "200",
                    Delay = "25"
                });
                showOutAnimationStoryboard.Animations.Add(new FadeOutAnimation
                {
                    Target = FullOperationStartAtLabel,
                    Direction = FadeDirection.Right,
                    Duration = "200",
                    Delay = "25"
                });
                showOutAnimationStoryboard.Animations.Add(new FadeOutAnimation
                {
                    Target = FullOperationEndAtCaptionLabel,
                    Direction = FadeDirection.Right,
                    Duration = "200"
                });
                showOutAnimationStoryboard.Animations.Add(new FadeOutAnimation
                {
                    Target = FullOperationEndAtLabel,
                    Direction = FadeDirection.Right,
                    Duration = "200"
                });

                showOutAnimationStoryboard.Animations.Add(lastAnimation);

                showOutAnimationStoryboard.Begin();
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
                var availableCheckIns = task.Result.OrderBy(item => item.StartAt);

                Service.ECASA.CMG.InterFIDS.API.Common.Models.CheckInDisplayModel prospect = null;

                foreach (var item in availableCheckIns)
                {
                    if (checkInModel != null && checkInModel.Id == item.Id)
                    {
                        prospect = item;

                        break;
                    }

                    if (System.DateTime.Now > item.EndAt + System.TimeSpan.FromMinutes(overlayContextModel.PostPresentationTime)) continue;

                    prospect = item;

                    break;
                }

                checkInModel = prospect;

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
                else
                {
                    if (FullPresentationGrid.IsVisible) await HideFullPresentationAsync();

                    if (PrePresentationGrid.IsVisible) await HidePrePresentationAsync();
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