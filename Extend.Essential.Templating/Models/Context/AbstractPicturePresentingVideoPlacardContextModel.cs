using MOROPO.VIDERHE.Extend.Common.Templating.Models.Context;

namespace MOROPO.VIDERHE.Extend.Essential.Templating.Models.Context
{
    public abstract class AbstractPicturePresentingVideoPlacardContextModel : AbstractPlacardContextModel
    {
        public ImageContextModel PresenterImage { get; set; }

        public VideoContextModel PresentedVideo { get; set; }

        public bool PresentedVideoCenteredAtPresentation { get; set; }

        public bool PresentedVideoMuted { get; set; }
    }
}
