namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Models.View
{
    public class LandscapeTranslucentContextualOverlapForImageSecuencePlacardViewModel : Common.Templating.Presentation.Models.View.AbstractPlacardViewModel
    {
        public Enumerations.OverlapShapeKind OverlapShapeKind { get; set; }

        public Enumerations.OverlapSize OverlapSize { get; set; }

        public string Title { get; set; }

        public string TitleFontFamily { get; set; }

        public int TitleFontSize { get; set; }

        public Templating.Models.Context.TextContentBlockContextModel[] ContentBlocks { get; set; }

        public Enumerations.OverlapHorizontalAlignment OverlapHorizontalAlignment { get; set; }

        public Essential.Templating.Models.Context.PictureSlideSecuencePlacardContextModel PresentedPictureSlideSecuence { get; set; }

        public Xamarin.Forms.Color OverlapBackgroundColor { get; set; }

        public Xamarin.Forms.Color TextColor { get; set; }
    }
}
