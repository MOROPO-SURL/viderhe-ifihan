namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Models.Context
{
    public class LandscapeTranslucentContextualOverlapForImageSecuencePlacardContextModel : Common.Templating.Presentation.Models.Context.AbstractPlacardContextModel
    {
        public Enumerations.OverlapShapeKind OverlapShapeKind { get; set; }

        public Enumerations.OverlapSize OverlapSize { get; set; }

        public string Title { get; set; }

        public string TitleFontFamily { get; set; }

        public int TitleFontSize { get; set; }

        public TextContentBlockModel[] ContentBlocks { get; set; }

        public Enumerations.OverlapHorizontalAlignment OverlapHorizontalAlignment { get; set; }

        public Essential.Templating.Presentation.Models.Context.PictureSlideSecuencePlacardContextModel PresentedPictureSlideSecuence { get; set; }

        public string OverlapBackgroundColor { get; set; }

        public string TextColor { get; set; }
    }
}
