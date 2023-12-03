using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Enumerations;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Models.View.Block.Contract;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Models.View.Placard.Contract;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Models.View.Placard
{
    public class TrailContextualOverlapForImageSecuencePlacardViewModel : Common.Templating.Presentation.Models.View.AbstractPlacardViewModel, IContextualOverlapSKPathTransformablePlacardViewModel
    {
        public AbstractContentBlockViewModel[] ContentBlocks { get; set; }

        public OverlapAlignment OverlapAlignment { get; set; }

        public OverlapShapeKind OverlapShapeKind { get; set; }

        public OverlapSize OverlapSize { get; set; }

        public Xamarin.Forms.Color OverlapBackgroundColor { get; set; }

        public OverlapTrailMode OverlapTrailMode { get; set; }

        public Essential.Templating.Models.Context.PictureSlideSecuencePlacardContextModel PresentedPictureSlideSecuence { get; set; }

        public bool ContextedImageSecuenceCenteredAtPresentation { get; set; }
    }
}
