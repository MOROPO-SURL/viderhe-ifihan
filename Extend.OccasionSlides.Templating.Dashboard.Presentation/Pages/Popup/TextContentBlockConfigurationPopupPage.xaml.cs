namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Pages.Popup
{
    public partial class TextContentBlockConfigurationPopupPage : Rg.Plugins.Popup.Pages.PopupPage
    {
        private System.Action<Templating.Presentation.Models.TextContentBlockModel> applyActionCallback;

        public TextContentBlockConfigurationPopupPage(System.Action<Templating.Presentation.Models.TextContentBlockModel> applyActionCallback, Templating.Presentation.Models.TextContentBlockModel model = null)
        {
            this.applyActionCallback = applyActionCallback;

            InitializeComponent();

            PageTitleLabel.Text = model != null ? "Modificar Bloque de Texto" : "Agregar Bloque de Texto";

            BindingContext = model ?? new Templating.Presentation.Models.TextContentBlockModel();
        }

        private void ApplyButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            applyActionCallback.Invoke(BindingContext as Templating.Presentation.Models.TextContentBlockModel);

            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
        }

        private void CancelButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            DisplayAlert("Confirmar", "Está seguro que desea cancelar?", "Cancelar", "Continuar").ContinueWith(task =>
            {
                if (!task.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
                });
            });
        }
    }
}