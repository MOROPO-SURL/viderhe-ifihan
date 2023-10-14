using SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Enumerations;
using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Enumerations;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page.Configuration.Placard
{
    public class TrailContextualOverlapForImageSecuencePlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledPlacardConfigurationPageModel
    {
        private OverlapShapeKind overlapShapeKind;
        private OverlapSize overlapSize;
        private OverlapAlignment overlapAlignment;
        private Xamarin.Forms.Color overlapBackgroundColor;
        private OverlapTrailMode overlapTrailMode;
        private int pictureSlidePresentationSecounds;
        private bool contextedImageSecuenceCenteredAtPresentation;

        public TrailContextualOverlapForImageSecuencePlacardConfigurationPageModel()
        {
            PictureSlidePresentationSecounds = 10;
            PresentedSlides = new System.Collections.ObjectModel.ObservableCollection<Essential.Templating.Dashboard.Presentation.Models.View.PictureSlideViewModel>();
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
            AvailableLayoutModes = new PictureLayoutMode[]
            {
                PictureLayoutMode.AspectFit,
                PictureLayoutMode.AspectFill,
                PictureLayoutMode.Fill,
                PictureLayoutMode.AspectFitWithOpaqueAspectFilledBySelf
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

        public bool ContextedImageSecuenceCenteredAtPresentation { get => contextedImageSecuenceCenteredAtPresentation; set => SetProperty(ref contextedImageSecuenceCenteredAtPresentation, value); }

        public System.Collections.ObjectModel.ObservableCollection<Essential.Templating.Dashboard.Presentation.Models.View.PictureSlideViewModel> PresentedSlides { get; set; }

        public int PictureSlidePresentationSecounds { get => pictureSlidePresentationSecounds; set => SetProperty(ref pictureSlidePresentationSecounds, value); }

        public PictureLayoutMode[] AvailableLayoutModes { get; private set; }
    }
}
