namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page.Contract
{
    public abstract class AbstractContextedMediaPlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledScreenTimedPlacardConfigurationPageModel
    {
        private Templating.Presentation.Enumerations.MediaContextOverlayShapeKind overlayShapeKind;
        private Templating.Presentation.Enumerations.MediaContextOverlaySize overlaySize;
        private string title;
        private int titleFontSize;

        public AbstractContextedMediaPlacardConfigurationPageModel()
        {
            TitleFontSize = 48;
            
            InfoBlocks = new System.Collections.ObjectModel.ObservableCollection<Templating.Presentation.Models.ContextedMediaInfoBlockModel>();

            AvailableOverlayShapeKinds = new Templating.Presentation.Enumerations.MediaContextOverlayShapeKind[]
            {
                Templating.Presentation.Enumerations.MediaContextOverlayShapeKind.Rectangle,
                Templating.Presentation.Enumerations.MediaContextOverlayShapeKind.TriangleFullTop,
                Templating.Presentation.Enumerations.MediaContextOverlayShapeKind.TriangleFullBottom
            };
            AvailableOverlaySizes = new Templating.Presentation.Enumerations.MediaContextOverlaySize[]
            {
                Templating.Presentation.Enumerations.MediaContextOverlaySize.Short,
                Templating.Presentation.Enumerations.MediaContextOverlaySize.Medium,
                Templating.Presentation.Enumerations.MediaContextOverlaySize.Large
            };
        }

        public Templating.Presentation.Enumerations.MediaContextOverlayShapeKind OverlayShapeKind { get => overlayShapeKind; set => SetProperty(ref overlayShapeKind, value); }

        public Templating.Presentation.Enumerations.MediaContextOverlayShapeKind[] AvailableOverlayShapeKinds { get; private set; }

        public Templating.Presentation.Enumerations.MediaContextOverlaySize OverlaySize { get => overlaySize; set => SetProperty(ref overlaySize, value); }

        public Templating.Presentation.Enumerations.MediaContextOverlaySize[] AvailableOverlaySizes { get; private set; }

        public string Title { get => title; set => SetProperty(ref title, value); }

        public int TitleFontSize { get => titleFontSize; set => SetProperty(ref titleFontSize, value); }

        public System.Collections.ObjectModel.ObservableCollection<Templating.Presentation.Models.ContextedMediaInfoBlockModel> InfoBlocks { get; private set; }
    }
}
