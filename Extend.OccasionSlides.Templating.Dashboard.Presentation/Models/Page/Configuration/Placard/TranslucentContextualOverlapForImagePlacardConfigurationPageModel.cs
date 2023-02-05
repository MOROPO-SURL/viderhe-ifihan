using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Enumerations;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page.Configuration.Placard
{
    public class TranslucentContextualOverlapForImagePlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledScreenTimedPlacardConfigurationPageModel
    {
        private OverlapShapeKind overlapShapeKind;
        private OverlapSize overlapSize;
        private OverlapAlignment overlapAlignment;
        private Xamarin.Forms.Color overlapBackgroundColor;
        private Support.Presentation.Models.View.ImageViewModel contextedImage;
        private bool contextedImageZoomingEnabled;
        private Essential.Templating.Enumerations.PictureLayoutMode contextedImageLayoutMode;

        public TranslucentContextualOverlapForImagePlacardConfigurationPageModel()
        {
            ScreenPresentationTimeSecounds = 10;
            ContentBlocks = new System.Collections.ObjectModel.ObservableCollection<View.ContentBlockCollectionItemViewModel>();
            ContextedImageLayoutMode = Essential.Templating.Enumerations.PictureLayoutMode.AspectFill;
            AvailableOverlapShapeKinds = new OverlapShapeKind[]
            {
                OverlapShapeKind.Rectangle,
                OverlapShapeKind.TriangleFullTop,
                OverlapShapeKind.TriangleFullBottom,
                OverlapShapeKind.TriangleMiddleTop,
                OverlapShapeKind.TriangleMiddleBottom
            };
            AvailableOverlapSizes = new OverlapSize[]
            {
                OverlapSize.Short,
                OverlapSize.Medium,
                OverlapSize.Large
            };
            AvailableOverlapAlignments = new OverlapAlignment[]
            {
                OverlapAlignment.Start,
                OverlapAlignment.End
            };
            AvailablePictureLayoutModes = new Essential.Templating.Enumerations.PictureLayoutMode[]
            {
                Essential.Templating.Enumerations.PictureLayoutMode.AspectFill,
                Essential.Templating.Enumerations.PictureLayoutMode.AspectFitWithOpaqueAspectFilledBySelf
            };
            OverlapBackgroundColor = Xamarin.Forms.Color.Black;
        }

        public OverlapShapeKind OverlapShapeKind { get => overlapShapeKind; set => SetProperty(ref overlapShapeKind, value); }

        public OverlapShapeKind[] AvailableOverlapShapeKinds { get; private set; }

        public OverlapSize OverlapSize { get => overlapSize; set => SetProperty(ref overlapSize, value); }

        public OverlapSize[] AvailableOverlapSizes { get; private set; }

        public System.Collections.ObjectModel.ObservableCollection<View.ContentBlockCollectionItemViewModel> ContentBlocks { get; private set; }

        public OverlapAlignment OverlapAlignment { get => overlapAlignment; set => SetProperty(ref overlapAlignment, value); }

        public OverlapAlignment[] AvailableOverlapAlignments { get; private set; }

        public Xamarin.Forms.Color OverlapBackgroundColor { get => overlapBackgroundColor; set => SetProperty(ref overlapBackgroundColor, value); }

        public Support.Presentation.Models.View.ImageViewModel ContextedImage { get => contextedImage; set => SetProperty(ref contextedImage, value); }

        public Essential.Templating.Enumerations.PictureLayoutMode ContextedImageLayoutMode { get => contextedImageLayoutMode; set => SetProperty(ref contextedImageLayoutMode, value); }

        public bool ContextedImageZoomingEnabled { get => contextedImageZoomingEnabled; set => SetProperty(ref contextedImageZoomingEnabled, value); }

        public Essential.Templating.Enumerations.PictureLayoutMode[] AvailablePictureLayoutModes { get; private set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            ContextedImage = null;
        }
    }
}
