namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Models.Context
{
    public abstract class AbstractPicturePresentingPictureSlideSecuencePlacardContextModel : Common.Templating.Models.Context.AbstractPlacardContextModel
    {
        public Common.Templating.Models.Context.ImageContextModel PresenterImage { get; set; }

        public PictureSlideSecuencePlacardContextModel PresentedPictureSlideSecuence { get; set; }

        public bool PresentedPictureSlideSecuenceCenteredAtPresentation { get; set; }
    }
}
