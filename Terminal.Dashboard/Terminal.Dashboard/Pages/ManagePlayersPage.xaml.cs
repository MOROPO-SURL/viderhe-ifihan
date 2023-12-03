using MOROPO.VIDERHE.Cloud.Api.Common.Models;
using MOROPO.VIDERHE.Cloud.Api.Common.Models.Filter;
using MOROPO.VIDERHE.Cloud.SignalR.Connect.Common.Enumerations;
using MOROPO.VIDERHE.Support.Presentation.Dashboard.Presenters.Facade;
using MOROPO.VIDERHE.Support.Presentation.Helpers.Facade;
using MOROPO.VIDERHE.Terminal.Dashboard.Hubs.Client;
using MOROPO.VIDERHE.Terminal.Dashboard.Managers;
using MOROPO.VIDERHE.Terminal.Dashboard.Models.Page;
using MOROPO.VIDERHE.Terminal.Dashboard.Models.View;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;
using System.Linq;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Pages
{
    public partial class ManagePlayersPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<ManagePlayersPageModel>
    {
        private const string SCREENPLAY_HANDLING_MODE_CURRENT_FRAME_PRESENTATION_COMPLETE = "Completado el Cartel Actual";
        private const string SCREENPLAY_HANDLING_MODE_FRAMES_PRESENTATION_COMPLETE = "Completado el Ciclo Actual";
        private const string SCREENPLAY_HANDLING_MODE_IMMEDIATELY = "Inmediatamente";

        private const string PLAYER_HANDLING_RELAUNCH = "Relanzar";
        private const string PLAYER_HANDLING_CLOSE = "Cerrar";
        private const string PLAYER_HANDLING_SHUTDOWN = "Apagar";
        private const string PLAYER_HANDLING_RESTART = "Reiniciar";

        public ManagePlayersPage() : base(new ManagePlayersPageModel { IsBusy = true })
        {
            InitializeComponent();

            BindingContextPageModel.FilterParamaChangeCallbackAction = FilterChange_Callback;

            IsEnabled = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!IsEnabled)
            {
                IsEnabled = true;

                LoadPlayers();
            }
        }

        private void RequestFilterButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new Popup.FilterPlayerPopupPage(BindingContextPageModel.Filter, RequestFilterSuccess_Callback));
        }

        private void ClearFilterButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            DisplayAlert("Quitar Filtro", "Está seguro que desea quitar el filtro actual para el listado de Reproductores?", "Quitar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() => BindingContextPageModel.Filter = null);
            });
        }

        private void AddToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            this.NavigationPushPageAsync(new ConfigurePlayerPage(ReloadPlayers));
        }

        private void ReloadToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            ReloadPlayers();
        }

        private void PlayerNextButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            var model = (sender as Xamarin.Forms.Button).BindingContext as PlayerViewModel;

            DashboardHubClient.Instance.RequestPlayerPresentNextFrameAsync(new PlayerViewModel[] { model }).ContinueWith(hubTask =>
            {
                System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;

                    Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Reproducir Siguiente Cartel", "Solicitud de reproducción de siguiente cartel enviada con éxito.");
                });
            });
        }

        private void PlayerPreviousButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            var model = (sender as Xamarin.Forms.Button).BindingContext as PlayerViewModel;

            DashboardHubClient.Instance.RequestPlayerPresentPreviousFrameAsync(new PlayerViewModel[] { model }).ContinueWith(hubTask =>
            {
                System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;

                    Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Reproducir Cartel Anterior", "Solicitud de reproducción de cartel anterior enviada con éxito.");
                });
            });
        }

        private void PlayerInterventionButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.PlacardPickPage(PlayerIterventionPlacardPicked_Callback, (sender as Xamarin.Forms.Button).BindingContext as PlayerViewModel));
        }

        private void PlayerAudioEnabledSwitchButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            var model = (sender as Xamarin.Forms.Button).BindingContext as PlayerViewModel;

            DashboardHubClient.Instance.RequestPlayerSetAudioEnabledAsync(new PlayerViewModel[] { model }, !model.AudioEnabled).ContinueWith(hubTask =>
            {
                System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;
                });
            });
        }

        private void PlayerAudioVolumeUpButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            var model = (sender as Xamarin.Forms.Button).BindingContext as PlayerViewModel;

            DashboardHubClient.Instance.RequestPlayerAudioVolumeChangeAsync(new PlayerViewModel[] { model }, model.AudioLevel + 10).ContinueWith(hubTask =>
            {
                System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;
                });
            });
        }

        private void PlayerAudioVolumeDownButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            var model = (sender as Xamarin.Forms.Button).BindingContext as PlayerViewModel;

            DashboardHubClient.Instance.RequestPlayerAudioVolumeChangeAsync(new PlayerViewModel[] { model }, model.AudioLevel - 10).ContinueWith(hubTask =>
            {
                System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;
                });
            });
        }

        private void PlayerTerminateButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            var model = (sender as Xamarin.Forms.Button).BindingContext as PlayerViewModel;

            DisplayActionSheet("Dispositivo de Reproducción", "Cancelar", null, PLAYER_HANDLING_RESTART, PLAYER_HANDLING_SHUTDOWN).ContinueWith(shutdownModelPickDialogTask =>
            {
                if (shutdownModelPickDialogTask.Result == PLAYER_HANDLING_RESTART)
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        DisplayAlert("Confirmar", "Está seguro que desea reiniciar este dispositivo?", "Reiniciar", "Cancelar").ContinueWith(confirmationDialogTask =>
                        {
                            if (!confirmationDialogTask.Result) return;

                            DashboardHubClient.Instance.RequestPlayerTerminateAsync(new PlayerViewModel[] { model }, true).ContinueWith(hubTask =>
                            {
                                System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                                {
                                    (BindingContext as ManagePlayersPageModel).IsBusy = false;

                                    Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Reiniciar Dispositivo", "Solicitud de reinicio de dispositivo enviada con éxito.");
                                });
                            });
                        });
                    });

                    return;
                }

                if (shutdownModelPickDialogTask.Result == PLAYER_HANDLING_SHUTDOWN)
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        DisplayAlert("Confirmar", "Está seguro que desea apagar este dispositivo?", "Apagar", "Cancelar").ContinueWith(confirmationDialogTask =>
                        {
                            if (!confirmationDialogTask.Result) return;

                            DashboardHubClient.Instance.RequestPlayerTerminateAsync(new PlayerViewModel[] { model }, false).ContinueWith(hubTask =>
                            {
                                System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                                {
                                    (BindingContext as ManagePlayersPageModel).IsBusy = false;

                                    Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Apagar Dispositivo", "Solicitud de apagar dispositivo enviada con éxito.");
                                });
                            });
                        });
                    });

                    return;
                }

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;
                });
            });
        }

        private void PlayerCloseButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            var model = (sender as Xamarin.Forms.Button).BindingContext as PlayerViewModel;

            DisplayActionSheet("Aplicación de Reproducción", "Cancelar", null, PLAYER_HANDLING_RELAUNCH, PLAYER_HANDLING_CLOSE).ContinueWith(shutdownModelPickDialogTask =>
            {
                if (shutdownModelPickDialogTask.Result == PLAYER_HANDLING_RELAUNCH)
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        DisplayAlert("Confirmar", "Está seguro que desea reiniciar la aplicación?", "Reiniciar", "Cancelar").ContinueWith(confirmationDialogTask =>
                        {
                            if (!confirmationDialogTask.Result) return;

                            DashboardHubClient.Instance.RequestPlayerCloseAsync(new PlayerViewModel[] { model }, true).ContinueWith(hubTask =>
                            {
                                System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                                {
                                    (BindingContext as ManagePlayersPageModel).IsBusy = false;

                                    Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Reiniciar Aplicación", "Solicitud de reinicio de aplicación enviada con éxito.");
                                });
                            });
                        });
                    });

                    return;
                }

                if (shutdownModelPickDialogTask.Result == PLAYER_HANDLING_CLOSE)
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        DisplayAlert("Confirmar", "Está seguro que desea cerrar aplicación?", "Apagar", "Cancelar").ContinueWith(confirmationDialogTask =>
                        {
                            if (!confirmationDialogTask.Result) return;

                            DashboardHubClient.Instance.RequestPlayerCloseAsync(new PlayerViewModel[] { model }, false).ContinueWith(hubTask =>
                            {
                                System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                                {
                                    (BindingContext as ManagePlayersPageModel).IsBusy = false;

                                    Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Cerrar Aplicación", "Solicitud de cerrar aplicación enviada con éxito.");
                                });
                            });
                        });
                    });

                    return;
                }

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;
                });
            });
        }

        private void PlayerBackwardButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            var model = (sender as Xamarin.Forms.Button).BindingContext as PlayerViewModel;

            DisplayActionSheet("Reiniciar Guion", "Cancelar", null, SCREENPLAY_HANDLING_MODE_CURRENT_FRAME_PRESENTATION_COMPLETE, SCREENPLAY_HANDLING_MODE_IMMEDIATELY).ContinueWith(task =>
            {
                if (task.Result == SCREENPLAY_HANDLING_MODE_CURRENT_FRAME_PRESENTATION_COMPLETE)
                {
                    DashboardHubClient.Instance.RequestPlayerRestartScreenplayAsync(new PlayerViewModel[] { model }, ScreenplayHandlingImmediacyMode.CurrentFramePresentationComplete).ContinueWith(hubTask =>
                    {
                        System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                        Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                        {
                            (BindingContext as ManagePlayersPageModel).IsBusy = false;

                            Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Reiniciar Guion", "Solicitud de reinicio de Guion cuando termine el cartel actual enviada con éxito.");
                        });
                    });

                    return;
                }

                if (task.Result == SCREENPLAY_HANDLING_MODE_IMMEDIATELY)
                {
                    DashboardHubClient.Instance.RequestPlayerRestartScreenplayAsync(new PlayerViewModel[] { model }, ScreenplayHandlingImmediacyMode.Immediately).ContinueWith(hubTask =>
                    {
                        System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                        Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                        {
                            (BindingContext as ManagePlayersPageModel).IsBusy = false;

                            Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Reiniciar Guion", "Solicitud de reinicio de Guion inmediatamente enviada con éxito.");
                        });
                    });

                    return;
                }

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;
                });
            });
        }

        private void PlayerReloadButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            var model = (sender as Xamarin.Forms.Button).BindingContext as PlayerViewModel;

            DisplayActionSheet("Recargar Guion", "Cancelar", null, SCREENPLAY_HANDLING_MODE_FRAMES_PRESENTATION_COMPLETE, SCREENPLAY_HANDLING_MODE_CURRENT_FRAME_PRESENTATION_COMPLETE, SCREENPLAY_HANDLING_MODE_IMMEDIATELY).ContinueWith(task =>
            {
                if (task.Result == SCREENPLAY_HANDLING_MODE_FRAMES_PRESENTATION_COMPLETE)
                {
                    DashboardHubClient.Instance.RequestPlayerReloadScreenplayAsync(new PlayerViewModel[] { model }, ScreenplayHandlingImmediacyMode.FramesPresentationComplete).ContinueWith(hubTask =>
                    {
                        System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                        Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                        {
                            BindingContextPageModel.IsBusy = false;

                            Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Recargar Guion", "Solicitud de recarga de Guion cuando termine el ciclo actual enviada con éxito.");
                        });
                    });

                    return;
                }

                if (task.Result == SCREENPLAY_HANDLING_MODE_CURRENT_FRAME_PRESENTATION_COMPLETE)
                {
                    DashboardHubClient.Instance.RequestPlayerReloadScreenplayAsync(new PlayerViewModel[] { model }, ScreenplayHandlingImmediacyMode.CurrentFramePresentationComplete).ContinueWith(hubTask =>
                    {
                        System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                        Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                        {
                            BindingContextPageModel.IsBusy = false;

                            Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Recargar Guion", "Solicitud de recarga de Guion cuando termine el cartel actual enviada con éxito.");
                        });
                    });

                    return;
                }

                if (task.Result == SCREENPLAY_HANDLING_MODE_FRAMES_PRESENTATION_COMPLETE)
                {
                    DashboardHubClient.Instance.RequestPlayerReloadScreenplayAsync(new PlayerViewModel[] { model }, ScreenplayHandlingImmediacyMode.FramesPresentationComplete).ContinueWith(hubTask =>
                    {
                        System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                        Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                        {
                            BindingContextPageModel.IsBusy = false;

                            Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Recargar Guion", "Solicitud de recarga de Guion cuando termine el ciclo actual enviada con éxito.");
                        });
                    });

                    return;
                }

                if (task.Result == SCREENPLAY_HANDLING_MODE_IMMEDIATELY)
                {
                    DashboardHubClient.Instance.RequestPlayerReloadScreenplayAsync(new PlayerViewModel[] { model }, ScreenplayHandlingImmediacyMode.Immediately).ContinueWith(hubTask =>
                    {
                        System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                        Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                        {
                            BindingContextPageModel.IsBusy = false;

                            Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Recargar Guion", "Solicitud de recarga de Guion inmediatamente enviada con éxito.");
                        });
                    });

                    return;
                }

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;
                });
            });
        }

        private void PlayersNextButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            var models = BindingContextPageModel.Items.Where(item => item.IsConnected && item.IsEnabled).ToArray();

            if (models.Length <= 0)
            {
                DisplayAlert("Aviso", "Ninguno de los dispositivos listados está en condiciones de recibir esta orden.", "Aceptar");

                return;
            }

            DashboardHubClient.Instance.RequestPlayerPresentNextFrameAsync(models).ContinueWith(hubTask =>
            {
                System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;

                    Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Reproducir Siguiente Cartel", "Solicitud de reproducción de siguiente cartel enviada con éxito.");
                });
            });
        }

        private void PlayersPreviousButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            var models = BindingContextPageModel.Items.Where(item => item.IsConnected && item.IsEnabled).ToArray();

            if (models.Length <= 0)
            {
                DisplayAlert("Aviso", "Ninguno de los dispositivos listados está en condiciones de recibir esta orden.", "Aceptar");

                return;
            }

            DashboardHubClient.Instance.RequestPlayerPresentPreviousFrameAsync(models).ContinueWith(hubTask =>
            {
                System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;

                    Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Reproducir Cartel Anterior", "Solicitud de reproducción de cartel anterior enviada con éxito.");
                });
            });
        }

        private void PlayersInterventionButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            var models = BindingContextPageModel.Items.Where(item => item.IsConnected && item.IsEnabled).ToArray();

            if (models.Length <= 0)
            {
                DisplayAlert("Aviso", "Ninguno de los dispositivos listados está en condiciones de recibir esta orden.", "Aceptar");

                return;
            }

            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.PlacardPickPage(PlayersIterventionPlacardPicked_Callback, null));
        }

        private void PlayersAudioEnabledSwitchButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            var models = BindingContextPageModel.Items.Where(item => item.IsConnected && item.IsEnabled).ToArray();

            if (models.Length <= 0)
            {
                DisplayAlert("Aviso", "Ninguno de los dispositivos listados está en condiciones de recibir esta orden.", "Aceptar");

                return;
            }

            BindingContextPageModel.IsGlobalAudioEnabled = !BindingContextPageModel.IsGlobalAudioEnabled;

            DashboardHubClient.Instance.RequestPlayerSetAudioEnabledAsync(models, BindingContextPageModel.IsGlobalAudioEnabled).ContinueWith(hubTask =>
            {
                System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;
                });
            });
        }

        private void PlayersTerminateButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            var models = BindingContextPageModel.Items.Where(item => item.IsConnected && item.IsEnabled).ToArray();

            if (models.Length <= 0)
            {
                DisplayAlert("Aviso", "Ninguno de los dispositivos listados está en condiciones de recibir esta orden.", "Aceptar");

                return;
            }

            DisplayActionSheet("Dispositivos de Reproducción", "Cancelar", null, PLAYER_HANDLING_RESTART, PLAYER_HANDLING_SHUTDOWN).ContinueWith(shutdownModelPickDialogTask =>
            {
                if (shutdownModelPickDialogTask.Result == PLAYER_HANDLING_RESTART)
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        DisplayAlert("Confirmar", "Está seguro que desea reiniciar estos dispositivos?", "Reiniciar", "Cancelar").ContinueWith(confirmationDialogTask =>
                        {
                            if (!confirmationDialogTask.Result) return;

                            DashboardHubClient.Instance.RequestPlayerTerminateAsync(models, true).ContinueWith(hubTask =>
                            {
                                System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                                {
                                    (BindingContext as ManagePlayersPageModel).IsBusy = false;

                                    Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Reiniciar Dispositivo", "Solicitud de reinicio de dispositivo enviada con éxito.");
                                });
                            });
                        });
                    });

                    return;
                }

                if (shutdownModelPickDialogTask.Result == PLAYER_HANDLING_SHUTDOWN)
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        DisplayAlert("Confirmar", "Está seguro que desea apagar estos dispositivos?", "Apagar", "Cancelar").ContinueWith(confirmationDialogTask =>
                        {
                            if (!confirmationDialogTask.Result) return;

                            DashboardHubClient.Instance.RequestPlayerTerminateAsync(models, false).ContinueWith(hubTask =>
                            {
                                System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                                {
                                    (BindingContext as ManagePlayersPageModel).IsBusy = false;

                                    Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Apagar Dispositivo", "Solicitud de apagar dispositivo enviada con éxito.");
                                });
                            });
                        });
                    });

                    return;
                }

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;
                });
            });
        }

        private void PlayersCloseButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            var models = BindingContextPageModel.Items.Where(item => item.IsConnected && item.IsEnabled).ToArray();

            if (models.Length <= 0)
            {
                DisplayAlert("Aviso", "Ninguno de los dispositivos listados está en condiciones de recibir esta orden.", "Aceptar");

                return;
            }

            DisplayActionSheet("Aplicación de Reproducción", "Cancelar", null, PLAYER_HANDLING_RELAUNCH, PLAYER_HANDLING_CLOSE).ContinueWith(shutdownModelPickDialogTask =>
            {
                if (shutdownModelPickDialogTask.Result == PLAYER_HANDLING_RELAUNCH)
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        DisplayAlert("Confirmar", "Está seguro que desea reiniciar la aplicación en estos dispositivos?", "Reiniciar", "Cancelar").ContinueWith(confirmationDialogTask =>
                        {
                            if (!confirmationDialogTask.Result) return;

                            DashboardHubClient.Instance.RequestPlayerCloseAsync(models, true).ContinueWith(hubTask =>
                            {
                                System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                                {
                                    (BindingContext as ManagePlayersPageModel).IsBusy = false;

                                    Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Reiniciar Aplicación", "Solicitud de reinicio de aplicación enviada con éxito.");
                                });
                            });
                        });
                    });

                    return;
                }

                if (shutdownModelPickDialogTask.Result == PLAYER_HANDLING_CLOSE)
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        DisplayAlert("Confirmar", "Está seguro que desea cerrar aplicación en estos dispositivos?", "Apagar", "Cancelar").ContinueWith(confirmationDialogTask =>
                        {
                            if (!confirmationDialogTask.Result) return;

                            DashboardHubClient.Instance.RequestPlayerCloseAsync(models, false).ContinueWith(hubTask =>
                            {
                                System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                                {
                                    (BindingContext as ManagePlayersPageModel).IsBusy = false;

                                    Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Cerrar Aplicación", "Solicitud de cerrar aplicación enviada con éxito.");
                                });
                            });
                        });
                    });

                    return;
                }

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;
                });
            });
        }

        private void PlayersBackwardButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            var models = BindingContextPageModel.Items.Where(item => item.IsConnected && item.IsEnabled).ToArray();

            if (models.Length <= 0)
            {
                DisplayAlert("Aviso", "Ninguno de los dispositivos listados está en condiciones de recibir esta orden.", "Aceptar");

                return;
            }

            DisplayActionSheet("Reiniciar Guion", "Cancelar", null, SCREENPLAY_HANDLING_MODE_CURRENT_FRAME_PRESENTATION_COMPLETE, SCREENPLAY_HANDLING_MODE_IMMEDIATELY).ContinueWith(task =>
            {
                if (task.Result == SCREENPLAY_HANDLING_MODE_CURRENT_FRAME_PRESENTATION_COMPLETE)
                {
                    DashboardHubClient.Instance.RequestPlayerRestartScreenplayAsync(models, ScreenplayHandlingImmediacyMode.CurrentFramePresentationComplete).ContinueWith(hubTask =>
                    {
                        System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                        Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                        {
                            (BindingContext as ManagePlayersPageModel).IsBusy = false;

                            Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Reiniciar Guion", "Solicitud de reinicio de Guion cuando termine el cartel actual enviada con éxito.");
                        });
                    });

                    return;
                }

                if (task.Result == SCREENPLAY_HANDLING_MODE_IMMEDIATELY)
                {
                    DashboardHubClient.Instance.RequestPlayerRestartScreenplayAsync(models, ScreenplayHandlingImmediacyMode.Immediately).ContinueWith(hubTask =>
                    {
                        System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                        Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                        {
                            (BindingContext as ManagePlayersPageModel).IsBusy = false;

                            Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Reiniciar Guion", "Solicitud de reinicio de Guion inmediatamente enviada con éxito.");
                        });
                    });

                    return;
                }

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;
                });
            });
        }

        private void PlayersReloadButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            var models = BindingContextPageModel.Items.Where(item => item.IsConnected && item.IsEnabled).ToArray();

            if (models.Length <= 0)
            {
                DisplayAlert("Aviso", "Ninguno de los dispositivos listados está en condiciones de recibir esta orden.", "Aceptar");

                return;
            }

            DisplayActionSheet("Recargar Guion", "Cancelar", null, SCREENPLAY_HANDLING_MODE_FRAMES_PRESENTATION_COMPLETE, SCREENPLAY_HANDLING_MODE_CURRENT_FRAME_PRESENTATION_COMPLETE, SCREENPLAY_HANDLING_MODE_IMMEDIATELY).ContinueWith(task =>
            {
                if (task.Result == SCREENPLAY_HANDLING_MODE_FRAMES_PRESENTATION_COMPLETE)
                {
                    DashboardHubClient.Instance.RequestPlayerReloadScreenplayAsync(models, ScreenplayHandlingImmediacyMode.FramesPresentationComplete).ContinueWith(hubTask =>
                    {
                        System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                        Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                        {
                            BindingContextPageModel.IsBusy = false;

                            Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Recargar Guion", "Solicitud de recarga de Guion cuando termine el ciclo actual enviada con éxito.");
                        });
                    });

                    return;
                }

                if (task.Result == SCREENPLAY_HANDLING_MODE_CURRENT_FRAME_PRESENTATION_COMPLETE)
                {
                    DashboardHubClient.Instance.RequestPlayerReloadScreenplayAsync(models, ScreenplayHandlingImmediacyMode.CurrentFramePresentationComplete).ContinueWith(hubTask =>
                    {
                        System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                        Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                        {
                            BindingContextPageModel.IsBusy = false;

                            Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Recargar Guion", "Solicitud de recarga de Guion cuando termine el cartel actual enviada con éxito.");
                        });
                    });

                    return;
                }

                if (task.Result == SCREENPLAY_HANDLING_MODE_FRAMES_PRESENTATION_COMPLETE)
                {
                    DashboardHubClient.Instance.RequestPlayerReloadScreenplayAsync(models, ScreenplayHandlingImmediacyMode.FramesPresentationComplete).ContinueWith(hubTask =>
                    {
                        System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                        Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                        {
                            BindingContextPageModel.IsBusy = false;

                            Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Recargar Guion", "Solicitud de recarga de Guion cuando termine el ciclo actual enviada con éxito.");
                        });
                    });

                    return;
                }

                if (task.Result == SCREENPLAY_HANDLING_MODE_IMMEDIATELY)
                {
                    DashboardHubClient.Instance.RequestPlayerReloadScreenplayAsync(models, ScreenplayHandlingImmediacyMode.Immediately).ContinueWith(hubTask =>
                    {
                        System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                        Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                        {
                            BindingContextPageModel.IsBusy = false;

                            Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Recargar Guion", "Solicitud de recarga de Guion inmediatamente enviada con éxito.");
                        });
                    });

                    return;
                }

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;
                });
            });
        }

        private void PlayerOverviewEditButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            var model = (sender as Xamarin.Forms.ImageButton).BindingContext as PlayerViewModel;

            this.NavigationPushPageAsync(new ConfigurePlayerPage(ReloadPlayers, model));
        }

        private void PlayerOverviewDeleteButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            DisplayAlert("Confirmar", "Está seguro que desea eliminar este reproductor?", "Aceptar", "Cancelar").ContinueWith(async task =>
            {
                if (!task.Result) return;

                BindingContextPageModel.IsBusy = true;

                var client = new Cloud.Api.Connect.Clients.PlayersApiConnectClient(SessionManager.Instance);

                var target = (sender as Xamarin.Forms.BindableObject).BindingContext as PlayerViewModel;

                System.Exception failException = null;

                try
                {
                    await client.Delete(target.Id);
                }
                catch (System.Exception ex)
                {
                    failException = ex;
                }

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    if (failException == null)
                    {
                        BindingContextPageModel.Items.Remove(target);

                        Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Información", "Reproductor eliminado con éxito.");
                    }
                    else
                    {
                        (Xamarin.Forms.Application.Current as IExceptionHandleHelperFacade).HandleException(failException);
                    }

                    BindingContextPageModel.IsBusy = false;
                });
            });
        }

        private void PlayerIterventionPlacardPicked_Callback(PlacardDisplayModel target, object param)
        {
            DisplayAlert("Confirmar", string.Format("Esta seguro que desea intervenir este reproductor con el cartel titulado \"{0}\"?", target.Label), "Intervenir", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    DashboardHubClient.Instance.PlayerPresentInterventionPlacardAsync(new PlayerViewModel[] { param as PlayerViewModel }, target.Id).ContinueWith(hubTask =>
                    {
                        System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                        Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                        {
                            BindingContextPageModel.IsBusy = false;

                            Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Intervenir", "Solicitud de intervención con cartel enviada con éxito.");
                        });
                    });
                });
            });
        }

        private void PlayersIterventionPlacardPicked_Callback(PlacardDisplayModel target, object param)
        {
            DisplayAlert("Confirmar", string.Format("Esta seguro que desea intervenir este reproductor con el cartel titulado \"{0}\"?", target.Label), "Intervenir", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    DashboardHubClient.Instance.PlayerPresentInterventionPlacardAsync(BindingContextPageModel.Items.Where(item => item.IsConnected && item.IsEnabled).ToArray(), target.Id).ContinueWith(hubTask =>
                    {
                        System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                        Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                        {
                            BindingContextPageModel.IsBusy = false;

                            Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Intervenir", "Solicitud de intervención con cartel enviada con éxito.");
                        });
                    });
                });
            });
        }

        private void FilterChange_Callback()
        {
            if (BindingContextPageModel.Filter == null)
            {
                Title = "Reproductores";
            }
            else
            {
                Title = "Reproductores (filtrados)";
            }

            ReloadPlayers();
        }

        private void RequestFilterSuccess_Callback(PlayerFilterModel model)
        {
            BindingContextPageModel.Filter = model;
        }

        private void ReloadPlayers()
        {
            BindingContextPageModel.Items.Clear();

            LoadPlayers();
        }

        private void LoadPlayers()
        {
            BindingContextPageModel.IsBusy = true;

            var apiConnectClient = new Cloud.Api.Connect.Clients.PlayersApiConnectClient(SessionManager.Instance);

            System.Threading.Tasks.Task<PlayerDisplayModel[]> apiConnectClientTask;

            if (BindingContextPageModel.Filter != null)
            {
                apiConnectClientTask = apiConnectClient.FilterAsync(BindingContextPageModel.Filter);
            }
            else
            {
                apiConnectClientTask = apiConnectClient.GetAsync();
            }

            apiConnectClientTask.ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    if (task.Exception != null || task.IsCanceled)
                    {
                        (Xamarin.Forms.Application.Current as IExceptionHandleHelperFacade).HandleException(task.Exception);
                    }
                    else
                    {
                        foreach (var model in task.Result)
                        {
                            BindingContextPageModel.Items.Add(new Models.View.PlayerViewModel
                            {
                                Id = model.Id,
                                Name = model.Name,
                                About = model.About,
                                Screenplay = model.Screenplay,
                                IsConnected = model.IsConnected,
                                IsEnabled = model.IsConnected,
                                AudioLevel = model.AudioLevel,
                                AudioEnabled = model.AudioEnabled,
                                OverlayId = model.OverlayId,
                                SerializedOverlayContext = model.SerializedOverlayContext,
                                Tags = model.Tags
                            });
                        }

                        PlayerConnectionStatusChange_Callback();

                        DashboardHubClient.Instance.GetReady(BindingContextPageModel.Items, PlayerConnectionStatusChange_Callback);
                    }

                    BindingContextPageModel.IsBusy = false;
                });
            });
        }

        private void PlayerConnectionStatusChange_Callback()
        {
            var models = BindingContextPageModel.Items.Where(item => item.IsConnected && item.IsEnabled).ToArray();

            BindingContextPageModel.IsBatchActionEnabled = models.Length > 1;
        }
    }
}