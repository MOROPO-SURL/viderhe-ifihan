using MOROPO.VIDERHE.Cloud.Api.Common.Models;
using MOROPO.VIDERHE.Cloud.Persistence.Enumerations;
using MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.Page;
using MOROPO.VIDERHE.Support.Presentation.Dashboard.Presenters.Facade;
using MOROPO.VIDERHE.Support.Presentation.Helpers.Facade;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Pages.Tabs
{
    public partial class ManagePlacardTagsPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.ManagePlacardTagsPageModel>
    {
        public ManagePlacardTagsPage() : base(new Models.Page.ManagePlacardTagsPageModel())
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ReloadItems();
        }

        private void AddToolbarItem_Clicked(object sender, System.EventArgs e)
        {
            if (BindingContextPageModel.IsBusy) return;

            BindingContextPageModel.IsBusy = true;

            DisplayPromptAsync("Nueva Etiqueta", "Escriba el texto que representará este nueva etiqueta:", "Aceptar", "Cancelar").ContinueWith(task =>
            {
                if (string.IsNullOrEmpty(task.Result))
                {
                    BindingContextPageModel.IsBusy = false;

                    return;
                }

                var apiConnectClient = new Cloud.Api.Connect.Clients.TagsApiConnectClient(Managers.SessionManager.Instance);

                var model = new Cloud.Api.Common.Models.TagInputModel
                {
                    Id = System.Guid.NewGuid(),
                    Group = TagGroup.Placard,
                    Color = Xamarin.Forms.Color.Accent.ToHex(),
                    Name = task.Result
                };

                apiConnectClient.CreateAsync(model).ContinueWith(_task =>
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        if (_task.Exception != null || _task.IsCanceled)
                        {
                            (Xamarin.Forms.Application.Current as IExceptionHandleHelperFacade).HandleException(_task.Exception);

                            BindingContextPageModel.IsBusy = false;
                        }
                        else
                        {
                            ReloadItems();
                        }
                    });
                });
            });
        }

        private void ReloadToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            ReloadItems();
        }

        private void RemoveTagButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            DisplayAlert("Confirmar", "Está seguro que desea eliminar esta etiqueta?", "Aceptar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() => BindingContextPageModel.IsBusy = true);

                var apiConnectClient = new Cloud.Api.Connect.Clients.TagsApiConnectClient(Managers.SessionManager.Instance);

                apiConnectClient.Delete(((sender as Xamarin.Forms.BindableObject).BindingContext as TagDisplayModel).Id).ContinueWith(_task =>
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        if (_task.IsCanceled || _task.Exception != null)
                        {
                            (Xamarin.Forms.Application.Current as IExceptionHandleHelperFacade).HandleException(_task.Exception);

                            BindingContextPageModel.IsBusy = false;
                        }
                        else
                        {
                            Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Información", "Gradiente eliminado con éxito.");

                            ReloadItems();
                        }
                    });
                });
            });
        }

        private void ReloadItems()
        {
            BindingContextPageModel.IsBusy = true;

            BindingContextPageModel.Items.Clear();

            var apiConnectClient = new Cloud.Api.Connect.Clients.TagsApiConnectClient(Managers.SessionManager.Instance);

            apiConnectClient.FilterAsync(new Cloud.Api.Common.Models.Filter.TagFilterModel
            {
                Group = TagGroup.Placard
            }).ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    var bindingContextPageModel = BindingContext as TagPickPopupPageModel;

                    if (task.Exception != null || task.IsCanceled)
                    {
                        (Xamarin.Forms.Application.Current as IExceptionHandleHelperFacade).HandleException(task.Exception);
                    }
                    else
                    {
                        foreach (var item in task.Result)
                        {
                            BindingContextPageModel.Items.Add(item);
                        }
                    }

                    BindingContextPageModel.IsBusy = false;
                });
            });
        }
    }
}