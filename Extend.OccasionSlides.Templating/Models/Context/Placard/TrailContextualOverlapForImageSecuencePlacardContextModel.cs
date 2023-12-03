using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Enumerations;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Models.Context.Placard
{
    public class TrailContextualOverlapForImageSecuencePlacardContextModel : Common.Templating.Models.Context.AbstractPlacardContextModel
    {
        public Block.Contract.AbstractContentBlockContextModel[] ContentBlocks { get; set; }

        public OverlapAlignment OverlapAlignment { get; set; }

        public OverlapShapeKind OverlapShapeKind { get; set; }

        public OverlapSize OverlapSize { get; set; }

        public string OverlapBackgroundColor { get; set; }

        public OverlapTrailMode OverlapTrailMode { get; set; }

        public Essential.Templating.Models.Context.PictureSlideSecuencePlacardContextModel PresentedPictureSlideSecuence { get; set; }

        public bool ContextedImageSecuenceCenteredAtPresentation { get; set; }
    }
}
