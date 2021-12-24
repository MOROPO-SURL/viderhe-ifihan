namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Models.Context.Contract
{
    public abstract class AbstractContextedMediaPlacardContextModel : Common.Templating.Presentation.Models.Context.AbstractScreenTimedPlacardContextModel
    {
        public AbstractContextedMediaPlacardContextModel()
        {
            InfoItems = new System.Collections.Generic.List<ContextedMediaInfoItemModel>();
        }

        public Enumerations.MediaContextOverlayShapeKind OverlayShapeKind { get; set; }

        public Enumerations.MediaContextOverlaySize OverlaySize { get; set; }

        public string Title { get; set; }

        public string TitleTextColor { get; set; }

        public int TitleFontSize { get; set; }

        public System.Collections.Generic.List<ContextedMediaInfoItemModel> InfoItems { get; set; }
    }
}
