namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Presentation.Models.Context
{
    public class PicturePresentingPictureLandscapePlacardContextModel : Common.Templating.Presentation.Models.Context.AbstractScreenTimedPlacardContextModel
    {
        public PicturePresentingPictureLandscapePlacardContextModel()
        {
            PresentedImageZoomingEnabled = false;
            PresentedImageCenteredAtPresentation = false;
            PresenterSide = Enumerations.LandscapePresentationSide.Left;
        }

        public Common.Templating.Presentation.Models.Context.ImageContextModel PresenterImage { get; set; }

        public Common.Templating.Presentation.Models.Context.ImageContextModel PresentedImage { get; set; }

        public bool PresentedImageZoomingEnabled { get; set; }

        public bool PresentedImageCenteredAtPresentation { get; set; }

        public Enumerations.LandscapePresentationSide PresenterSide { get; set; }
    }
}
