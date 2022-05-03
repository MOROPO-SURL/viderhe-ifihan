using SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Presentation.Enumerations;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page
{
    public class LandscapeTranslucentContextualOverlapForImageSecuencePlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledScreenTimedPlacardConfigurationPageModel
    {
        private Templating.Presentation.Enumerations.OverlapShapeKind overlapShapeKind;
        private Templating.Presentation.Enumerations.OverlapSize overlapSize;
        private string title;
        private string titleFontFamily;
        private int titleFontSize;
        private Templating.Presentation.Enumerations.OverlapHorizontalAlignment overlapHorizontalAlignment;
        private Xamarin.Forms.Color overlapBackgroundColor;
        private Xamarin.Forms.Color textColor;
        private int pictureSlidePresentationSecounds;

        public LandscapeTranslucentContextualOverlapForImageSecuencePlacardConfigurationPageModel()
        {
            TitleFontSize = 48;

            ContentBlocks = new System.Collections.ObjectModel.ObservableCollection<Templating.Presentation.Models.TextContentBlockModel>();
            PictureSlidePresentationSecounds = 10;
            AvailableLayoutModes = new PictureLayoutMode[] { PictureLayoutMode.AspectFit, PictureLayoutMode.AspectFill, PictureLayoutMode.Fill, PictureLayoutMode.AspectFitWithOpaqueAspectFilledBySelf };

            PresentedSlides = new System.Collections.ObjectModel.ObservableCollection<Essential.Templating.Dashboard.Presentation.Models.View.PictureSlideViewModel>();

            AvailableOverlapShapeKinds = new Templating.Presentation.Enumerations.OverlapShapeKind[]
            {
                Templating.Presentation.Enumerations.OverlapShapeKind.Rectangle,
                Templating.Presentation.Enumerations.OverlapShapeKind.TriangleFullTop,
                Templating.Presentation.Enumerations.OverlapShapeKind.TriangleFullBottom
            };
            AvailableOverlapSizes = new Templating.Presentation.Enumerations.OverlapSize[]
            {
                Templating.Presentation.Enumerations.OverlapSize.Short,
                Templating.Presentation.Enumerations.OverlapSize.Medium,
                Templating.Presentation.Enumerations.OverlapSize.Large
            };
        }

        public Templating.Presentation.Enumerations.OverlapShapeKind OverlapShapeKind { get => overlapShapeKind; set => SetProperty(ref overlapShapeKind, value); }

        public Templating.Presentation.Enumerations.OverlapShapeKind[] AvailableOverlapShapeKinds { get; private set; }

        public Templating.Presentation.Enumerations.OverlapSize OverlapSize { get => overlapSize; set => SetProperty(ref overlapSize, value); }

        public Templating.Presentation.Enumerations.OverlapSize[] AvailableOverlapSizes { get; private set; }

        public string Title { get => title; set => SetProperty(ref title, value); }

        public string TitleFontFamily { get => titleFontFamily; set => SetProperty(ref titleFontFamily, value); }

        public int TitleFontSize { get => titleFontSize; set => SetProperty(ref titleFontSize, value); }

        public System.Collections.ObjectModel.ObservableCollection<Templating.Presentation.Models.TextContentBlockModel> ContentBlocks { get; private set; }

        public Templating.Presentation.Enumerations.OverlapHorizontalAlignment OverlapHorizontalAlignment { get => overlapHorizontalAlignment; set => SetProperty(ref overlapHorizontalAlignment, value); }

        public Templating.Presentation.Enumerations.OverlapHorizontalAlignment[] AvailableOverlapHorizontalAlignments { get; private set; }

        public Xamarin.Forms.Color OverlapBackgroundColor { get => overlapBackgroundColor; set => SetProperty(ref overlapBackgroundColor, value); }

        public Xamarin.Forms.Color TextColor { get => textColor; set => SetProperty(ref textColor, value); }

        public System.Collections.ObjectModel.ObservableCollection<Essential.Templating.Dashboard.Presentation.Models.View.PictureSlideViewModel> PresentedSlides { get; set; }

        public Essential.Templating.Presentation.Enumerations.PictureLayoutMode[] AvailableLayoutModes { get; private set; }

        public int PictureSlidePresentationSecounds { get => pictureSlidePresentationSecounds; set => SetProperty(ref pictureSlidePresentationSecounds, value); }
    }
}
