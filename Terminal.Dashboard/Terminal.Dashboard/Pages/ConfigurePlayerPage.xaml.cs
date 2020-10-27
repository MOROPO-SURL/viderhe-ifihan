using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Videre.Terminal.Dashboard.Pages
{
    public partial class ConfigurePlayerPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.ConfigurePlayerPageModel>
    {
        private readonly bool editing;

        private System.Action successCallbackAction;

        public ConfigurePlayerPage(System.Action successCallbackAction, Models.View.PlayerViewModel model = null)
            : base(Factories.ConfigurePlayerPageModelFactory.Build(model))
        {
            InitializeComponent();

            this.successCallbackAction = successCallbackAction;

            editing = model != null;

            if (editing)
            {
                Title = "Editar Reproductor";
            }
            else
            {
                Title = "Agregar Reproductor";
            }

            IsEnabled = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!IsEnabled)
            {
                IsEnabled = true;

                System.Threading.Tasks.Task.Run(async () =>
                {
                    var client = new Cloud.Api.Connect.Clients.ScreenplaysApiClient(Managers.SessionManager.Instance);

                    return await client.GetPaginateAsync();
                }).ContinueWith(task =>
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        if (task.Exception != null || task.IsCanceled)
                        {
                            (Xamarin.Forms.Application.Current as Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade).HandleException(task.Exception);

                            successCallbackAction = null;

                            this.NavigationPopPageAsync();
                        }
                        else
                        {
                            var found = false;
                            var index = -1;

                            foreach (var item in task.Result.List)
                            {
                                BindingContextPageModel.Screenplays.Add(item);

                                if (!found)
                                {
                                    index++;

                                    found = BindingContextPageModel.Screenplay != null && item.Id == BindingContextPageModel.Screenplay.Id;
                                }
                            }

                            if (found) ScreenplayPicker.SelectedIndex = index;
                        }

                        BindingContextPageModel.IsBusy = false;
                    });
                });
            }
        }

        protected override bool OnBackButtonPressed()
        {
            CancelToolbarItem_Activated(this, System.EventArgs.Empty);

            return true;
        }

        private void ScreenplayPicker_SelectedIndexChanged(object target, System.EventArgs eventArgs)
        {
            BindingContextPageModel.Screenplay = (target as Xamarin.Forms.Picker).SelectedItem as Cloud.Api.Common.Models.ScreenplayDisplayModel;
        }

        private void SelectedScreenplayClearButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            ScreenplayPicker.SelectedIndex = -1;
        }

        private void ApplyToolbarItem_Activated(object sender, System.EventArgs eventArgs)
        {
            BindingContextPageModel.IsBusy = true;

            System.Threading.Tasks.Task.Run(async () =>
            {
                var client = new Cloud.Api.Connect.Clients.PlayersApiClient(Managers.SessionManager.Instance);

                var model = new Cloud.Api.Common.Models.PlayerInputModel
                {
                    Id = BindingContextPageModel.Id,
                    Name = BindingContextPageModel.Name,
                    About = BindingContextPageModel.About,
                    ScreenplayId = BindingContextPageModel.Screenplay?.Id ?? System.Guid.Empty
                };

                if (editing)
                {
                    await client.EditAsync(model);
                }
                else
                {
                    await client.CreateAsync(model);
                }
            }).ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    if (task.Exception == null && !task.IsCanceled)
                    {
                        Presenters.NotificationPresenter.Instance.PresentNotification("Información", "Cambios aplicados con éxito.");

                        this.NavigationPopPageAsync();
                    }
                    else
                    {
                        BindingContextPageModel.IsBusy = false;

                        (Xamarin.Forms.Application.Current as Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade).HandleException(task.Exception);
                    }
                });
            });
        }

        private void CancelToolbarItem_Activated(object sender, System.EventArgs eventArgs)
        {
            DisplayAlert("Confirmar", "Está seguro que desea regresar sin guardar los cambios?", "Regresar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    successCallbackAction = null;

                    this.NavigationPopPageAsync();
                });
            });
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            successCallbackAction?.Invoke();

            successCallbackAction = null;
        }
    }
}