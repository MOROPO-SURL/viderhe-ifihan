using MOROPO.VIDERHE.Cloud.Api.Common.Models;
using MOROPO.VIDERHE.Cloud.Persistence.Enumerations;
using MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.Page;
using MOROPO.VIDERHE.Support.Presentation.Helpers.Facade;
using System.Linq;

namespace MOROPO.VIDERHE.Support.Presentation.Dashboard.Pages.Popup
{
    public partial class TagPickPopupPage : Rg.Plugins.Popup.Pages.PopupPage
    {
        private readonly TagGroup group;
        private readonly System.Action<TagDisplayModel> pickCallbackAction;
        private readonly TagDisplayModel[] exclusions;

        public TagPickPopupPage(TagGroup group, System.Action<TagDisplayModel> pickCallbackAction, TagDisplayModel[] exclusions = null)
        {
            this.group = group;
            this.pickCallbackAction = pickCallbackAction;
            this.exclusions = exclusions;

            InitializeComponent();

            BindingContext = new TagPickPopupPageModel { IsBusy = true };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var apiConnectClient = new Cloud.Api.Connect.Clients.TagsApiConnectClient(Xamarin.Forms.DependencyService.Get<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

            apiConnectClient.FilterAsync(new Cloud.Api.Common.Models.Filter.TagFilterModel
            {
                Group = group
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
            if ((BindingContext as TagPickPopupPageModel).IsBusy) return;

            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
        }

        public void ApplyButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            if ((BindingContext as TagPickPopupPageModel).IsBusy) return;

            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();

            pickCallbackAction.Invoke(TagPicker.SelectedItem as TagDisplayModel);
        }

        public void AddNewButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            var bindingContextPageModel = BindingContext as TagPickPopupPageModel;

            bindingContextPageModel.IsBusy = true;

            DisplayPromptAsync("Nueva Etiqueta", "Escriba el texto que representará este nueva etiqueta:", "Aceptar", "Cancelar").ContinueWith(task =>
            {
                if (string.IsNullOrEmpty(task.Result))
                {
                    bindingContextPageModel.IsBusy = false;

                    return;
                }

                var apiConnectClient = new Cloud.Api.Connect.Clients.TagsApiConnectClient(Xamarin.Forms.DependencyService.Get<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                var model = new TagInputModel
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
                            (Xamarin.Forms.Application.Current as IExceptionHandleHelperFacade).HandleException(_task.Exception);

                            bindingContextPageModel.IsBusy = false;
                        }
                        else
                        {
                            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();

                            pickCallbackAction.Invoke(new TagDisplayModel
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