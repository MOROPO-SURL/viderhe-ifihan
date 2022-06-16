using SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Enumerations;
using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Enumerations;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page
{
    public class LandscapeTranslucentContextualOverlapForImageSecuencePlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledScreenTimedPlacardConfigurationPageModel
    {
        private OverlapShapeKind overlapShapeKind;
        private OverlapSize overlapSize;
        private string title;
        private string titleFontFamily;
        private int titleFontSize;
        private OverlapHorizontalAlignment overlapHorizontalAlignment;
        private Xamarin.Forms.Color overlapBackgroundColor;
        private Xamarin.Forms.Color textColor;
        private int pictureSlidePresentationSecounds;

        public LandscapeTranslucentContextualOverlapForImageSecuencePlacardConfigurationPageModel()
        {
            TitleFontSize = 48;

            ContentBlocks = new System.Collections.ObjectModel.ObservableCollection<View.TextContentBlockViewModel>();
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
            AvailableOverlapHorizontalAlignments = new OverlapHorizontalAlignment[]
            {
                OverlapHorizontalAlignment.Left,
                OverlapHorizontalAlignment.Right
            };
        }

        public OverlapShapeKind OverlapShapeKind { get => overlapShapeKind; set => SetProperty(ref overlapShapeKind, value); }

        public OverlapShapeKind[] AvailableOverlapShapeKinds { get; private set; }

        public OverlapSize OverlapSize { get => overlapSize; set => SetProperty(ref overlapSize, value); }

        public OverlapSize[] AvailableOverlapSizes { get; private set; }

        public string Title { get => title; set => SetProperty(ref title, value); }

        public string TitleFontFamily { get => titleFontFamily; set => SetProperty(ref titleFontFamily, value); }

        public int TitleFontSize { get => titleFontSize; set => SetProperty(ref titleFontSize, value); }

        public System.Collections.ObjectModel.ObservableCollection<View.TextContentBlockViewModel> ContentBlocks { get; private set; }

        public OverlapHorizontalAlignment OverlapHorizontalAlignment { get => overlapHorizontalAlignment; set => SetProperty(ref overlapHorizontalAlignment, value); }

        public OverlapHorizontalAlignment[] AvailableOverlapHorizontalAlignments { get; private set; }

        public Xamarin.Forms.Color OverlapBackgroundColor { get => overlapBackgroundColor; set => SetProperty(ref overlapBackgroundColor, value); }

        public Xamarin.Forms.Color TextColor { get => textColor; set => SetProperty(ref textColor, value); }

        public System.Collections.ObjectModel.ObservableCollection<Essential.Templating.Dashboard.Presentation.Models.View.PictureSlideViewModel> PresentedSlides { get; set; }

        public PictureLayoutMode[] AvailableLayoutModes { get; private set; }

        public int PictureSlidePresentationSecounds { get => pictureSlidePresentationSecounds; set => SetProperty(ref pictureSlidePresentationSecounds, value); }
    }
}
