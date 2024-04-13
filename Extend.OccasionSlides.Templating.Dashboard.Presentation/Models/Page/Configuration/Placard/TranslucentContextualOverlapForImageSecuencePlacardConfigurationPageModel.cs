using MOROPO.VIDERHE.Extend.Essential.Templating.Enumerations;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Enumerations;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page.Configuration.Placard
{
    public class TranslucentContextualOverlapForImageSecuencePlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledPlacardConfigurationPageModel
    {
        private OverlapShapeKind overlapShapeKind;
        private OverlapSize overlapSize;
        private OverlapAlignment overlapAlignment;
        private Xamarin.Forms.Color overlapBackgroundColor;
        private int pictureSlidePresentationSecounds;
        private bool isOverlapAnchoredAtVertical;

        public TranslucentContextualOverlapForImageSecuencePlacardConfigurationPageModel()
        {
            ContentBlocks = new System.Collections.ObjectModel.ObservableCollection<View.ContentBlockCollectionItemViewModel>();
            PictureSlidePresentationSecounds = 10;
            AvailableLayoutModes = new PictureLayoutMode[]
            {
                PictureLayoutMode.AspectFit,
                PictureLayoutMode.AspectFill,
                PictureLayoutMode.Fill,
                PictureLayoutMode.AspectFitWithOpaqueAspectFilledBySelf
            };

            PresentedSlides = new System.Collections.ObjectModel.ObservableCollection<Essential.Templating.Dashboard.Presentation.Models.View.PictureSlideViewModel>();

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
        }

        public OverlapShapeKind OverlapShapeKind { get => overlapShapeKind; set => SetProperty(ref overlapShapeKind, value); }

        public OverlapShapeKind[] AvailableOverlapShapeKinds { get; private set; }

        public OverlapSize OverlapSize { get => overlapSize; set => SetProperty(ref overlapSize, value); }

        public OverlapSize[] AvailableOverlapSizes { get; private set; }

        public System.Collections.ObjectModel.ObservableCollection<View.ContentBlockCollectionItemViewModel> ContentBlocks { get; private set; }

        public OverlapAlignment OverlapAlignment { get => overlapAlignment; set => SetProperty(ref overlapAlignment, value); }

        public OverlapAlignment[] AvailableOverlapAlignments { get; private set; }

        public Xamarin.Forms.Color OverlapBackgroundColor { get => overlapBackgroundColor; set => SetProperty(ref overlapBackgroundColor, value); }

        public System.Collections.ObjectModel.ObservableCollection<Essential.Templating.Dashboard.Presentation.Models.View.PictureSlideViewModel> PresentedSlides { get; set; }

        public PictureLayoutMode[] AvailableLayoutModes { get; private set; }

        public int PictureSlidePresentationSecounds { get => pictureSlidePresentationSecounds; set => SetProperty(ref pictureSlidePresentationSecounds, value); }

        public bool IsOverlapAnchoredAtVertical { get => isOverlapAnchoredAtVertical; set => SetProperty(ref isOverlapAnchoredAtVertical, value); }
    }
}
