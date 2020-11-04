namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Dashboard.Presentation.Models.Page
{
    public abstract class AbstractPicturePresentingVideoPlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledPlacardConfigurationPageModel
    {
        private Support.Presentation.Models.View.ImageViewModel presenterImage;
        private Support.Presentation.Models.View.VideoViewModel presentedVideo;
        private bool presentedVideoCenteredAtPresentation;

        public Support.Presentation.Models.View.ImageViewModel PresenterImage { get => presenterImage; set => SetProperty(ref presenterImage, value); }

        public Support.Presentation.Models.View.VideoViewModel PresentedVideo { get => presentedVideo; set => SetProperty(ref presentedVideo, value); }

        public bool PresentedVideoCenteredAtPresentation { get => presentedVideoCenteredAtPresentation; set => SetProperty(ref presentedVideoCenteredAtPresentation, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            PresenterImage = null;
            PresentedVideo = null;
        }
    }
}
