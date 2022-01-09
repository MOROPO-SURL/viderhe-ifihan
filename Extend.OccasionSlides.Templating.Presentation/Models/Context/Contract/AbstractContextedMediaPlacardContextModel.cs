namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Models.Context.Contract
{
    public abstract class AbstractContextedMediaPlacardContextModel : Common.Templating.Presentation.Models.Context.AbstractScreenTimedPlacardContextModel
    {
        public Enumerations.OverlapShapeKind OverlapShapeKind { get; set; }

        public Enumerations.OverlapSize OverlapSize { get; set; }

        public string Title { get; set; }

        public int TitleFontSize { get; set; }

        public TextContentBlockModel[] ContentBlocks { get; set; }
    }
}
