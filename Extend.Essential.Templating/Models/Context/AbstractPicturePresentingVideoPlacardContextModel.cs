namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Models.Context
{
    public abstract class AbstractPicturePresentingVideoPlacardContextModel : Common.Templating.Models.Context.AbstractPlacardContextModel
    {
        public Common.Templating.Models.Context.ImageContextModel PresenterImage { get; set; }

        public Common.Templating.Models.Context.VideoContextModel PresentedVideo { get; set; }

        public bool PresentedVideoCenteredAtPresentation { get; set; }
    }
}
