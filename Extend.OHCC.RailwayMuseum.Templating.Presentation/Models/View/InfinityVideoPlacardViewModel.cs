namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Presentation.Models.View
{
    public class InfinityVideoPlacardViewModel : Common.Templating.Presentation.Models.View.AbstractPlacardViewModel
    {
        public Common.Templating.Presentation.Models.Context.VideoContextModel Video { get; set; }

        public int StartMargin { get; set; }

        public int EndMargin { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Video = null;
        }
    }
}
