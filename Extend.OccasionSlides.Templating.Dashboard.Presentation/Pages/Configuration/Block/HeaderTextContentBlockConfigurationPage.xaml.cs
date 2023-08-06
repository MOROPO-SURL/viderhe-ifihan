using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Pages.Configuration.Block
{
    public partial class HeaderTextContentBlockConfigurationPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.Configuration.Block.HeaderTextContentBlockConfigurationPageModel>
    {
        private System.Action<Templating.Presentation.Models.View.Block.HeaderTextContentBlockViewModel> applyCallbackAction;

        public HeaderTextContentBlockConfigurationPage(System.Action<Templating.Presentation.Models.View.Block.HeaderTextContentBlockViewModel> applyCallbackAction)
            : this(null, applyCallbackAction)
        {
        }

        public HeaderTextContentBlockConfigurationPage(Templating.Presentation.Models.View.Block.HeaderTextContentBlockViewModel model, System.Action<Templating.Presentation.Models.View.Block.HeaderTextContentBlockViewModel> applyCallbackAction)
            : base(Factories.Block.HeaderTextContentBlockConfigurationPageModelFactory.Build(model))
        {
            this.applyCallbackAction = applyCallbackAction;

            InitializeComponent();

            Title = model != null ? "Modificar Bloque de Texto con Encabezado" : "Agregar Bloque de Texto con Encabezado";
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            applyCallbackAction = null;
        }

        private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            applyCallbackAction.Invoke(new Templating.Presentation.Models.View.Block.HeaderTextContentBlockViewModel
            {
                Id = BindingContextPageModel.Id,
                Text = BindingContextPageModel.Text,
                TextFontFamily = BindingContextPageModel.TextFontFamily,
                TextFontSize = BindingContextPageModel.TextFontSize,
                TextMaxLineCount = BindingContextPageModel.TextMaxLineCount,
                TextColor = BindingContextPageModel.TextColor,
                Header = BindingContextPageModel.Header,
                HeaderFontFamily = BindingContextPageModel.HeaderFontFamily,
                HeaderFontSize = BindingContextPageModel.HeaderFontSize,
                HeaderColor = BindingContextPageModel.HeaderColor
            });

            this.NavigationPopPageAsync();
        }

        private void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            DisplayAlert("Confirmar", "Está seguro que desea cancelar?", "Cancelar", "Continuar").ContinueWith(task =>
            {
                if (!task.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    this.NavigationPopPageAsync();
                });
            });
        }

        private void TextFontFamilyClearButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            BindingContextPageModel.TextFontFamily = null;
        }

        private void TextFontFamilyPickButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.EmbeddedFontFamilyNamePickPage(TextFontFamilyPicked_Callback));
        }

        private void HeaderFontFamilyClearButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            BindingContextPageModel.HeaderFontFamily = null;
        }

        private void HeaderFontFamilyPickButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.EmbeddedFontFamilyNamePickPage(HeaderFontFamilyPicked_Callback));
        }

        private void PickTextButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.TextPickPage(PickText_Callback));
        }

        private void PickHeaderButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.TextPickPage(PickHeader_Callback));
        }

        private void TextSaveButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            DisplayPromptAsync("Salvar Texto", "Especifique una referencia para este texto").ContinueWith(task =>
            {
                if (string.IsNullOrEmpty(task.Result)) return;

                BindingContextPageModel.IsBusy = true;

                var apiConnectClient = new Cloud.Api.Connect.Clients.TextsApiConnectClient(Xamarin.Forms.DependencyService.Get<MOROPO.SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                apiConnectClient.CreateAsync(new Cloud.Api.Common.Models.TextInputModel
                {
                    About = task.Result,
                    Content = BindingContextPageModel.Text
                }).ContinueWith(_task =>
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        if (_task.IsCanceled || _task.IsFaulted)
                        {
                            Xamarin.Forms.DependencyService.Get<Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade>().HandleException(task.Exception);
                        }
                        else
                        {
                            Xamarin.Forms.DependencyService.Get<Support.Presentation.Dashboard.Presenters.Facade.INotificationPresenterFacade>().PresentNotification("Información", "Cambios aplicados con éxito.");
                        }

                        BindingContextPageModel.IsBusy = false;
                    });
                });
            });
        }

        private void HeaderSaveButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            DisplayPromptAsync("Salvar Texto", "Especifique una referencia para este texto").ContinueWith(task =>
            {
                if (string.IsNullOrEmpty(task.Result)) return;

                BindingContextPageModel.IsBusy = true;

                var apiConnectClient = new Cloud.Api.Connect.Clients.TextsApiConnectClient(Xamarin.Forms.DependencyService.Get<MOROPO.SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

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
                            Xamarin.Forms.DependencyService.Get<Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade>().HandleException(task.Exception);
                        }
                        else
                        {
                            Xamarin.Forms.DependencyService.Get<Support.Presentation.Dashboard.Presenters.Facade.INotificationPresenterFacade>().PresentNotification("Información", "Cambios aplicados con éxito.");
                        }

                        BindingContextPageModel.IsBusy = false;
                    });
                });
            });
        }

        private void PickText_Callback(Support.Presentation.Dashboard.Models.View.TextViewModel target)
        {
            BindingContextPageModel.Text = target.Content;
        }

        private void PickHeader_Callback(Support.Presentation.Dashboard.Models.View.TextViewModel target)
        {
            BindingContextPageModel.Header = target.Content;
        }

        private void TextFontFamilyPicked_Callback(string selection)
        {
            BindingContextPageModel.TextFontFamily = selection;
        }

        private void HeaderFontFamilyPicked_Callback(string selection)
        {
            BindingContextPageModel.HeaderFontFamily = selection;
        }
    }
}