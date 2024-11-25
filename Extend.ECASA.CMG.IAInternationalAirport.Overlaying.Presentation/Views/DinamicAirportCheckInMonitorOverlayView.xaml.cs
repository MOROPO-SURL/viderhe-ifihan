using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Extensions;
using SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations;
using SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Overlaying.Presentation.Views
{
    public partial class DinamicAirportCheckInMonitorOverlayView : Common.Overlaying.Presentation.Views.BaseOverlayView, Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade
    {
        private Service.ECASA.CMG.InterFIDS.API.Common.Models.CheckInDisplayModel checkInModel;

        public DinamicAirportCheckInMonitorOverlayView(Models.Context.DinamicAirportCheckInMonitorOverlayContextModel overlayContextModel)
        {
            InitializeComponent();

            PreCheckInHeadLabel.Text = overlayContextModel.PreCheckInHeadLabel;

            ChechInNumberBackgroundBoxView.Color = GlobalClockBackgroundBoxView.Color = Xamarin.Forms.Color.FromHex(overlayContextModel.PrimaryBackgroundColor);

            PreCheckInWrapperLayout.BackgroundColor = Xamarin.Forms.Color.FromHex(overlayContextModel.SecoundaryBackgroundColor);

            ChechInNumberLabel.Text = overlayContextModel.Number.ToString();
            ChechInNumberLabel.TextColor = Xamarin.Forms.Color.FromHex(overlayContextModel.AccentColor);
            
            PrePresentationGrid.IsVisible = false;
            
            FullPresentationGrid.IsVisible = false;
            FullPresentationGrid.BackgroundColor = ChechInNumberBackgroundBoxView.Color;

            var vectorSourceData = "<svg id=\"Capa_1\" data-name=\"Capa 1\" xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 152.08 152.08\"><style type=\"text/css\">.cls-1{fill:" + overlayContextModel.AccentColor + ";fill-rule:evenodd;}</style><path class=\"cls-1\" d=\"M631.26,585.3a16,16,0,1,0-16-16,16,16,0,0,0,16,16M543,645.18H656.82v11.4H543Zm113.85-5.71.06-41.94c0-4.76-3.17-6.53-7-6.53H622a21.62,21.62,0,0,0-14.23,5.63l-19.68,19-22.33-23.57,0,19.64,17.37,21.15c2.7,3.21,8,3.09,11.07.11l12.91-13,2.13,19.46Zm-96.77-59.79v39.74H545.82V579.68Zm-36.19-56.17H645.52a30.5,30.5,0,0,1,30.41,30.42V675.59H523.86Z\" transform=\"translate(-523.86 -523.51)\"/></svg>";

            FullPresentationCheckInSymbolImage.Source = FFImageLoading.Svg.Forms.SvgImageSource.FromSvgString(vectorSourceData);

            var client = new Service.ECASA.CMG.InterFIDS.API.Connect.Frontend.Clients.CheckInsAPIConnectClient(this);

            System.Threading.Tasks.Task.Delay(System.TimeSpan.FromSeconds(10)).ContinueWith(delayTask =>
            {
                client.FilterAsync(new Service.ECASA.CMG.InterFIDS.API.Common.Models.Filter.CheckInFilterModel
                {
                    Number = overlayContextModel.Number,
                }).ContinueWith(FetchCheckIns_Callback);
            });

            var bindingContextModel = new Models.View.AirportCheckInMonitorOverlayViewModel
            {
                OverlayContext = overlayContextModel
            };

            if (Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.Android)
            {
                bindingContextModel.NumberReferenceSize = overlayContextModel.Number >= 10 ? 168 : 192;
            }
            else
            {
                bindingContextModel.NumberReferenceSize = overlayContextModel.Number >= 10 ? 168 : 216;
            }

            BindingContext = bindingContextModel;

            GlobalClockWrapGrid.IsVisible = overlayContextModel.ShowClock;

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

            checkInModel = null;
            PreOperationCarrierImageView.Source = null;
            FullOperationCarrierImageView.Source = null;
        }

        private bool Timer_Callback()
        {
            var now = System.DateTime.Now;

            FullNowDateLabel.Text = now.ToString("dddd dd, MMMM, yyyy");

            FullNowTimeLabel.Text = GlobalNowTimeLabel.Text = now.ToString("HH:mm");

            return BindingContext != null;
        }

        private System.Threading.Tasks.Task ShowPrePresentationAsync()
        {
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                var concretBidingContext = BindingContext as Models.View.AirportCheckInMonitorOverlayViewModel;

                PrePresentationGrid.BindingContext = checkInModel;

                if (checkInModel.DepartureOperation.Carrier.Image != null)
                {
                    PreOperationCarrierImageView.Source = checkInModel.DepartureOperation.Carrier.Image.ToImageSource(concretBidingContext.OverlayContext);
                }
                else
                {
                    PreOperationCarrierImageView.Source = Xamarin.Forms.ImageSource.FromUri(new System.Uri(string.Format("{0}://{1}/images/default-carrier.jpg", "http", concretBidingContext.OverlayContext.APIServer)));
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
                var concretBidingContext = BindingContext as Models.View.AirportCheckInMonitorOverlayViewModel;

                FullPresentationGrid.BindingContext = checkInModel;

                if (checkInModel.DepartureOperation.Carrier.Image != null)
                {
                    FullOperationCarrierImageView.Source = checkInModel.DepartureOperation.Carrier.Image.ToImageSource(concretBidingContext.OverlayContext);
                }
                else
                {
                    FullOperationCarrierImageView.Source = Xamarin.Forms.ImageSource.FromUri(new System.Uri(string.Format("{0}://{1}/images/default-carrier.jpg", "http", concretBidingContext.OverlayContext.APIServer)));
                }

                UpdateCheckInStatus();

                FullPresentationGrid.TranslationY = Height * -1;
                FullPresentationCheckInSymbolImage.Opacity = 0;
                FullPresentationCheckInLabel.Opacity = 0;
                FullPresentationCheckInDeskNumberLabel.Scale = 0;
                CheckInStatusBackgroundBoxView.Scale = 0;
                CheckInStatusLabel.Opacity = 0;
                FullOperationCarrierImageView.Scale = 0;
                FullOperationCarrierNameLabel.Opacity = 0;
                FullOperationFlyWrapLayout.Opacity = 0;
                FullOperationDestinationWrapLayout.Opacity = 0;
                FullOperationStartAtWrapLayout.Opacity = 0;
                FullOperationEndAtWrapLayout.Opacity = 0;
                FullPresentationFooterSeparationBoxView.Opacity = 0;
                FullPresentationFooterStackLayout.Opacity = 0;

                FullPresentationGrid.IsVisible = true;

                var showInContinueAnimationStoryboard = new Storyboard { IsParallel = true };

                showInContinueAnimationStoryboard.Animations.Add(new FadeInAnimation
                {
                    Target = FullPresentationCheckInSymbolImage,
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
                showInContinueAnimationStoryboard.Animations.Add(new FadeInAnimation
                {
                    Target = FullOperationFlyWrapLayout,
                    Direction = FadeDirection.Left,
                    Duration = "400",
                    Delay = "1800"
                });
                showInContinueAnimationStoryboard.Animations.Add(new FadeInAnimation
                {
                    Target = FullOperationDestinationWrapLayout,
                    Direction = FadeDirection.Left,
                    Duration = "400",
                    Delay = "1900"
                });
                showInContinueAnimationStoryboard.Animations.Add(new FadeInAnimation
                {
                    Target = FullOperationStartAtWrapLayout,
                    Direction = FadeDirection.Left,
                    Duration = "400",
                    Delay = "2000"
                });
                showInContinueAnimationStoryboard.Animations.Add(new FadeInAnimation
                {
                    Target = FullOperationEndAtWrapLayout,
                    Direction = FadeDirection.Left,
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

                showInAnimationStoryboard.Begin().ContinueWith(_ => Xamarin.Forms.DependencyService.Get<Common.Templating.Presentation.Presenters.Facade.IOvarlablePresenter>().SuspendPresentation());
            });
        }

        private System.Threading.Tasks.Task HideFullPresentationAsync()
        {
            Xamarin.Forms.DependencyService.Get<Common.Templating.Presentation.Presenters.Facade.IOvarlablePresenter>().ResumePresentation();

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
                    Target = FullPresentationCheckInSymbolImage,
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
                    Target = FullOperationFlyWrapLayout,
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
                showOutAnimationStoryboard.Animations.Add(new FadeToAnimation
                {
                    Target = FullOperationDestinationWrapLayout,
                    Opacity = 0,
                    Duration = "200",
                    Delay = "50"
                });
                showOutAnimationStoryboard.Animations.Add(new FadeToAnimation
                {
                    Target = FullOperationStartAtWrapLayout,
                    Opacity = 0,
                    Duration = "200",
                    Delay = "25"
                });
                showOutAnimationStoryboard.Animations.Add(new FadeToAnimation
                {
                    Target = FullOperationEndAtWrapLayout,
                    Opacity = 0,
                    Duration = "200"
                });

                showOutAnimationStoryboard.Animations.Add(lastAnimation);

                showOutAnimationStoryboard.Begin();
            });

            return System.Threading.Tasks.Task.CompletedTask;
        }

        private void UpdateCheckInStatus()
        {
            var concretBidingContext = BindingContext as Models.View.AirportCheckInMonitorOverlayViewModel;

            CheckInStatusLabel.Text = concretBidingContext.OverlayContext.ClosedCheckInLabel;

            if (checkInModel == null || !checkInModel.IsOpen) return;

            CheckInStatusLabel.Text = concretBidingContext.OverlayContext.OpenCheckInLabel;

            if (System.DateTime.Now >= checkInModel.EndAt)
            {
                CheckInStatusLabel.Text = concretBidingContext.OverlayContext.ClosedCheckInLabel;
            }
        }

        private System.Threading.Tasks.Task UpdateFullPresentationAsync()
        {
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                var concretBidingContext = BindingContext as Models.View.AirportCheckInMonitorOverlayViewModel;

                FullPresentationGrid.BindingContext = checkInModel;

                if (checkInModel.DepartureOperation.Carrier.Image != null)
                {
                    FullOperationCarrierImageView.Source = checkInModel.DepartureOperation.Carrier.Image.ToImageSource(concretBidingContext.OverlayContext);
                }
                else
                {
                    FullOperationCarrierImageView.Source = Xamarin.Forms.ImageSource.FromUri(new System.Uri(string.Format("{0}://{1}/images/default-carrier.jpg", "http", concretBidingContext.OverlayContext.APIServer)));
                }

                UpdateCheckInStatus();
            });

            return System.Threading.Tasks.Task.CompletedTask;
        }

        private System.Threading.Tasks.Task UpdatePrePresentationAsync()
        {
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                var concretBidingContext = BindingContext as Models.View.AirportCheckInMonitorOverlayViewModel;

                PrePresentationGrid.BindingContext = checkInModel;

                if (checkInModel.DepartureOperation.Carrier.Image != null)
                {
                    PreOperationCarrierImageView.Source = checkInModel.DepartureOperation.Carrier.Image.ToImageSource(concretBidingContext.OverlayContext);
                }
                else
                {
                    PreOperationCarrierImageView.Source = Xamarin.Forms.ImageSource.FromUri(new System.Uri(string.Format("{0}://{1}/images/default-carrier.jpg", "http", concretBidingContext.OverlayContext.APIServer)));
                }
            });

            return System.Threading.Tasks.Task.CompletedTask;
        }

        private async void FetchCheckIns_Callback(System.Threading.Tasks.Task<Service.ECASA.CMG.InterFIDS.API.Common.Models.CheckInDisplayModel[]> task)
        {
            var concretBidingContext = BindingContext as Models.View.AirportCheckInMonitorOverlayViewModel;

            if (concretBidingContext.OverlayContext == null) return;

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            if (!task.IsCanceled && task.Exception == null)
            {
                var availableCheckIns = task.Result.OrderByDescending(item => item.StartAt);

                Service.ECASA.CMG.InterFIDS.API.Common.Models.CheckInDisplayModel prospect = null;

                var now = System.DateTime.Now;

                foreach (var item in availableCheckIns)
                {
                    if (item.StartAt <= now && item.EndAt >= now)
                    {
                        prospect = item;

                        break;
                    }

                    if (now >= item.StartAt - System.TimeSpan.FromMinutes(concretBidingContext.OverlayContext.PrePresentationTime) && now < item.StartAt)
                    {
                        prospect = item;

                        break;
                    }

                    if (now > item.EndAt && now <= item.EndAt + System.TimeSpan.FromMinutes(concretBidingContext.OverlayContext.PostPresentationTime))
                    {
                        prospect = item;

                        break;
                    }
                }

                checkInModel = prospect;

                if (checkInModel != null)
                {
                    var hideAll = true;

                    if (now > checkInModel.EndAt + System.TimeSpan.FromMinutes(concretBidingContext.OverlayContext.PostPresentationTime))
                    {
                        hideAll = false;

                        if (FullPresentationGrid.IsVisible)
                        {
                            await HideFullPresentationAsync();
                        }
                    }
                    
                    if (now >= checkInModel.StartAt)
                    {
                        hideAll = false;

                        if (!FullPresentationGrid.IsVisible)
                        {
                            await ShowFullPresentationAsync();
                        }
                        else
                        {
                            await UpdateFullPresentationAsync();
                        }
                    }
                    else if (now >= checkInModel.StartAt - System.TimeSpan.FromMinutes(concretBidingContext.OverlayContext.PrePresentationTime))
                    {
                        hideAll = false;

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
                    
                    if (hideAll)
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

            var delay = System.TimeSpan.FromSeconds(concretBidingContext.OverlayContext.UpdateInterval) - stopwatch.Elapsed;

#pragma warning disable CS4014 // Dado que no se esperaba esta llamada, la ejecución del método actual continuará antes de que se complete la llamada
            if (delay <= System.TimeSpan.Zero)
            {
                client.FilterAsync(new Service.ECASA.CMG.InterFIDS.API.Common.Models.Filter.CheckInFilterModel
                {
                    Number = concretBidingContext.OverlayContext.Number,
                }).ContinueWith(FetchCheckIns_Callback);
            }
            else
            {
                System.Threading.Tasks.Task.Delay(delay).ContinueWith(delayTask =>
                {
                    client.FilterAsync(new Service.ECASA.CMG.InterFIDS.API.Common.Models.Filter.CheckInFilterModel
                    {
                        Number = concretBidingContext.OverlayContext.Number,
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

                var concretBidingContext = BindingContext as Models.View.AirportCheckInMonitorOverlayViewModel;

                if (concretBidingContext.OverlayContext.UseSSL && concretBidingContext.OverlayContext.AllowAnyCertificate)
                {
                    return new Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper(
                        new System.Net.Http.HttpClientHandler
                        {
                            ServerCertificateCustomValidationCallback = (request, certificate, chain, errors) => true
                        },
                        string.Format("https://{0}/api/", concretBidingContext.OverlayContext.APIServer),
                        null,
                        () => { return new KeyValuePair<string, string>[] { new KeyValuePair<string, string>(Service.ECASA.CMG.InterFIDS.API.Common.Constants.Authentication.API_KEY_HEADER_PROPERTY, concretBidingContext.OverlayContext.APIKey) }; });;
                }

                return new Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper(
                    string.Format("{0}://{1}/api/", concretBidingContext.OverlayContext.UseSSL ? "https" : "http", concretBidingContext.OverlayContext.APIServer),
                    null,
                    () => { return new KeyValuePair<string, string>[] { new KeyValuePair<string, string>(Service.ECASA.CMG.InterFIDS.API.Common.Constants.Authentication.API_KEY_HEADER_PROPERTY, concretBidingContext.OverlayContext.APIKey) }; });
            }
        }

        #endregion
    }
}