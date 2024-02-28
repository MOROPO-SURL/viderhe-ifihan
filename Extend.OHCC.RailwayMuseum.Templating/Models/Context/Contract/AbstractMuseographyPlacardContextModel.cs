namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Models.Context.Contract
{
    public abstract class AbstractMuseographyPlacardContextModel : Common.Templating.Models.Context.AbstractScreenTimedPlacardContextModel
    {
        public string Header { get; set; }

        public int HeaderFontSize { get; set; }

        public string Content { get; set; }

        public int ContentFontSize { get; set; }
    }
}
