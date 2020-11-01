namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Dashboard.Presentation.Models.Page
{
    public class PicturePresentingPictureLandscapePlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledScreenTimedPlacardConfigurationPageModel
    {
        private Support.Presentation.Models.View.ImageViewModel presentedImage;
        private Support.Presentation.Models.View.ImageViewModel presenterImage;
        private bool presentedImageZoomingEnabled;
        private bool presentedImageCenteredAtPresentation;
        private Templating.Presentation.Enumerations.LandscapePresentationSide presenterSide;

        public PicturePresentingPictureLandscapePlacardConfigurationPageModel()
        {
            ScreenPresentationTimeSecounds = 15;
            PresenterSide = Templating.Presentation.Enumerations.LandscapePresentationSide.Left;
        }

        public Support.Presentation.Models.View.ImageViewModel PresenterImage { get => presenterImage; set => SetProperty(ref presenterImage, value); }

        public Templating.Presentation.Enumerations.LandscapePresentationSide PresenterSide { get => presenterSide; set => SetProperty(ref presenterSide, value); }

        public Support.Presentation.Models.View.ImageViewModel PresentedImage { get => presentedImage; set => SetProperty(ref presentedImage, value); }

        public bool PresentedImageZoomingEnabled { get => presentedImageZoomingEnabled; set => SetProperty(ref presentedImageZoomingEnabled, value); }

        public bool PresentedImageCenteredAtPresentation { get => presentedImageCenteredAtPresentation; set => SetProperty(ref presentedImageCenteredAtPresentation, value); }

        public Templating.Presentation.Enumerations.LandscapePresentationSide[] LandscapePresentationSides { get => new[] { Templating.Presentation.Enumerations.LandscapePresentationSide.Left, Templating.Presentation.Enumerations.LandscapePresentationSide.Right }; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            PresenterImage = null;
            PresentedImage = null;
        }
    }
}
