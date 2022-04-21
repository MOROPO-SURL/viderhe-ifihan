using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Pages.Block
{
    public partial class TextContentBlockConfigurationPage : XFToolKit.Mvvm.Pages.ContentPage
    {
        private System.Action<Templating.Presentation.Models.TextContentBlockModel> applyCallbackAction;

        public TextContentBlockConfigurationPage(System.Action<Templating.Presentation.Models.TextContentBlockModel> applyCallbackAction)
            : this(null, applyCallbackAction)
        {
        }

        public TextContentBlockConfigurationPage(Templating.Presentation.Models.TextContentBlockModel model, System.Action<Templating.Presentation.Models.TextContentBlockModel> applyCallbackAction)
        {
            this.applyCallbackAction = applyCallbackAction;

            InitializeComponent();

            Title = model != null ? "Modificar Bloque de Texto" : "Agregar Bloque de Texto";
            BindingContext = model ?? new Templating.Presentation.Models.TextContentBlockModel();
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            applyCallbackAction = null;
        }

        private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            applyCallbackAction.Invoke(BindingContext as Templating.Presentation.Models.TextContentBlockModel);

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
            (BindingContext as Templating.Presentation.Models.TextContentBlockModel).ContentFontFamily = null;
        }

        private void ContentFontFamilyPickButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.EmbeddedFontFamilyNamePickPage(ContentFontFamilyPicked_Callback));
        }

        private void HeaderFontFamilyClearButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            (BindingContext as Templating.Presentation.Models.TextContentBlockModel).HeaderFontFamily = null;
        }

        private void HeaderFontFamilyPickButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.EmbeddedFontFamilyNamePickPage(HeaderFontFamilyPicked_Callback));
        }

        private void ContentFontFamilyPicked_Callback(string selection)
        {
            (BindingContext as Templating.Presentation.Models.TextContentBlockModel).ContentFontFamily = selection;
        }

        private void HeaderFontFamilyPicked_Callback(string selection)
        {
            (BindingContext as Templating.Presentation.Models.TextContentBlockModel).HeaderFontFamily = selection;
        }
    }
}