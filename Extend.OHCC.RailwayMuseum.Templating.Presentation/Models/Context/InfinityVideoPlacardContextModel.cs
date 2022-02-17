namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Presentation.Models.Context
{
    public class InfinityVideoPlacardContextModel : Common.Templating.Presentation.Models.Context.AbstractPlacardContextModel
    {
        public Common.Templating.Presentation.Models.Context.VideoContextModel Video { get; set; }

        public int StartMargin { get; set; }

        public int EndMargin { get; set; }
    }
}
