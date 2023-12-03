using MOROPO.VIDERHE.Extend.Common.Templating.Dashboard.Presentation.Models.Page;
using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace MOROPO.VIDERHE.Extend.Essential.Templating.Dashboard.Presentation.Models.Page
{
    public abstract class AbstractPicturePresentingPicturePlacardConfigurationPageModel : AbstractLabeledScreenTimedPlacardConfigurationPageModel
    {
        private ImageViewModel presentedImage;
        private ImageViewModel presenterImage;
        private bool presentedImageZoomingEnabled;
        private bool presentedImageCenteredAtPresentation;

        public AbstractPicturePresentingPicturePlacardConfigurationPageModel()
        {
            ScreenPresentationTimeSecounds = 15;
        }

        public ImageViewModel PresenterImage { get => presenterImage; set => SetProperty(ref presenterImage, value); }

        public ImageViewModel PresentedImage { get => presentedImage; set => SetProperty(ref presentedImage, value); }

        public bool PresentedImageZoomingEnabled { get => presentedImageZoomingEnabled; set => SetProperty(ref presentedImageZoomingEnabled, value); }

        public bool PresentedImageCenteredAtPresentation { get => presentedImageCenteredAtPresentation; set => SetProperty(ref presentedImageCenteredAtPresentation, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            PresenterImage = null;
            PresentedImage = null;
        }
    }
}
