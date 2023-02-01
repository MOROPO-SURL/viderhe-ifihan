using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Enumerations;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page.Configuration.Placard
{
    public class TrailContextualOverlapForVideoPlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledScreenTimedPlacardConfigurationPageModel
    {
        private OverlapShapeKind overlapShapeKind;
        private OverlapSize overlapSize;
        private OverlapAlignment overlapAlignment;
        private Xamarin.Forms.Color overlapBackgroundColor;
        private OverlapTrailMode overlapTrailMode;
        private bool contextedVideoCenteredAtPresentation;
        private Support.Presentation.Models.View.VideoViewModel contextedVideo;
        private bool isVideoFramed;

        public TrailContextualOverlapForVideoPlacardConfigurationPageModel()
        {
            ScreenPresentationTimeSecounds = 10;
            ContentBlocks = new System.Collections.ObjectModel.ObservableCollection<View.ContentBlockCollectionItemViewModel>();
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
        }

        public OverlapShapeKind OverlapShapeKind { get => overlapShapeKind; set => SetProperty(ref overlapShapeKind, value); }

        public OverlapShapeKind[] AvailableOverlapShapeKinds { get; private set; }

        public OverlapSize OverlapSize { get => overlapSize; set => SetProperty(ref overlapSize, value); }

        public OverlapSize[] AvailableOverlapSizes { get; private set; }

        public System.Collections.ObjectModel.ObservableCollection<View.ContentBlockCollectionItemViewModel> ContentBlocks { get; private set; }

        public OverlapAlignment OverlapAlignment { get => overlapAlignment; set => SetProperty(ref overlapAlignment, value); }

        public OverlapAlignment[] AvailableOverlapAlignments { get; private set; }

        public Xamarin.Forms.Color OverlapBackgroundColor { get => overlapBackgroundColor; set => SetProperty(ref overlapBackgroundColor, value); }

        public OverlapTrailMode OverlapTrailMode { get => overlapTrailMode; set => SetProperty(ref overlapTrailMode, value); }

        public OverlapTrailMode[] AvailableOverlapTrailModes { get; private set; }

        public bool ContextedVideoCenteredAtPresentation { get => contextedVideoCenteredAtPresentation; set => SetProperty(ref contextedVideoCenteredAtPresentation, value); }

        public Support.Presentation.Models.View.VideoViewModel ContextedVideo { get => contextedVideo; set => SetProperty(ref contextedVideo, value); }

        public bool IsContextedVideoFramed { get => isVideoFramed; set => SetProperty(ref isVideoFramed, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            ContextedVideo = null;
        }
    }
}
