namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Models.Page
{
    public class InfinityVideoPlacardCreatePageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledPlacardConfigurationPageModel
    {
        private int startMargin;
        private int endMargin;

        public Support.Presentation.Models.View.VideoViewModel Video { get; set; }

        public int StartMargin { get => startMargin; set => SetProperty(ref startMargin, value); }

        public int EndMargin { get => endMargin; set => SetProperty(ref endMargin, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Video = null;
        }
    }
}
