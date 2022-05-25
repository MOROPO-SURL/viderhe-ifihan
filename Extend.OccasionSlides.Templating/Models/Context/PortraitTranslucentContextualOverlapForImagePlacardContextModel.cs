namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Models.Context
{
    public class PortraitTranslucentContextualOverlapForImagePlacardContextModel : Common.Templating.Models.Context.AbstractScreenTimedPlacardContextModel
    {
        public Enumerations.OverlapShapeKind OverlapShapeKind { get; set; }

        public string Title { get; set; }

        public string TitleFontFamily { get; set; }

        public int TitleFontSize { get; set; }

        public TextContentBlockContextModel[] ContentBlocks { get; set; }

        public Enumerations.OverlapVerticalAlignment OverlapVerticalAlignment { get; set; }

        public Common.Templating.Models.Context.ImageContextModel ContextedImage { get; set; }

        public bool ContextedImageZoomingEnabled { get; set; }

        public string OverlapBackgroundColor { get; set; }

        public string TextColor { get; set; }
    }
}
