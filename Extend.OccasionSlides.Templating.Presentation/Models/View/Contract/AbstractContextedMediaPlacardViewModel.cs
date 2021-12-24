namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Models.View.Contract
{
    public abstract class AbstractContextedMediaPlacardViewModel : Common.Templating.Presentation.Models.View.AbstractScreenTimedPlacardViewModel
    {
        public AbstractContextedMediaPlacardViewModel()
        {
            InfoItems = new System.Collections.Generic.List<ContextedMediaInfoItemModel>();
        }

        public Enumerations.MediaContextOverlayShapeKind OverlayShapeKind { get; set; }

        public Enumerations.MediaContextOverlaySize OverlaySize { get; set; }

        public string Title { get; set; }

        public Xamarin.Forms.Color TitleTextColor { get; set; }

        public int TitleFontSize { get; set; }

        public System.Collections.Generic.List<ContextedMediaInfoItemModel> InfoItems { get; set; }
    }
}
