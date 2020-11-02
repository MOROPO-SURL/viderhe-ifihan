namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Presentation.Models.Context
{
    public class PicturePresentingVideoLandscapePlacardContextModel : Common.Templating.Presentation.Models.Context.AbstractScreenTimedPlacardContextModel
    {
        public PicturePresentingVideoLandscapePlacardContextModel()
        {
            PresentedVideoCenteredAtPresentation = false;
            PresenterSide = Enumerations.LandscapePresentationSide.Left;
        }

        public Common.Templating.Presentation.Models.Context.ImageContextModel PresenterImage { get; set; }

        public Enumerations.LandscapePresentationSide PresenterSide { get; set; }

        public Common.Templating.Presentation.Models.Context.VideoContextModel PresentedVideo { get; set; }

        public bool PresentedVideoCenteredAtPresentation { get; set; }
    }
}
