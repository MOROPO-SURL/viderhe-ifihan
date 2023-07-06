using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Pages
{
    public partial class ManageTextsPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.ManageTextsPageModel>
    {
        private int currentItemsPageNumber;

        public ManageTextsPage() : base(new Models.Page.ManageTextsPageModel { IsBusy = true })
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
            Xamarin.Essentials.Clipboard.SetTextAsync(((sender as Xamarin.Forms.BindableObject).BindingContext as Support.Presentation.Dashboard.Models.View.TextViewModel).Content).ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    if (task.IsFaulted || task.IsCanceled)
                    {
                        DisplayAlert("Aviso", "No fue posible copiar el contenido del elemento especificado al portapapeles del sistema.", "Aceptar");

                        return;
                    }

                    Xamarin.Forms.DependencyService.Get<Support.Presentation.Dashboard.Presenters.Facade.INotificationPresenterFacade>().PresentNotification("Información", "Contenido del elemento especificado copiado al portapapeles del sistema con éxito.");
                });
            });
        }

        private void ItemDetailButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new ConfigureTextPage(RequiredReload_Callback, (sender as Xamarin.Forms.BindableObject).BindingContext as Support.Presentation.Dashboard.Models.View.TextViewModel));
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

                var client = new Cloud.Api.Connect.Clients.TextsApiConnectClient(Managers.SessionManager.Instance);

                System.Exception failException = null;

                try
                {
                    await client.Delete(((sender as Xamarin.Forms.BindableObject).BindingContext as Support.Presentation.Dashboard.Models.View.TextViewModel).Id);
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
                        Xamarin.Forms.DependencyService.Get<Support.Presentation.Dashboard.Presenters.Facade.INotificationPresenterFacade>().PresentNotification("Información", "Gradiente eliminado con éxito.");

                        RequiredReload_Callback();
                    }
                    else
                    {
                        (Xamarin.Forms.Application.Current as Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade).HandleException(failException);
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

            var apiConnectClient = new Cloud.Api.Connect.Clients.TextsApiConnectClient(Managers.SessionManager.Instance);

            apiConnectClient.GetPaginateAsync(++currentItemsPageNumber).ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;

                    if (task.Exception != null || task.IsCanceled)
                    {
                        (Xamarin.Forms.Application.Current as Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade).HandleException(task.Exception);
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