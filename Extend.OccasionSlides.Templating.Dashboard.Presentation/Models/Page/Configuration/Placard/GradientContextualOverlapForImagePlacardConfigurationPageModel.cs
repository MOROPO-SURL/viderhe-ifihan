using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Enumerations;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page.Configuration.Placard
{
    public class GradientContextualOverlapForImagePlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledScreenTimedPlacardConfigurationPageModel
    {
        private OverlapSize overlapSize;
        private Support.Presentation.Models.View.ImageViewModel contextedImage;
        private bool contextedImageZoomingEnabled;
        private Xamarin.Forms.Color gradientColor;
        private bool contextedImageCenteredAtPresentation;
        private OverlapAlignment overlapAlignment;
        private Essential.Templating.Enumerations.PictureLayoutMode contextedImageLayoutMode;
        private bool isOverlapAnchoredAtVertical;

        public GradientContextualOverlapForImagePlacardConfigurationPageModel()
        {
            ScreenPresentationTimeSecounds = 10;
            ContentBlocks = new System.Collections.ObjectModel.ObservableCollection<View.ContentBlockCollectionItemViewModel>();
            ContextedImageLayoutMode = Essential.Templating.Enumerations.PictureLayoutMode.AspectFill;
            AvailableOverlapSizes = new OverlapSize[]
            {
                OverlapSize.Short,
                OverlapSize.Medium,
                OverlapSize.Large
            };
            GradientColor = Xamarin.Forms.Color.Black;
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
        }

        public OverlapSize OverlapSize { get => overlapSize; set => SetProperty(ref overlapSize, value); }

        public OverlapSize[] AvailableOverlapSizes { get; private set; }

        public System.Collections.ObjectModel.ObservableCollection<View.ContentBlockCollectionItemViewModel> ContentBlocks { get; private set; }

        public Xamarin.Forms.Color GradientColor { get => gradientColor; set => SetProperty(ref gradientColor, value); }

        public bool ContextedImageCenteredAtPresentation { get => contextedImageCenteredAtPresentation; set => SetProperty(ref contextedImageCenteredAtPresentation, value); }

        public Support.Presentation.Models.View.ImageViewModel ContextedImage { get => contextedImage; set => SetProperty(ref contextedImage, value); }

        public bool ContextedImageZoomingEnabled { get => contextedImageZoomingEnabled; set => SetProperty(ref contextedImageZoomingEnabled, value); }

        public Essential.Templating.Enumerations.PictureLayoutMode ContextedImageLayoutMode { get => contextedImageLayoutMode; set => SetProperty(ref contextedImageLayoutMode, value); }

        public OverlapAlignment OverlapAlignment { get => overlapAlignment; set => SetProperty(ref overlapAlignment, value); }

        public OverlapAlignment[] AvailableOverlapAlignments { get; private set; }

        public Essential.Templating.Enumerations.PictureLayoutMode[] AvailablePictureLayoutModes { get; private set; }

        public bool IsOverlapAnchoredAtVertical { get => isOverlapAnchoredAtVertical; set => SetProperty(ref isOverlapAnchoredAtVertical, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            ContextedImage = null;
        }
    }
}
