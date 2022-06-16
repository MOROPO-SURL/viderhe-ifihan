using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Pages.Block
{
    public partial class TextContentBlockConfigurationPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.Block.TextContentBlockConfigurationPageModel>
    {
        private System.Action<Models.View.TextContentBlockViewModel> applyCallbackAction;

        public TextContentBlockConfigurationPage(System.Action<Models.View.TextContentBlockViewModel> applyCallbackAction)
            : this(null, applyCallbackAction)
        {
        }

        public TextContentBlockConfigurationPage(Models.View.TextContentBlockViewModel model, System.Action<Models.View.TextContentBlockViewModel> applyCallbackAction)
            : base(Factories.TextContentBlockConfigurationPageModelFactory.Build(model))
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
            applyCallbackAction.Invoke(new Models.View.TextContentBlockViewModel
            {
                Id = BindingContextPageModel.Id,
                Priority = BindingContextPageModel.Priority,
                Content = BindingContextPageModel.Content,
                ContentFontFamily = BindingContextPageModel.ContentFontFamily,
                ContentFontSize = BindingContextPageModel.ContentFontSize,
                ContentMaxLine = BindingContextPageModel.ContentMaxLine,
                IsHeaderVisible = BindingContextPageModel.IsHeaderVisible,
                Header = BindingContextPageModel.Header,
                HeaderFontFamily = BindingContextPageModel.HeaderFontFamily,
                HeaderFontSize = BindingContextPageModel.HeaderFontSize
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

        private void ContentFontFamilyClearButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            BindingContextPageModel.ContentFontFamily = null;
        }

        private void ContentFontFamilyPickButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.EmbeddedFontFamilyNamePickPage(ContentFontFamilyPicked_Callback));
        }

        private void HeaderFontFamilyClearButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            BindingContextPageModel.HeaderFontFamily = null;
        }

        private void HeaderFontFamilyPickButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.EmbeddedFontFamilyNamePickPage(HeaderFontFamilyPicked_Callback));
        }

        private void ContentFontFamilyPicked_Callback(string selection)
        {
            BindingContextPageModel.ContentFontFamily = selection;
        }

        private void HeaderFontFamilyPicked_Callback(string selection)
        {
            BindingContextPageModel.HeaderFontFamily = selection;
        }
    }
}