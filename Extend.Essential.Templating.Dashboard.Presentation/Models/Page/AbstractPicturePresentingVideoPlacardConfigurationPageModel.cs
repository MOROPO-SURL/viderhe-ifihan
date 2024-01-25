using MOROPO.VIDERHE.Extend.Common.Templating.Dashboard.Presentation.Models.Page;
using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace MOROPO.VIDERHE.Extend.Essential.Templating.Dashboard.Presentation.Models.Page
{
    public abstract class AbstractPicturePresentingVideoPlacardConfigurationPageModel : AbstractLabeledPlacardConfigurationPageModel
    {
        private ImageViewModel presenterImage;
        private VideoViewModel presentedVideo;
        private bool presentedVideoCenteredAtPresentation;

        public ImageViewModel PresenterImage { get => presenterImage; set => SetProperty(ref presenterImage, value); }

        public VideoViewModel PresentedVideo { get => presentedVideo; set => SetProperty(ref presentedVideo, value); }

        public bool PresentedVideoCenteredAtPresentation { get => presentedVideoCenteredAtPresentation; set => SetProperty(ref presentedVideoCenteredAtPresentation, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            PresenterImage = null;
            PresentedVideo = null;
        }
    }
}
