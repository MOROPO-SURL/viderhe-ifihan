namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Models.Context
{
    public class LandscapeTranslucentContextualOverlapForImageSecuencePlacardContextModel : Common.Templating.Models.Context.AbstractPlacardContextModel
    {
        public Enumerations.OverlapShapeKind OverlapShapeKind { get; set; }

        public Enumerations.OverlapSize OverlapSize { get; set; }

        public string Title { get; set; }

        public string TitleFontFamily { get; set; }

        public int TitleFontSize { get; set; }

        public TextContentBlockContextModel[] ContentBlocks { get; set; }

        public Enumerations.OverlapHorizontalAlignment OverlapHorizontalAlignment { get; set; }

        public Essential.Templating.Models.Context.PictureSlideSecuencePlacardContextModel PresentedPictureSlideSecuence { get; set; }

        public string OverlapBackgroundColor { get; set; }

        public string TextColor { get; set; }
    }
}
