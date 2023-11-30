using MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.View;
using MOROPO.VIDERHE.Support.Presentation.Dashboard.Presenters.Facade;
using MOROPO.VIDERHE.Support.Presentation.Helpers.Facade;
using MOROPO.VIDERHE.Terminal.Dashboard.Managers;
using MOROPO.VIDERHE.Terminal.Dashboard.Models.Page;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Pages
{
    public partial class ManageTextsPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<ManageTextsPageModel>
    {
        private int currentItemsPageNumber;

        public ManageTextsPage() : base(new ManageTextsPageModel { IsBusy = true })
        {
            InitializeComponent();

            IsEnabled = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (IsEnabled) return;

            RequiredReload_Callback();

            IsEnabled = true;
        }

        private void ItemCopyButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            Xamarin.Essentials.Clipboard.SetTextAsync(((sender as Xamarin.Forms.BindableObject).BindingContext as TextViewModel).Content).ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    if (task.IsFaulted || task.IsCanceled)
                    {
                        DisplayAlert("Aviso", "No fue posible copiar el contenido del elemento especificado al portapapeles del sistema.", "Aceptar");

                        return;
                    }

                    Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Información", "Contenido del elemento especificado copiado al portapapeles del sistema con éxito.");
                });
            });
        }

        private void ItemDetailButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new ConfigureTextPage(RequiredReload_Callback, (sender as Xamarin.Forms.BindableObject).BindingContext as TextViewModel));
        }

        private void ItemDeleteButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            DisplayAlert("Confirmar", "Está seguro que desea eliminar este texto?", "Aceptar", "Cancelar").ContinueWith(async task =>
            {
                if (!task.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = true;
                });

                var client = new Cloud.Api.Connect.Clients.TextsApiConnectClient(SessionManager.Instance);

                System.Exception failException = null;

                try
                {
                    await client.Delete(((sender as Xamarin.Forms.BindableObject).BindingContext as TextViewModel).Id);
                }
                catch (System.Exception ex)
                {
                    failException = ex;
                }

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;

                    if (failException == null)
                    {
                        Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Información", "Gradiente eliminado con éxito.");

                        RequiredReload_Callback();
                    }
                    else
                    {
                        (Xamarin.Forms.Application.Current as IExceptionHandleHelperFacade).HandleException(failException);
                    }
                });
            });
        }

        private void AddToolbarItem_Activated(object sender, System.EventArgs e)
        {
            if (BindingContextPageModel.IsBusy) return;

            this.NavigationPushPageAsync(new ConfigureTextPage(RequiredReload_Callback));
        }

        private void ReloadToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            RequiredReload_Callback();
        }

        private void LoadNextPageButtton_Clicked(object sender, System.EventArgs eventArgs)
        {
            LoadNextItemsPage();
        }

        private void RequiredReload_Callback()
        {
            LoadNextItemsPage(true);
        }

        private void LoadNextItemsPage(bool restart = false)
        {
            BindingContextPageModel.IsBusy = true;

            if (restart) currentItemsPageNumber = 0;

            var apiConnectClient = new Cloud.Api.Connect.Clients.TextsApiConnectClient(SessionManager.Instance);

            apiConnectClient.GetPaginateAsync(++currentItemsPageNumber).ContinueWith(task =>
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
                        if (currentItemsPageNumber == 1)
                        {
                            BindingContextPageModel.Items.Clear();
                        }

                        foreach (var item in task.Result.List)
                        {
                            BindingContextPageModel.Items.Add(new Support.Presentation.Dashboard.Models.View.TextViewModel
                            {
                                Id = item.Id,
                                About = item.About,
                                CreateAt = item.CreateAt,
                                Content = item.Content
                            });
                        }

                        BindingContextPageModel.HasMoreItems = task.Result.HasNext && task.Result.List.Count > 0;
                    }
                });
            });
        }
    }
}