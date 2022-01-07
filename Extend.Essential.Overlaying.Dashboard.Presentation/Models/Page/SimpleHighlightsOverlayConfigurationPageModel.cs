namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Overlaying.Dashboard.Presentation.Models.Page
{
    public class SimpleHighlightsOverlayConfigurationPageModel : Support.Presentation.Dashboard.Models.Page.FormPageModel
    {
        private string header;
        private string highlights;

        public string Header { get => header; set => SetProperty(ref header, value); }

        public string Highlights { get => highlights; set => SetProperty(ref highlights, value); }
    }
}
