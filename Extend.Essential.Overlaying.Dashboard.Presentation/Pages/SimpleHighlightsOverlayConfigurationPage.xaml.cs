using MOROPO.VIDERHE.Extend.Essential.Overlaying.Dashboard.Presentation.Factories;
using MOROPO.VIDERHE.Extend.Essential.Overlaying.Dashboard.Presentation.Models.Page;
using MOROPO.VIDERHE.Support.Presentation.Dashboard.Behaviors.Contract;
using MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.View;
using MOROPO.VIDERHE.Support.Presentation.Dashboard.Pages.Contract;
using MOROPO.VIDERHE.Support.Presentation.Dashboard.Presenters.Facade;
using MOROPO.VIDERHE.Support.Presentation.Helpers.Facade;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace MOROPO.VIDERHE.Extend.Essential.Overlaying.Dashboard.Presentation.Pages
{
    public partial class SimpleHighlightsOverlayConfigurationPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<SimpleHighlightsOverlayConfigurationPageModel>, IValidableFormPage
    {
        private readonly System.Collections.Generic.List<IFormFieldValidationBehavior> validationBehaviors;

        private System.Action<string> successfulCompleteCallbackAction;

        public SimpleHighlightsOverlayConfigurationPage(string serializedContext, System.Action<string> successfulCompleteCallbackAction)
            : base(SimpleHighlightsOverlayConfigurationPageModelFactory.Build(serializedContext))
        {
            validationBehaviors = new System.Collections.Generic.List<IFormFieldValidationBehavior>();

            InitializeComponent();

            this.successfulCompleteCallbackAction = successfulCompleteCallbackAction;
        }

        private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            BindingContextPageModel.ResetValidationState();

            foreach (var validationBehavior in validationBehaviors)
            {
                var result = validationBehavior.Evaluate();

                if (!BindingContextPageModel.IsValid) continue;

                if (!result) BindingContextPageModel.IsValid = false;
            }

            if (!BindingContextPageModel.IsValid) return;

            this.NavigationPopPageAsync();

            successfulCompleteCallbackAction.Invoke(Newtonsoft.Json.JsonConvert.SerializeObject(new Overlaying.Presentation.Models.Context.SimpleHighlightsContextModel
            {
                Header = BindingContextPageModel.Header,
                Highlights = BindingContextPageModel.Highlights
            }));
        }

        private void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPopPageAsync();
        }

        private void PickHeaderTextButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.TextPickPage(PickHeaderText_Callback));
        }

        private void HeaderTextSaveButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            DisplayPromptAsync("Salvar Texto", "Especifique una referencia para este texto").ContinueWith(task =>
            {
                if (string.IsNullOrEmpty(task.Result)) return;

                BindingContextPageModel.IsBusy = true;

                var apiConnectClient = new Cloud.Api.Connect.Clients.TextsApiConnectClient(Xamarin.Forms.DependencyService.Get<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                apiConnectClient.CreateAsync(new Cloud.Api.Common.Models.TextInputModel
                {
                    About = task.Result,
                    Content = BindingContextPageModel.Header
                }).ContinueWith(_task =>
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        if (_task.IsCanceled || _task.IsFaulted)
                        {
                            Xamarin.Forms.DependencyService.Get<IExceptionHandleHelperFacade>().HandleException(task.Exception);
                        }
                        else
                        {
                            Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Información", "Cambios aplicados con éxito.");
                        }

                        BindingContextPageModel.IsBusy = false;
                    });
                });
            });
        }

        private void PickHighlightsTextButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.TextPickPage(PickHighlightsText_Callback));
        }

        private void HighlightsTextSaveButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            DisplayPromptAsync("Salvar Texto", "Especifique una referencia para este texto").ContinueWith(task =>
            {
                if (string.IsNullOrEmpty(task.Result)) return;

                BindingContextPageModel.IsBusy = true;

                var apiConnectClient = new Cloud.Api.Connect.Clients.TextsApiConnectClient(Xamarin.Forms.DependencyService.Get<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                apiConnectClient.CreateAsync(new Cloud.Api.Common.Models.TextInputModel
                {
                    About = task.Result,
                    Content = BindingContextPageModel.Highlights
                }).ContinueWith(_task =>
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        if (_task.IsCanceled || _task.IsFaulted)
                        {
                            Xamarin.Forms.DependencyService.Get<IExceptionHandleHelperFacade>().HandleException(task.Exception);
                        }
                        else
                        {
                            Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Información", "Cambios aplicados con éxito.");
                        }

                        BindingContextPageModel.IsBusy = false;
                    });
                });
            });
        }

        private void PickHeaderText_Callback(TextViewModel target)
        {
            BindingContextPageModel.Header = target.Content;
        }

        private void PickHighlightsText_Callback(TextViewModel target)
        {
            BindingContextPageModel.Highlights = target.Content;
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            successfulCompleteCallbackAction = null;
        }

        #region IValidableFormPage implementation

        public void AddValidationBehavior(IFormFieldValidationBehavior validationBehavior)
        {
            validationBehaviors.Add(validationBehavior);
        }

        public void RemoveValidationBehavior(IFormFieldValidationBehavior validationBehavior)
        {
            validationBehaviors.Remove(validationBehavior);
        }

        public void AddValidationMessage(string label, string message)
        {
            BindingContextPageModel.ValidationMessages.Add(new Support.Presentation.Dashboard.Models.View.ValidationMessageViewModel
            {
                Caption = label,
                Message = message
            });
        }

        #endregion
    }
}