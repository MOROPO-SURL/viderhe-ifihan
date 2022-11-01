namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Models.Context.Placard
{
    public class TranslucentContextualOverlapForImageSecuencePlacardContextModel : Common.Templating.Models.Context.AbstractPlacardContextModel
    {
        public Enumerations.OverlapShapeKind OverlapShapeKind { get; set; }

        public Enumerations.OverlapSize OverlapSize { get; set; }

        public Block.Contract.AbstractContentBlockContextModel[] ContentBlocks { get; set; }

        public Enumerations.OverlapAlignment OverlapAlignment { get; set; }

        public Essential.Templating.Models.Context.PictureSlideSecuencePlacardContextModel PresentedPictureSlideSecuence { get; set; }

        public string OverlapBackgroundColor { get; set; }
    }
}
