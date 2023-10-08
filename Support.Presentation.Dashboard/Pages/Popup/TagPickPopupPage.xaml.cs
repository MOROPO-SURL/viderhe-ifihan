using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Dashboard.Pages.Popup
{
    public partial class TagPickPopupPage : Rg.Plugins.Popup.Pages.PopupPage
    {
        private readonly Cloud.Persistence.Enumerations.TagGroup group;
        private readonly System.Action<Cloud.Api.Common.Models.TagDisplayModel> pickCallbackAction;
        private readonly Cloud.Api.Common.Models.TagDisplayModel[] exclusions;

        public TagPickPopupPage(Cloud.Persistence.Enumerations.TagGroup group, System.Action<Cloud.Api.Common.Models.TagDisplayModel> pickCallbackAction, Cloud.Api.Common.Models.TagDisplayModel[] exclusions = null)
        {
            this.group = group;
            this.pickCallbackAction = pickCallbackAction;
            this.exclusions = exclusions;

            InitializeComponent();

            BindingContext = new Models.Page.TagPickPopupPageModel { IsBusy = true };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var apiConnectClient = new Cloud.Api.Connect.Clients.TagsApiConnectClient(Xamarin.Forms.DependencyService.Get<MOROPO.SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

            apiConnectClient.FilterAsync(new Cloud.Api.Common.Models.Filter.TagFilterModel
            {
                Group = group
            }).ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    var bindingContextPageModel = BindingContext as Models.Page.TagPickPopupPageModel;

                    if (task.Exception != null || task.IsCanceled)
                    {
                        (Xamarin.Forms.Application.Current as Presentation.Helpers.Facade.IExceptionHandleHelperFacade).HandleException(task.Exception);
                    }
                    else
                    {
                        foreach (var item in task.Result)
                        {
                            if (exclusions != null && exclusions.Any(model => model.Id == item.Id)) continue;

                            bindingContextPageModel.Items.Add(item);
                        }
                    }

                    bindingContextPageModel.IsBusy = false;
                });
            });
        }

        public void CloseButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            if ((BindingContext as Models.Page.TagPickPopupPageModel).IsBusy) return;

            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
        }

        public void ApplyButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            if ((BindingContext as Models.Page.TagPickPopupPageModel).IsBusy) return;

            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();

            pickCallbackAction.Invoke(TagPicker.SelectedItem as Cloud.Api.Common.Models.TagDisplayModel);
        }

        public void AddNewButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            var bindingContextPageModel = BindingContext as Models.Page.TagPickPopupPageModel;

            bindingContextPageModel.IsBusy = true;

            DisplayPromptAsync("Nueva Etiqueta", "Escriba el texto que representará este nueva etiqueta:", "Aceptar", "Cancelar").ContinueWith(task =>
            {
                if (string.IsNullOrEmpty(task.Result))
                {
                    bindingContextPageModel.IsBusy = false;

                    return;
                }

                var apiConnectClient = new Cloud.Api.Connect.Clients.TagsApiConnectClient(Xamarin.Forms.DependencyService.Get<MOROPO.SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                var model = new Cloud.Api.Common.Models.TagInputModel
                {
                    Id = System.Guid.NewGuid(),
                    Group = group,
                    Color = Xamarin.Forms.Color.Accent.ToHex(),
                    Name = task.Result
                };

                apiConnectClient.CreateAsync(model).ContinueWith(_task =>
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        if (_task.Exception != null || _task.IsCanceled)
                        {
                            (Xamarin.Forms.Application.Current as Presentation.Helpers.Facade.IExceptionHandleHelperFacade).HandleException(_task.Exception);

                            bindingContextPageModel.IsBusy = false;
                        }
                        else
                        {
                            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();

                            pickCallbackAction.Invoke(new Cloud.Api.Common.Models.TagDisplayModel
                            {
                                Id = model.Id,
                                Name = model.Name,
                                Color = model.Color,
                                Group = model.Group
                            });
                        }
                    });
                });
            });
        }
    }
}