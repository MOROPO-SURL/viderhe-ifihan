namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Models.View.Placard
{
    public class TranslucentContextualOverlapForImageSecuencePlacardViewModel : Common.Templating.Presentation.Models.View.AbstractPlacardViewModel, Contract.IContextualOverlapSKPathTransformablePlacardViewModel
    {
        public Enumerations.OverlapShapeKind OverlapShapeKind { get; set; }

        public Enumerations.OverlapSize OverlapSize { get; set; }

        public Block.Contract.AbstractContentBlockViewModel[] ContentBlocks { get; set; }

        public Enumerations.OverlapAlignment OverlapAlignment { get; set; }

        public Essential.Templating.Models.Context.PictureSlideSecuencePlacardContextModel PresentedPictureSlideSecuence { get; set; }

        public Xamarin.Forms.Color OverlapBackgroundColor { get; set; }
    }
}
