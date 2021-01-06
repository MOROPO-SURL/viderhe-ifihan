using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Videre.Terminal.Dashboard.Pages
{
    public partial class ManagePlayersPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.ManagePlayersPageModel>
    {
        private const string SCREENPLAY_HANDLING_MODE_CURRENT_FRAME_PRESENTATION_COMPLETE = "Completado el Marco Actual";
        private const string SCREENPLAY_HANDLING_MODE_FRAMES_PRESENTATION_COMPLETE = "Completado el Ciclo Actual";
        private const string SCREENPLAY_HANDLING_MODE_IMMEDIATELY = "Inmediatamente";

        private const string PLAYER_HANDLING_SHUTDOWN = "Apagar";
        private const string PLAYER_HANDLING_RESTART = "Reiniciar";

        public ManagePlayersPage() : base(new Models.Page.ManagePlayersPageModel { IsBusy = true })
        {
            InitializeComponent();

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

        private void AddToolbarItem_Activated(object sender, System.EventArgs e)
        {
            if (BindingContextPageModel.IsBusy) return;

            this.NavigationPushPageAsync(new ConfigurePlayerPage(ReloadPlayer));
        }

        private void PlayerNextButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            var model = (sender as Xamarin.Forms.Button).BindingContext as Models.View.PlayerViewModel;

            Hubs.Client.DashboardHubClient.Instance.RequestPlayerPresentNextFrameAsync(model.Id).ContinueWith(hubTask =>
            {
                System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;

                    Presenters.NotificationPresenter.Instance.PresentNotification("Reproducir Siguiente Marco", "Solicitud de reproducción de siguiente marco enviada con éxito.");
                });
            });
        }

        private void PlayerPreviousButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            var model = (sender as Xamarin.Forms.Button).BindingContext as Models.View.PlayerViewModel;

            Hubs.Client.DashboardHubClient.Instance.RequestPlayerPresentPreviousFrameAsync(model.Id).ContinueWith(hubTask =>
            {
                System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;

                    Presenters.NotificationPresenter.Instance.PresentNotification("Reproducir Marco Anterior", "Solicitud de reproducción de marco anterior enviada con éxito.");
                });
            });
        }

        private void PlayerAudioEnabledSwitchButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            var model = (sender as Xamarin.Forms.Button).BindingContext as Models.View.PlayerViewModel;

            Hubs.Client.DashboardHubClient.Instance.RequestPlayerSetAudioEnabledAsync(model.Id, !model.AudioEnabled).ContinueWith(hubTask =>
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

            var model = (sender as Xamarin.Forms.Button).BindingContext as Models.View.PlayerViewModel;

            Hubs.Client.DashboardHubClient.Instance.RequestPlayerAudioVolumeChangeAsync(model.Id, model.AudioLevel + 10).ContinueWith(hubTask =>
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

            var model = (sender as Xamarin.Forms.Button).BindingContext as Models.View.PlayerViewModel;

            Hubs.Client.DashboardHubClient.Instance.RequestPlayerAudioVolumeChangeAsync(model.Id, model.AudioLevel - 10).ContinueWith(hubTask =>
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

            var model = (sender as Xamarin.Forms.Button).BindingContext as Models.View.PlayerViewModel;

            DisplayActionSheet("Apagar Dispositivo", "Cancelar", null, PLAYER_HANDLING_RESTART, PLAYER_HANDLING_SHUTDOWN).ContinueWith(shutdownModelPickDialogTask =>
            {
                if (shutdownModelPickDialogTask.Result == PLAYER_HANDLING_RESTART)
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        DisplayAlert("Confirmar", "Está seguro que desea reiniciar este dispositivo?", "Reiniciar", "Cancelar").ContinueWith(confirmationDialogTask =>
                        {
                            if (!confirmationDialogTask.Result) return;

                            Hubs.Client.DashboardHubClient.Instance.RequestPlayerTerminateAsync(model.Id, true).ContinueWith(hubTask =>
                            {
                                System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                                {
                                    (BindingContext as Models.Page.ManagePlayersPageModel).IsBusy = false;

                                    Presenters.NotificationPresenter.Instance.PresentNotification("Reiniciar Dispositivo", "Solicitud de reinicio de dispositivo enviada con éxito.");
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

                            Hubs.Client.DashboardHubClient.Instance.RequestPlayerTerminateAsync(model.Id, false).ContinueWith(hubTask =>
                            {
                                System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                                {
                                    (BindingContext as Models.Page.ManagePlayersPageModel).IsBusy = false;

                                    Presenters.NotificationPresenter.Instance.PresentNotification("Apagar Dispositivo", "Solicitud de apagar dispositivo enviada con éxito.");
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

            var model = (sender as Xamarin.Forms.Button).BindingContext as Models.View.PlayerViewModel;

            DisplayActionSheet("Reiniciar Guión", "Cancelar", null, SCREENPLAY_HANDLING_MODE_CURRENT_FRAME_PRESENTATION_COMPLETE, SCREENPLAY_HANDLING_MODE_IMMEDIATELY).ContinueWith(task =>
            {
                if (task.Result == SCREENPLAY_HANDLING_MODE_CURRENT_FRAME_PRESENTATION_COMPLETE)
                {
                    Hubs.Client.DashboardHubClient.Instance.RequestPlayerRestarScreenplayAsync(model.Id, Cloud.SignalR.Connect.Common.Enumerations.ScreenplayHandlingImmediacyMode.CurrentFramePresentationComplete).ContinueWith(hubTask =>
                    {
                        System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                        Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                        {
                            (BindingContext as Models.Page.ManagePlayersPageModel).IsBusy = false;

                            Presenters.NotificationPresenter.Instance.PresentNotification("Reiniciar Guión", "Solicitud de reinicio de guión cuando termine el marco actual enviada con éxito.");
                        });
                    });

                    return;
                }

                if (task.Result == SCREENPLAY_HANDLING_MODE_IMMEDIATELY)
                {
                    Hubs.Client.DashboardHubClient.Instance.RequestPlayerRestarScreenplayAsync(model.Id, Cloud.SignalR.Connect.Common.Enumerations.ScreenplayHandlingImmediacyMode.Immediately).ContinueWith(hubTask =>
                    {
                        System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                        Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                        {
                            (BindingContext as Models.Page.ManagePlayersPageModel).IsBusy = false;

                            Presenters.NotificationPresenter.Instance.PresentNotification("Reiniciar Guión", "Solicitud de reinicio de guión inmediatamente enviada con éxito.");
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

            var model = (sender as Xamarin.Forms.Button).BindingContext as Models.View.PlayerViewModel;

            DisplayActionSheet("Recargar Guión", "Cancelar", null, SCREENPLAY_HANDLING_MODE_FRAMES_PRESENTATION_COMPLETE, SCREENPLAY_HANDLING_MODE_CURRENT_FRAME_PRESENTATION_COMPLETE, SCREENPLAY_HANDLING_MODE_IMMEDIATELY).ContinueWith(task =>
            {
                if (task.Result == SCREENPLAY_HANDLING_MODE_FRAMES_PRESENTATION_COMPLETE)
                {
                    Hubs.Client.DashboardHubClient.Instance.RequestPlayerReloadScreenplayAsync(model.Id, Cloud.SignalR.Connect.Common.Enumerations.ScreenplayHandlingImmediacyMode.FramesPresentationComplete).ContinueWith(hubTask =>
                    {
                        System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                        Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                        {
                            BindingContextPageModel.IsBusy = false;

                            Presenters.NotificationPresenter.Instance.PresentNotification("Recargar Guión", "Solicitud de recarga de guión cuando termine el ciclo actual enviada con éxito.");
                        });
                    });

                    return;
                }

                if (task.Result == SCREENPLAY_HANDLING_MODE_CURRENT_FRAME_PRESENTATION_COMPLETE)
                {
                    Hubs.Client.DashboardHubClient.Instance.RequestPlayerReloadScreenplayAsync(model.Id, Cloud.SignalR.Connect.Common.Enumerations.ScreenplayHandlingImmediacyMode.CurrentFramePresentationComplete).ContinueWith(hubTask =>
                    {
                        System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                        Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                        {
                            BindingContextPageModel.IsBusy = false;

                            Presenters.NotificationPresenter.Instance.PresentNotification("Recargar Guión", "Solicitud de recarga de guión cuando termine el marco actual enviada con éxito.");
                        });
                    });

                    return;
                }

                if (task.Result == SCREENPLAY_HANDLING_MODE_FRAMES_PRESENTATION_COMPLETE)
                {
                    Hubs.Client.DashboardHubClient.Instance.RequestPlayerReloadScreenplayAsync(model.Id, Cloud.SignalR.Connect.Common.Enumerations.ScreenplayHandlingImmediacyMode.FramesPresentationComplete).ContinueWith(hubTask =>
                    {
                        System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                        Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                        {
                            BindingContextPageModel.IsBusy = false;

                            Presenters.NotificationPresenter.Instance.PresentNotification("Recargar Guión", "Solicitud de recarga de guión cuando termine el ciclo actual enviada con éxito.");
                        });
                    });

                    return;
                }

                if (task.Result == SCREENPLAY_HANDLING_MODE_IMMEDIATELY)
                {
                    Hubs.Client.DashboardHubClient.Instance.RequestPlayerReloadScreenplayAsync(model.Id, Cloud.SignalR.Connect.Common.Enumerations.ScreenplayHandlingImmediacyMode.Immediately).ContinueWith(hubTask =>
                    {
                        System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                        Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                        {
                            BindingContextPageModel.IsBusy = false;

                            Presenters.NotificationPresenter.Instance.PresentNotification("Recargar Guión", "Solicitud de recarga de guión inmediatamente enviada con éxito.");
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
            this.NavigationPushPageAsync(new ConfigurePlayerPage(ReloadPlayer, (sender as Xamarin.Forms.BindableObject).BindingContext as Models.View.PlayerViewModel));
        }

        private void PlayerOverviewDeleteButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            DisplayAlert("Confirmar", "Está seguro que desea eliminar este reproductor?", "Aceptar", "Cancelar").ContinueWith(async task =>
            {
                if (!task.Result) return;

                BindingContextPageModel.IsBusy = true;

                var client = new Cloud.Api.Connect.Clients.PlayersApiClient(Managers.SessionManager.Instance);

                var target = (sender as Xamarin.Forms.BindableObject).BindingContext as Models.View.PlayerViewModel;

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

                        Presenters.NotificationPresenter.Instance.PresentNotification("Información", "Reproductor eliminado con éxito.");
                    }
                    else
                    {
                        (Xamarin.Forms.Application.Current as Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade).HandleException(failException);
                    }

                    BindingContextPageModel.IsBusy = false;
                });
            });
        }

        private void ReloadPlayer()
        {
            BindingContextPageModel.Items.Clear();

            LoadPlayers();
        }

        private void LoadPlayers()
        {
            BindingContextPageModel.IsBusy = true;

            System.Threading.Tasks.Task.Run(async () =>
            {
                var client = new Cloud.Api.Connect.Clients.PlayersApiClient(Managers.SessionManager.Instance);

                return await client.GetPaginateAsync();
            }).ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    if (task.Exception != null || task.IsCanceled)
                    {
                        (Xamarin.Forms.Application.Current as Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade).HandleException(task.Exception);
                    }
                    else
                    {
                        foreach (var model in task.Result.List)
                        {
                            BindingContextPageModel.Items.Add(new Models.View.PlayerViewModel
                            {
                                Id = model.Id,
                                Name = model.Name,
                                About = model.About,
                                Screenplay = model.Screenplay,
                                IsConnected = model.IsConnected,
                                AudioLevel = model.AudioLevel,
                                AudioEnabled = model.AudioEnabled
                            });
                        }

                        Hubs.Client.DashboardHubClient.Instance.GetReady(BindingContextPageModel.Items);
                    }

                    BindingContextPageModel.IsBusy = false;
                });
            });
        }
    }
}