using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Pages
{
    public partial class ManageGradientsPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.ManageGradientsPageModel>
    {
        private int currentItemsPageNumber;

        public ManageGradientsPage() : base(new Models.Page.ManageGradientsPageModel { IsBusy = true })
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

        private void ItemDetailButton_Clicked(object sender, System.EventArgs e)
        {
            this.NavigationPushPageAsync(new ConfigureGradientPage(RequiredReload_Callback, (sender as Xamarin.Forms.BindableObject).BindingContext as Models.View.GradientViewModel));
        }

        private void ItemDeleteButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            DisplayAlert("Confirmar", "Está seguro que desea eliminar este gradiente?", "Aceptar", "Cancelar").ContinueWith(async task =>
            {
                if (!task.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = true;
                });

                var client = new Cloud.Api.Connect.Clients.GradientsApiConnectClient(Managers.SessionManager.Instance);

                System.Exception failException = null;

                try
                {
                    await client.Delete(((sender as Xamarin.Forms.BindableObject).BindingContext as Models.View.GradientViewModel).Id);
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

            this.NavigationPushPageAsync(new ConfigureGradientPage(RequiredReload_Callback));
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

            var apiConnectClient = new Cloud.Api.Connect.Clients.GradientsApiConnectClient(Managers.SessionManager.Instance);

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
                            BindingContextPageModel.Items.Add(new Models.View.GradientViewModel
                            {
                                Id = item.Id,
                                About = item.About,
                                CreateAt = item.CreateAt,
                                Source = MagicGradients.CssGradientSource.Parse(item.Data)
                            });
                        }

                        BindingContextPageModel.HasMoreItems = task.Result.HasNext && task.Result.List.Count > 0;
                    }
                });
            });
        }
    }
}