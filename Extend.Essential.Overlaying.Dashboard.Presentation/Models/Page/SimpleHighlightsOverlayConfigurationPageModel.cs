using MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.Page;

namespace MOROPO.VIDERHE.Extend.Essential.Overlaying.Dashboard.Presentation.Models.Page
{
    public class SimpleHighlightsOverlayConfigurationPageModel : FormPageModel
    {
        private string header;
        private string highlights;

        public string Header { get => header; set => SetProperty(ref header, value); }

        public string Highlights { get => highlights; set => SetProperty(ref highlights, value); }
    }
}
