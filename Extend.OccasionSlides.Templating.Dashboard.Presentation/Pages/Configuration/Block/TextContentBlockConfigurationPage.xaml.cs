using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Dashboard.Presentation.Factories.Block;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page.Configuration.Block;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Models.View.Block;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Dashboard.Presentation.Pages.Configuration.Block
{
    public partial class TextContentBlockConfigurationPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<TextContentBlockConfigurationPageModel>
    {
        private System.Action<TextContentBlockViewModel> applyCallbackAction;

        public TextContentBlockConfigurationPage(System.Action<TextContentBlockViewModel> applyCallbackAction)
            : this(null, applyCallbackAction)
        {
        }

        public TextContentBlockConfigurationPage(TextContentBlockViewModel model, System.Action<TextContentBlockViewModel> applyCallbackAction)
            : base(TextContentBlockConfigurationPageModelFactory.Build(model))
        {
            this.applyCallbackAction = applyCallbackAction;

            InitializeComponent();

            Title = model != null ? "Modificar Bloque de Texto" : "Agregar Bloque de Texto";
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            applyCallbackAction = null;
        }

        private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            applyCallbackAction.Invoke(new Templating.Presentation.Models.View.Block.TextContentBlockViewModel
            {
                Id = BindingContextPageModel.Id,
                Text = BindingContextPageModel.Text,
                TextFontFamily = BindingContextPageModel.TextFontFamily,
                TextFontSize = BindingContextPageModel.TextFontSize,
                TextMaxLineCount = BindingContextPageModel.TextMaxLineCount,
                TextColor = BindingContextPageModel.TextColor
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

        private void TextFontFamilyPicked_Callback(string selection)
        {
            BindingContextPageModel.TextFontFamily = selection;
        }

        private void PickTextButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.TextPickPage(PickText_Callback));
        }

        private void TextSaveButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            DisplayPromptAsync("Salvar Texto", "Especifique una referencia para este texto").ContinueWith(task =>
            {
                if (string.IsNullOrEmpty(task.Result)) return;

                BindingContextPageModel.IsBusy = true;

                var apiConnectClient = new Cloud.Api.Connect.Clients.TextsApiConnectClient(Xamarin.Forms.DependencyService.Get<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

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

        private void PickText_Callback(Support.Presentation.Dashboard.Models.View.TextViewModel target)
        {
            BindingContextPageModel.Text = target.Content;
        }
    }
}