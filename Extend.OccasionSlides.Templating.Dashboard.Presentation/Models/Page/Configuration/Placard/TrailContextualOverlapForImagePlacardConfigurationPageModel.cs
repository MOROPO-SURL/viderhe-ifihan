using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.View;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Enumerations;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page.Configuration.Placard
{
    public class TrailContextualOverlapForImagePlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledScreenTimedPlacardConfigurationPageModel
    {
        private OverlapShapeKind overlapShapeKind;
        private OverlapSize overlapSize;
        private OverlapAlignment overlapAlignment;
        private Xamarin.Forms.Color overlapBackgroundColor;
        private OverlapTrailMode overlapTrailMode;
        private bool contextedImageCenteredAtPresentation;
        private Support.Presentation.Models.View.ImageViewModel contextedImage;
        private bool contextedImageZoomingEnabled;
        private Essential.Templating.Enumerations.PictureLayoutMode contextedImageLayoutMode;
        private bool isOverlapAnchoredAtVertical;

        public TrailContextualOverlapForImagePlacardConfigurationPageModel()
        {
            ScreenPresentationTimeSecounds = 10;
            ContentBlocks = new System.Collections.ObjectModel.ObservableCollection<ContentBlockCollectionItemViewModel>();
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
            OverlapBackgroundColor = Xamarin.Forms.Color.Black;
            OverlapTrailMode = OverlapTrailMode.Dual;
            AvailableOverlapTrailModes = new OverlapTrailMode[]
            {
                OverlapTrailMode.Single,
                OverlapTrailMode.Dual,
                OverlapTrailMode.Triplex,
                OverlapTrailMode.Fourfold
            };
            AvailablePictureLayoutModes = new Essential.Templating.Enumerations.PictureLayoutMode[]
            {
                Essential.Templating.Enumerations.PictureLayoutMode.AspectFill,
                Essential.Templating.Enumerations.PictureLayoutMode.AspectFitWithOpaqueAspectFilledBySelf
            };
        }

        public OverlapShapeKind OverlapShapeKind { get => overlapShapeKind; set => SetProperty(ref overlapShapeKind, value); }

        public OverlapShapeKind[] AvailableOverlapShapeKinds { get; private set; }

        public OverlapSize OverlapSize { get => overlapSize; set => SetProperty(ref overlapSize, value); }

        public OverlapSize[] AvailableOverlapSizes { get; private set; }

        public System.Collections.ObjectModel.ObservableCollection<ContentBlockCollectionItemViewModel> ContentBlocks { get; private set; }

        public OverlapAlignment OverlapAlignment { get => overlapAlignment; set => SetProperty(ref overlapAlignment, value); }

        public OverlapAlignment[] AvailableOverlapAlignments { get; private set; }

        public Xamarin.Forms.Color OverlapBackgroundColor { get => overlapBackgroundColor; set => SetProperty(ref overlapBackgroundColor, value); }

        public OverlapTrailMode OverlapTrailMode { get => overlapTrailMode; set => SetProperty(ref overlapTrailMode, value); }

        public OverlapTrailMode[] AvailableOverlapTrailModes { get; private set; }

        public bool ContextedImageCenteredAtPresentation { get => contextedImageCenteredAtPresentation; set => SetProperty(ref contextedImageCenteredAtPresentation, value); }

        public Support.Presentation.Models.View.ImageViewModel ContextedImage { get => contextedImage; set => SetProperty(ref contextedImage, value); }

        public Essential.Templating.Enumerations.PictureLayoutMode ContextedImageLayoutMode { get => contextedImageLayoutMode; set => SetProperty(ref contextedImageLayoutMode, value); }

        public bool ContextedImageZoomingEnabled { get => contextedImageZoomingEnabled; set => SetProperty(ref contextedImageZoomingEnabled, value); }

        public Essential.Templating.Enumerations.PictureLayoutMode[] AvailablePictureLayoutModes { get; private set; }

        public bool IsOverlapAnchoredAtVertical { get => isOverlapAnchoredAtVertical; set => SetProperty(ref isOverlapAnchoredAtVertical, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            ContextedImage = null;
        }
    }
}
