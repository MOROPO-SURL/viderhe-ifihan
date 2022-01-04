namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Pages.Popup
{
    public partial class InfoBlockConfigurationPopupPage : Rg.Plugins.Popup.Pages.PopupPage
    {
        private System.Action<Templating.Presentation.Models.ContextedMediaInfoBlockModel> applyActionCallback;

        public InfoBlockConfigurationPopupPage(System.Action<Templating.Presentation.Models.ContextedMediaInfoBlockModel> applyActionCallback, Templating.Presentation.Models.ContextedMediaInfoBlockModel model = null)
        {
            InitializeComponent();
        }
    }
}