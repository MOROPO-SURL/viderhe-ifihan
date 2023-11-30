using MOROPO.VIDERHE.Support.Presentation.Dashboard.Presenters.Facade;
using MOROPO.VIDERHE.Support.Presentation.Helpers.Facade;
using MOROPO.VIDERHE.Terminal.Dashboard.Managers;
using MOROPO.VIDERHE.Terminal.Dashboard.Models.Page;
using MOROPO.VIDERHE.Terminal.Dashboard.Models.View;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Pages
{
    public partial class ManageModeratorsPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<ManageModeratorsPageModel>
    {
        public ManageModeratorsPage() : base(new ManageModeratorsPageModel())
        {
            InitializeComponent();

            IsEnabled = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (IsEnabled) return;

            PresentAvailableModerators();

            IsEnabled = true;
        }

        private void AddToolbarItem_Clicked(object sender, System.EventArgs e)
        {
            if (BindingContextPageModel.IsBusy) return;

            this.NavigationPushPageAsync(new ConfigureModeratorPage(AvailableModeratorsChange_Callback));
        }

        private void ReloadToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            PresentAvailableModerators();
        }

        private void ActionFrame_Tapped(object sender, System.EventArgs eventArgs)
        {
            var target = (sender as Xamarin.Forms.BindableObject).BindingContext as ModeratorViewModel;

            ModeratorCollectionView.SelectedItems.Clear();

            if (target.IsCurrentUser)
            {
                Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new Popup.ModeratorDetailPopupPage(target, ModeratorRequireEdit_Callback));

                return;
            }

            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new Popup.ModeratorDetailPopupPage(target, ModeratorRequireEdit_Callback, ModeratorRequireDelete_Callback));
        }

        private void ModeratorRequireEdit_Callback(ModeratorViewModel target)
        {
            if (target.IsCurrentUser)
            {
                this.NavigationPushPageAsync(new EditUserProfilePage(AvailableModeratorsChange_Callback));

                return;
            }

            this.NavigationPushPageAsync(new ConfigureModeratorPage(AvailableModeratorsChange_Callback, target));
        }

        private void ModeratorRequireDelete_Callback(ModeratorViewModel target)
        {
            DisplayAlert("Confirmar", "Esta seguro que desea eliminar el usuario seleccionado?", "Eliminar", "Cancelar").ContinueWith(confirmationTask =>
            {
                if (!confirmationTask.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = true;
                });

                var client = new Cloud.Api.Connect.Clients.ModeratorsApiConnectClient(SessionManager.Instance);

                client.Delete(target.Model.Id).ContinueWith(apiConnectTask =>
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        BindingContextPageModel.IsBusy = false;

                        if (apiConnectTask.Exception != null || !apiConnectTask.IsCanceled)
                        {
                            Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Información", "Usuario eliminado con éxito.");

                            AvailableModeratorsChange_Callback();
                        }
                        else
                        {
                            (Xamarin.Forms.Application.Current as IExceptionHandleHelperFacade).HandleException(apiConnectTask.Exception);
                        }
                    });
                });
            });
        }

        private void AvailableModeratorsChange_Callback()
        {
            PresentAvailableModerators();
        }

        private void PresentAvailableModerators()
        {
            BindingContextPageModel.IsBusy = true;

            BindingContextPageModel.Items.Clear();

            var apiClientConnectclient = new Cloud.Api.Connect.Clients.ModeratorsApiConnectClient(SessionManager.Instance);

            apiClientConnectclient.GetAsync().ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;

                    if (task.Exception != null || task.IsCanceled)
                    {
                        (Xamarin.Forms.Application.Current as IExceptionHandleHelperFacade).HandleException(task.Exception);
                    }
                    else
                    {
                        foreach (var model in task.Result)
                        {
                            BindingContextPageModel.Items.Add(new Models.View.ModeratorViewModel { Model = model });
                        }
                    }
                });
            });
        }
    }
}