using MOROPO.VIDERHE.Extend.Common.Templating.Models.Context;

namespace MOROPO.VIDERHE.Extend.Essential.Templating.Models.Context
{
    public abstract class AbstractPicturePresentingPictureSlideSecuencePlacardContextModel : AbstractPlacardContextModel
    {
        public ImageContextModel PresenterImage { get; set; }

        public PictureSlideSecuencePlacardContextModel PresentedPictureSlideSecuence { get; set; }

        public bool PresentedPictureSlideSecuenceCenteredAtPresentation { get; set; }
    }
}
