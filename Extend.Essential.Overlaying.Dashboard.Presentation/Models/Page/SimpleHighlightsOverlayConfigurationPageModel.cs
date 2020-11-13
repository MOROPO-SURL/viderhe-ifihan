namespace SmartSolucionesCuba.Videre.Extend.Essential.Overlaying.Dashboard.Presentation.Models.Page
{
    public class SimpleHighlightsOverlayConfigurationPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private string header;
        private string highlights;

        public string Header { get => header; set => SetProperty(ref header, value); }

        public string Highlights { get => highlights; set => SetProperty(ref highlights, value); }
    }
}
