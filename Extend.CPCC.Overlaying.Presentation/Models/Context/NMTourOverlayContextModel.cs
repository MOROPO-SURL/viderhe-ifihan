using MOROPO.VIDERHE.Extend.Common.Templating.Models.Context;

namespace MOROPO.VIDERHE.Extend.CPCC.Overlaying.Presentation.Models.Context
{
    public class NMTourOverlayContextModel : AdvicesMarqueeOverlayContextModel
    {
        public ImageContextModel BannerImage { get; set; }

        public string Title { get; set; }

        public string About { get; set; }

        public NMTourOverlaySectionContextModel[] Sections { get; set; }
    }
}
