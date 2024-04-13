using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Enumerations;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Models.Context.Placard
{
    public class TrailContextualOverlapForImagePlacardContextModel : Common.Templating.Models.Context.AbstractScreenTimedPlacardContextModel
    {
        public Block.Contract.AbstractContentBlockContextModel[] ContentBlocks { get; set; }

        public OverlapAlignment OverlapAlignment { get; set; }

        public OverlapShapeKind OverlapShapeKind { get; set; }

        public OverlapSize OverlapSize { get; set; }

        public string OverlapBackgroundColor { get; set; }

        public OverlapTrailMode OverlapTrailMode { get; set; }

        public bool IsOverlapAnchoredAtVertical { get; set; }

        public Common.Templating.Models.Context.ImageContextModel ContextedImage { get; set; }

        public bool ContextedImageAspectToFitAndComplementFilled { get; set; }

        public bool ContextedImageZoomingEnabled { get; set; }

        public bool ContextedImageCenteredAtPresentation { get; set; }
    }
}
