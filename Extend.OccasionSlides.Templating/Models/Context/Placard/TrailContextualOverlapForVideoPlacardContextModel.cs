using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Enumerations;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Models.Context.Block.Contract;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Models.Context.Placard
{
    public class TrailContextualOverlapForVideoPlacardContextModel : Common.Templating.Models.Context.AbstractPlacardContextModel
    {
        public AbstractContentBlockContextModel[] ContentBlocks { get; set; }

        public OverlapAlignment OverlapAlignment { get; set; }

        public OverlapShapeKind OverlapShapeKind { get; set; }

        public OverlapSize OverlapSize { get; set; }

        public string OverlapBackgroundColor { get; set; }

        public OverlapTrailMode OverlapTrailMode { get; set; }

        public bool IsOverlapAnchoredAtVertical { get; set; }

        public Common.Templating.Models.Context.VideoContextModel ContextedVideo { get; set; }

        public bool IsContextedVideoFramed { get; set; }

        public bool ContextedVideoCenteredAtPresentation { get; set; }

        public bool ContextedVideoMuted { get; set; }
    }
}
