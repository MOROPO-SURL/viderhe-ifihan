namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Models.Context.Contract
{
    public abstract class AbstractContextedMediaPlacardContextModel : Common.Templating.Presentation.Models.Context.AbstractScreenTimedPlacardContextModel
    {
        public Enumerations.MediaContextOverlayShapeKind OverlayShapeKind { get; set; }

        public Enumerations.MediaContextOverlaySize OverlaySize { get; set; }

        public string Title { get; set; }

        public int TitleFontSize { get; set; }

        public ContextedMediaInfoBlockModel[] InfoBlocks { get; set; }
    }
}
