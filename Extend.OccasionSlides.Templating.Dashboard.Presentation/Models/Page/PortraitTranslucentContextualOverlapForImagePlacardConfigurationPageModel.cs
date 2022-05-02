namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page
{
    public class PortraitTranslucentContextualOverlapForImagePlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledScreenTimedPlacardConfigurationPageModel
    {
        private Templating.Presentation.Enumerations.OverlapShapeKind overlapShapeKind;
        private string title;
        private string titleFontFamily;
        private int titleFontSize;
        private Templating.Presentation.Enumerations.OverlapVerticalAlignment overlapVerticalAlignment;
        private Support.Presentation.Models.View.ImageViewModel contextedImage;
        private bool contextedImageZoomingEnabled;
        private Xamarin.Forms.Color overlapBackgroundColor;
        private Xamarin.Forms.Color textColor;

        public PortraitTranslucentContextualOverlapForImagePlacardConfigurationPageModel()
        {
            TitleFontSize = 48;

            ContentBlocks = new System.Collections.ObjectModel.ObservableCollection<Templating.Presentation.Models.TextContentBlockModel>();

            AvailableOverlapShapeKinds = new Templating.Presentation.Enumerations.OverlapShapeKind[]
            {
                Templating.Presentation.Enumerations.OverlapShapeKind.Rectangle,
                Templating.Presentation.Enumerations.OverlapShapeKind.TriangleFullTop,
                Templating.Presentation.Enumerations.OverlapShapeKind.TriangleFullBottom
            };

            OverlapBackgroundColor = Xamarin.Forms.Color.Black;
            TextColor = Xamarin.Forms.Color.White;

            AvailableOverlapVerticalAlignments = new Templating.Presentation.Enumerations.OverlapVerticalAlignment[]
            {
                Templating.Presentation.Enumerations.OverlapVerticalAlignment.Top,
                Templating.Presentation.Enumerations.OverlapVerticalAlignment.Bottom
            };
        }

        public Templating.Presentation.Enumerations.OverlapShapeKind OverlapShapeKind { get => overlapShapeKind; set => SetProperty(ref overlapShapeKind, value); }

        public Templating.Presentation.Enumerations.OverlapShapeKind[] AvailableOverlapShapeKinds { get; private set; }

        public string Title { get => title; set => SetProperty(ref title, value); }

        public string TitleFontFamily { get => titleFontFamily; set => SetProperty(ref titleFontFamily, value); }

        public int TitleFontSize { get => titleFontSize; set => SetProperty(ref titleFontSize, value); }

        public System.Collections.ObjectModel.ObservableCollection<Templating.Presentation.Models.TextContentBlockModel> ContentBlocks { get; private set; }

        public Support.Presentation.Models.View.ImageViewModel ContextedImage { get => contextedImage; set => SetProperty(ref contextedImage, value); }

        public bool ContextedImageZoomingEnabled { get => contextedImageZoomingEnabled; set => SetProperty(ref contextedImageZoomingEnabled, value); }

        public Templating.Presentation.Enumerations.OverlapVerticalAlignment OverlapVerticalAlignment { get => overlapVerticalAlignment; set => SetProperty(ref overlapVerticalAlignment, value); }

        public Templating.Presentation.Enumerations.OverlapVerticalAlignment[] AvailableOverlapVerticalAlignments { get; private set; }

        public Xamarin.Forms.Color OverlapBackgroundColor { get => overlapBackgroundColor; set => SetProperty(ref overlapBackgroundColor, value); }

        public Xamarin.Forms.Color TextColor { get => textColor; set => SetProperty(ref textColor, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            ContextedImage = null;
        }
    }
}
