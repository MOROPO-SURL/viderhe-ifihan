namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Models.Context
{
    public abstract class AbstractPicturePresentingPicturePlacardContextModel : Common.Templating.Models.Context.AbstractScreenTimedPlacardContextModel
    {
        public Common.Templating.Models.Context.ImageContextModel PresenterImage { get; set; }

        public Common.Templating.Models.Context.ImageContextModel PresentedImage { get; set; }

        public bool PresentedImageZoomingEnabled { get; set; }

        public bool PresentedImageCenteredAtPresentation { get; set; }
    }
}
