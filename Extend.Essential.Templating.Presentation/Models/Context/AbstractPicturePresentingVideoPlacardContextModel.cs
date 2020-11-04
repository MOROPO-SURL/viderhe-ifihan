namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Presentation.Models.Context
{
    public abstract class AbstractPicturePresentingVideoPlacardContextModel : Common.Templating.Presentation.Models.Context.AbstractPlacardContextModel
    {
        public Common.Templating.Presentation.Models.Context.ImageContextModel PresenterImage { get; set; }

        public Common.Templating.Presentation.Models.Context.VideoContextModel PresentedVideo { get; set; }

        public bool PresentedVideoCenteredAtPresentation { get; set; }
    }
}
