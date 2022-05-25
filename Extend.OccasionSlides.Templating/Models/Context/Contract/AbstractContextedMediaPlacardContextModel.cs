namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Models.Context.Contract
{
    public abstract class AbstractContextedMediaPlacardContextModel : Common.Templating.Models.Context.AbstractScreenTimedPlacardContextModel
    {
        public Enumerations.OverlapShapeKind OverlapShapeKind { get; set; }

        public Enumerations.OverlapSize OverlapSize { get; set; }

        public string Title { get; set; }

        public string TitleFontFamily { get; set; }

        public int TitleFontSize { get; set; }

        public TextContentBlockContextModel[] ContentBlocks { get; set; }
    }
}
