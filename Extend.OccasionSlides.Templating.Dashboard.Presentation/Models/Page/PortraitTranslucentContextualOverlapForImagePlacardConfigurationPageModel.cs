using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Enumerations;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page
{
    public class PortraitTranslucentContextualOverlapForImagePlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledScreenTimedPlacardConfigurationPageModel
    {
        private OverlapShapeKind overlapShapeKind;
        private string title;
        private string titleFontFamily;
        private int titleFontSize;
        private OverlapVerticalAlignment overlapVerticalAlignment;
        private Support.Presentation.Models.View.ImageViewModel contextedImage;
        private bool contextedImageZoomingEnabled;
        private Xamarin.Forms.Color overlapBackgroundColor;
        private Xamarin.Forms.Color textColor;

        public PortraitTranslucentContextualOverlapForImagePlacardConfigurationPageModel()
        {
            TitleFontSize = 48;

            ContentBlocks = new System.Collections.ObjectModel.ObservableCollection<Templating.Models.Context.TextContentBlockContextModel>();

            AvailableOverlapShapeKinds = new OverlapShapeKind[]
            {
                OverlapShapeKind.Rectangle,
                OverlapShapeKind.TriangleFullTop,
                OverlapShapeKind.TriangleFullBottom
            };

            OverlapBackgroundColor = Xamarin.Forms.Color.Black;
            TextColor = Xamarin.Forms.Color.White;

            AvailableOverlapVerticalAlignments = new OverlapVerticalAlignment[]
            {
                OverlapVerticalAlignment.Top,
                OverlapVerticalAlignment.Bottom
            };
        }

        public OverlapShapeKind OverlapShapeKind { get => overlapShapeKind; set => SetProperty(ref overlapShapeKind, value); }

        public OverlapShapeKind[] AvailableOverlapShapeKinds { get; private set; }

        public string Title { get => title; set => SetProperty(ref title, value); }

        public string TitleFontFamily { get => titleFontFamily; set => SetProperty(ref titleFontFamily, value); }

        public int TitleFontSize { get => titleFontSize; set => SetProperty(ref titleFontSize, value); }

        public System.Collections.ObjectModel.ObservableCollection<Templating.Models.Context.TextContentBlockContextModel> ContentBlocks { get; private set; }

        public Support.Presentation.Models.View.ImageViewModel ContextedImage { get => contextedImage; set => SetProperty(ref contextedImage, value); }

        public bool ContextedImageZoomingEnabled { get => contextedImageZoomingEnabled; set => SetProperty(ref contextedImageZoomingEnabled, value); }

        public OverlapVerticalAlignment OverlapVerticalAlignment { get => overlapVerticalAlignment; set => SetProperty(ref overlapVerticalAlignment, value); }

        public OverlapVerticalAlignment[] AvailableOverlapVerticalAlignments { get; private set; }

        public Xamarin.Forms.Color OverlapBackgroundColor { get => overlapBackgroundColor; set => SetProperty(ref overlapBackgroundColor, value); }

        public Xamarin.Forms.Color TextColor { get => textColor; set => SetProperty(ref textColor, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            ContextedImage = null;
        }
    }
}
