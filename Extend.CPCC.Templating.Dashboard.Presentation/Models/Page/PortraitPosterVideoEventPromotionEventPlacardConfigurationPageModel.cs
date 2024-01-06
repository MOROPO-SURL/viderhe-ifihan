namespace MOROPO.VIDERHE.Extend.CPCC.Templating.Dashboard.Presentation.Models.Page
{
    public class PortraitPosterVideoEventPromotionEventPlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledPlacardConfigurationPageModel
    {
        private Support.Presentation.Models.View.ImageViewModel eventPoster;
        private Support.Presentation.Models.View.VideoViewModel eventVideo;

        public Support.Presentation.Models.View.ImageViewModel EventPoster { get => eventPoster; set => SetProperty(ref eventPoster, value); }

        public Support.Presentation.Models.View.VideoViewModel EventVideo { get => eventVideo; set => SetProperty(ref eventVideo, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            EventPoster = null;
            EventVideo = null;
        }
    }
}