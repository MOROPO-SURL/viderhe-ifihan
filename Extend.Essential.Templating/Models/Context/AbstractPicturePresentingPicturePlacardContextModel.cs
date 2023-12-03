using MOROPO.VIDERHE.Extend.Common.Templating.Models.Context;

namespace MOROPO.VIDERHE.Extend.Essential.Templating.Models.Context
{
    public abstract class AbstractPicturePresentingPicturePlacardContextModel : AbstractScreenTimedPlacardContextModel
    {
        public ImageContextModel PresenterImage { get; set; }

        public ImageContextModel PresentedImage { get; set; }

        public bool PresentedImageZoomingEnabled { get; set; }

        public bool PresentedImageCenteredAtPresentation { get; set; }
    }
}
