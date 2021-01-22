namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Dashboard.Presentation.Models.Page
{
    public abstract class AbstractPicturePresentingPicturePlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledScreenTimedPlacardConfigurationPageModel
    {
        private Support.Presentation.Models.View.ImageViewModel presentedImage;
        private Support.Presentation.Models.View.ImageViewModel presenterImage;
        private bool presentedImageZoomingEnabled;
        private bool presentedImageCenteredAtPresentation;

        public AbstractPicturePresentingPicturePlacardConfigurationPageModel()
        {
            ScreenPresentationTimeSecounds = 15;
        }

        public Support.Presentation.Models.View.ImageViewModel PresenterImage { get => presenterImage; set => SetProperty(ref presenterImage, value); }

        public Support.Presentation.Models.View.ImageViewModel PresentedImage { get => presentedImage; set => SetProperty(ref presentedImage, value); }

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
