namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Presentation.Models.Context
{
    public abstract class AbstractPicturePresentingPictureSlideSecuencePlacardContextModel : Common.Templating.Presentation.Models.Context.AbstractPlacardContextModel
    {
        public Common.Templating.Presentation.Models.Context.ImageContextModel PresenterImage { get; set; }

        public PictureSlideSecuencePlacardContextModel PresentedPictureSlideSecuence { get; set; }

        public bool PresentedPictureSlideSecuenceCenteredAtPresentation { get; set; }
    }
}
