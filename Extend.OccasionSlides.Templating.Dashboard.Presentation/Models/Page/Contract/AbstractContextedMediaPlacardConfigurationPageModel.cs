namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page.Contract
{
    public abstract class AbstractContextedMediaPlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledScreenTimedPlacardConfigurationPageModel
    {
        private Templating.Presentation.Enumerations.OverlapShapeKind overlapShapeKind;
        private Templating.Presentation.Enumerations.OverlapSize overlapSize;
        private string title;
        private string titleFontFamily;
        private int titleFontSize;

        public AbstractContextedMediaPlacardConfigurationPageModel()
        {
            TitleFontSize = 48;
            
            ContentBlocks = new System.Collections.ObjectModel.ObservableCollection<Templating.Presentation.Models.TextContentBlockModel>();

            AvailableOverlapShapeKinds = new Templating.Presentation.Enumerations.OverlapShapeKind[]
            {
                Templating.Presentation.Enumerations.OverlapShapeKind.Rectangle,
                Templating.Presentation.Enumerations.OverlapShapeKind.TriangleFullTop,
                Templating.Presentation.Enumerations.OverlapShapeKind.TriangleFullBottom
            };
            AvailableOverlapSizes = new Templating.Presentation.Enumerations.OverlapSize[]
            {
                Templating.Presentation.Enumerations.OverlapSize.Short,
                Templating.Presentation.Enumerations.OverlapSize.Medium,
                Templating.Presentation.Enumerations.OverlapSize.Large
            };
        }

        public Templating.Presentation.Enumerations.OverlapShapeKind OverlapShapeKind { get => overlapShapeKind; set => SetProperty(ref overlapShapeKind, value); }

        public Templating.Presentation.Enumerations.OverlapShapeKind[] AvailableOverlapShapeKinds { get; private set; }

        public Templating.Presentation.Enumerations.OverlapSize OverlapSize { get => overlapSize; set => SetProperty(ref overlapSize, value); }

        public Templating.Presentation.Enumerations.OverlapSize[] AvailableOverlapSizes { get; private set; }

        public string Title { get => title; set => SetProperty(ref title, value); }

        public string TitleFontFamily { get => titleFontFamily; set => SetProperty(ref titleFontFamily, value); }

        public int TitleFontSize { get => titleFontSize; set => SetProperty(ref titleFontSize, value); }

        public System.Collections.ObjectModel.ObservableCollection<Templating.Presentation.Models.TextContentBlockModel> ContentBlocks { get; private set; }
    }
}
