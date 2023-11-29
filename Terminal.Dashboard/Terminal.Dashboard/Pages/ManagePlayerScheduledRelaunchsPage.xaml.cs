using MOROPO.VIDERHE.Cloud.Api.Common.Models;
using MOROPO.VIDERHE.Support.Presentation.Helpers.Facade;
using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Pages
{
    public partial class ManagePlayerScheduledRelaunchsPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.ManagePlayerScheduledRelaunchsPageModel>
    {
        public ManagePlayerScheduledRelaunchsPage(Models.View.PlayerViewModel player) : base(new Models.Page.ManagePlayerScheduledRelaunchsPageModel(player) { IsBusy = true })
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

                ReloadScheduledRelaunchs();
            }
        }

        private void AddToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new Popup.CreateScheduledRelaunchPopuoPage(BindingContextPageModel.Player, ReloadScheduledRelaunchs));
        }

        private void ReloadToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            ReloadScheduledRelaunchs();
        }

        private void ScheduledRelaunchDeleteView_Tapped(object sender, System.EventArgs eventArgs)
        {
            DisplayAlert("Confirmar", "Está seguro que desea eliminar este relanzamiento programando?", "Aceptar", "Cancelar").ContinueWith(dialogTask =>
            {
                if (!dialogTask.Result) return;

                BindingContextPageModel.IsBusy = true;

                var client = new Cloud.Api.Connect.Clients.ScheduledRelaunchsApiConnectClient(Managers.SessionManager.Instance);

                var target = (sender as Xamarin.Forms.BindableObject).BindingContext as ScheduledRelaunchDisplayModel;

                client.Delete(target.Id).ContinueWith(task =>
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        if (task.Exception != null || task.IsCanceled)
                        {
                            (Xamarin.Forms.Application.Current as IExceptionHandleHelperFacade).HandleException(task.Exception);
                        }
                        else
                        {
                            BindingContextPageModel.Items.Remove(target);
                        }

                        BindingContextPageModel.IsBusy = false;
                    });
                });
            });
        }

        private void ReloadScheduledRelaunchs()
        {
            BindingContextPageModel.Items.Clear();

            BindingContextPageModel.IsBusy = true;

            var client = new Cloud.Api.Connect.Clients.ScheduledRelaunchsApiConnectClient(Managers.SessionManager.Instance);

            client.FilterAsync(new Cloud.Api.Common.Models.Filter.ScheduledRelaunchFilterModel
            {
                PlayerId = BindingContextPageModel.Player.Id
            }).ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    if (task.Exception != null || task.IsCanceled)
                    {
                        (Xamarin.Forms.Application.Current as IExceptionHandleHelperFacade).HandleException(task.Exception);
                    }
                    else
                    {
                        var orderedModels = task.Result.OrderBy(item => item.Time);

                        foreach (var model in orderedModels)
                        {
                            BindingContextPageModel.Items.Add(model);
                        }
                    }

                    BindingContextPageModel.IsBusy = false;
                });
            });
        }
    }
}