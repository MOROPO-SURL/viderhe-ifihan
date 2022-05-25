namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Models.Context
{
    public class InfinityVideoPlacardContextModel : Common.Templating.Models.Context.AbstractPlacardContextModel
    {
        public Common.Templating.Models.Context.VideoContextModel Video { get; set; }

        public int StartMargin { get; set; }

        public int EndMargin { get; set; }
    }
}
