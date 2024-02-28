namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Presentation.Models.View.Contract
{
    public abstract class AbstractMuseographyPlacardViewModel : Common.Templating.Presentation.Models.View.AbstractScreenTimedPlacardViewModel
    {
        public string Header { get; set; }

        public int HeaderFontSize { get; set; }

        public string Content { get; set; }

        public int ContentFontSize { get; set; }
    }
}
