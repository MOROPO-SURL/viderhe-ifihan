namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Pages.Popup
{
    public partial class InfoBlockConfigurationPopupPage : Rg.Plugins.Popup.Pages.PopupPage
    {
        private System.Action<Templating.Presentation.Models.ContextedMediaInfoBlockModel> applyActionCallback;

        public InfoBlockConfigurationPopupPage(System.Action<Templating.Presentation.Models.ContextedMediaInfoBlockModel> applyActionCallback, Templating.Presentation.Models.ContextedMediaInfoBlockModel model = null)
        {
            this.applyActionCallback = applyActionCallback;

            InitializeComponent();

            PageTitleLabel.Text = model != null ? "Modificar Bloque Informativo" : "Agregar Bloque Informativo";

            BindingContext = model ?? new Templating.Presentation.Models.ContextedMediaInfoBlockModel();
        }

        private void ApplyButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            applyActionCallback.Invoke(BindingContext as Templating.Presentation.Models.ContextedMediaInfoBlockModel);

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