using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Enumerations;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page.Configuration.Placard
{
    public class FlatContextualOverlapForVideoPlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledPlacardConfigurationPageModel
    {
        private OverlapShapeKind overlapShapeKind;
        private OverlapSize overlapSize;
        private Support.Presentation.Models.View.VideoViewModel contextedVideo;
        private Xamarin.Forms.Color overlapBackgroundColor;
        private bool useOverlapShadown;
        private bool contextedVideoCenteredAtPresentation;
        private bool contextedVideoMuted;
        private OverlapAlignment overlapAlignment;
        private bool isOverlapAnchoredAtVertical;

        public FlatContextualOverlapForVideoPlacardConfigurationPageModel()
        {
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
            OverlapBackgroundColor = Xamarin.Forms.Color.Black;
            AvailableOverlapAlignments = new OverlapAlignment[]
            {
                OverlapAlignment.Start,
                OverlapAlignment.End
            };
        }

        public OverlapShapeKind OverlapShapeKind { get => overlapShapeKind; set => SetProperty(ref overlapShapeKind, value); }

        public OverlapShapeKind[] AvailableOverlapShapeKinds { get; private set; }

        public OverlapSize OverlapSize { get => overlapSize; set => SetProperty(ref overlapSize, value); }

        public OverlapSize[] AvailableOverlapSizes { get; private set; }

        public System.Collections.ObjectModel.ObservableCollection<View.ContentBlockCollectionItemViewModel> ContentBlocks { get; private set; }

        public Xamarin.Forms.Color OverlapBackgroundColor { get => overlapBackgroundColor; set => SetProperty(ref overlapBackgroundColor, value); }

        public bool UseOverlapShadown { get => useOverlapShadown; set => SetProperty(ref useOverlapShadown, value); }

        public bool ContextedVideoCenteredAtPresentation { get => contextedVideoCenteredAtPresentation; set => SetProperty(ref contextedVideoCenteredAtPresentation, value); }

        public bool ContextedVideoMuted { get => contextedVideoMuted; set => SetProperty(ref contextedVideoMuted, value); }

        public Support.Presentation.Models.View.VideoViewModel ContextedVideo { get => contextedVideo; set => SetProperty(ref contextedVideo, value); }

        public OverlapAlignment OverlapAlignment { get => overlapAlignment; set => SetProperty(ref overlapAlignment, value); }

        public OverlapAlignment[] AvailableOverlapAlignments { get; private set; }

        public bool IsOverlapAnchoredAtVertical { get => isOverlapAnchoredAtVertical; set => SetProperty(ref isOverlapAnchoredAtVertical, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            ContextedVideo = null;
        }
    }
}
