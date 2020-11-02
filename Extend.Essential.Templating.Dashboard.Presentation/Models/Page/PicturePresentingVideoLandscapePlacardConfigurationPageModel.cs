namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Dashboard.Presentation.Models.Page
{
    public class PicturePresentingVideoLandscapePlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledScreenTimedPlacardConfigurationPageModel
    {
        private Support.Presentation.Models.View.ImageViewModel presenterImage;
        private Templating.Presentation.Enumerations.LandscapePresentationSide presenterSide;
        private Support.Presentation.Models.View.VideoViewModel presentedVideo;
        private bool presentedVideoCenteredAtPresentation;

        public PicturePresentingVideoLandscapePlacardConfigurationPageModel()
        {
            ScreenPresentationTimeSecounds = 15;
            PresenterSide = Templating.Presentation.Enumerations.LandscapePresentationSide.Left;
        }

        public Support.Presentation.Models.View.ImageViewModel PresenterImage { get => presenterImage; set => SetProperty(ref presenterImage, value); }

        public Templating.Presentation.Enumerations.LandscapePresentationSide PresenterSide { get => presenterSide; set => SetProperty(ref presenterSide, value); }

        public Support.Presentation.Models.View.VideoViewModel PresentedVideo { get => presentedVideo; set => SetProperty(ref presentedVideo, value); }

        public bool PresentedVideoCenteredAtPresentation { get => presentedVideoCenteredAtPresentation; set => SetProperty(ref presentedVideoCenteredAtPresentation, value); }

        public Templating.Presentation.Enumerations.LandscapePresentationSide[] LandscapePresentationSides { get => new[] { Templating.Presentation.Enumerations.LandscapePresentationSide.Left, Templating.Presentation.Enumerations.LandscapePresentationSide.Right }; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            PresenterImage = null;
            PresentedVideo = null;
        }
    }
}
