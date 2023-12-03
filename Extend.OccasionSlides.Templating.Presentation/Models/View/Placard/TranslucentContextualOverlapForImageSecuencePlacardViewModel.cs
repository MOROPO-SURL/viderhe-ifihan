using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Enumerations;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Models.View.Placard
{
    public class TranslucentContextualOverlapForImageSecuencePlacardViewModel : Common.Templating.Presentation.Models.View.AbstractPlacardViewModel, Contract.IContextualOverlapSKPathTransformablePlacardViewModel
    {
        public OverlapShapeKind OverlapShapeKind { get; set; }

        public OverlapSize OverlapSize { get; set; }

        public Block.Contract.AbstractContentBlockViewModel[] ContentBlocks { get; set; }

        public OverlapAlignment OverlapAlignment { get; set; }

        public Essential.Templating.Models.Context.PictureSlideSecuencePlacardContextModel PresentedPictureSlideSecuence { get; set; }

        public Xamarin.Forms.Color OverlapBackgroundColor { get; set; }
    }
}
