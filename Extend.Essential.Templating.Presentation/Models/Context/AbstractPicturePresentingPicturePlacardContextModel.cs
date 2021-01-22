namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Presentation.Models.Context
{
    public abstract class AbstractPicturePresentingPicturePlacardContextModel : Common.Templating.Presentation.Models.Context.AbstractScreenTimedPlacardContextModel
    {
        public Common.Templating.Presentation.Models.Context.ImageContextModel PresenterImage { get; set; }

        public Common.Templating.Presentation.Models.Context.ImageContextModel PresentedImage { get; set; }

        public bool PresentedImageZoomingEnabled { get; set; }

        public bool PresentedImageCenteredAtPresentation { get; set; }
    }
}
