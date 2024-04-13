using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Enumerations;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Models.Context.Placard
{
    public class TranslucentContextualOverlapForVideoPlacardContextModel : Common.Templating.Models.Context.AbstractPlacardContextModel
    {
        public Block.Contract.AbstractContentBlockContextModel[] ContentBlocks { get; set; }

        public OverlapAlignment OverlapAlignment { get; set; }

        public OverlapShapeKind OverlapShapeKind { get; set; }

        public OverlapSize OverlapSize { get; set; }

        public bool IsOverlapAnchoredAtVertical { get; set; }

        public string OverlapBackgroundColor { get; set; }

        public Common.Templating.Models.Context.VideoContextModel ContextedVideo { get; set; }
    }
}
