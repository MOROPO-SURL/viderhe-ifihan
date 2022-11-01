using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Pages.Configuration.Block
{
    public partial class TextContentBlockConfigurationPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.Configuration.Block.TextContentBlockConfigurationPageModel>
    {
        private System.Action<Templating.Presentation.Models.View.Block.TextContentBlockViewModel> applyCallbackAction;

        public TextContentBlockConfigurationPage(System.Action<Templating.Presentation.Models.View.Block.TextContentBlockViewModel> applyCallbackAction)
            : this(null, applyCallbackAction)
        {
        }

        public TextContentBlockConfigurationPage(Templating.Presentation.Models.View.Block.TextContentBlockViewModel model, System.Action<Templating.Presentation.Models.View.Block.TextContentBlockViewModel> applyCallbackAction)
            : base(Factories.Block.TextContentBlockConfigurationPageModelFactory.Build(model))
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
    }
}