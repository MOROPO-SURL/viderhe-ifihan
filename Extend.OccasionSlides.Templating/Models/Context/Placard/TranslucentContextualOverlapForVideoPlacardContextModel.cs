namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Models.Context.Placard
{
    public class TranslucentContextualOverlapForVideoPlacardContextModel : Common.Templating.Models.Context.AbstractPlacardContextModel
    {
        public Block.Contract.AbstractContentBlockContextModel[] ContentBlocks { get; set; }

        public Enumerations.OverlapAlignment OverlapAlignment { get; set; }

        public Enumerations.OverlapShapeKind OverlapShapeKind { get; set; }

        public Enumerations.OverlapSize OverlapSize { get; set; }

        public string OverlapBackgroundColor { get; set; }

        public Common.Templating.Models.Context.VideoContextModel ContextedVideo { get; set; }
    }
}
