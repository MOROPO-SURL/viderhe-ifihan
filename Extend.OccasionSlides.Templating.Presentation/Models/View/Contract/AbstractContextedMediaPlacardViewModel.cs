namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Models.View.Contract
{
    public abstract class AbstractContextedMediaPlacardViewModel : Common.Templating.Presentation.Models.View.AbstractScreenTimedPlacardViewModel
    {
        public Enumerations.FlyoutShapeKind OverlayShapeKind { get; set; }

        public Enumerations.FlyoutSize OverlaySize { get; set; }

        public string Title { get; set; }

        public int TitleFontSize { get; set; }

        public ContextedMediaInfoBlockModel[] InfoBlocks { get; set; }
    }
}
