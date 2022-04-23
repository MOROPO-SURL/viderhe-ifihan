namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Models.Context
{
    public class CenteredTraslucentIntroOverImagePlacardContextModel : Common.Templating.Presentation.Models.Context.AbstractScreenTimedPlacardContextModel
    {
        public string Title { get; set; }

        public string TitleFontFamily { get; set; }

        public int TitleFontSize { get; set; }

        public TextContentBlockModel[] ContentBlocks { get; set; }

        public Enumerations.CenteredContentBoxPresentationKind ContentBoxPresentationKind { get; set; }

        public double OverlapOpacity { get; set; }

        public string OverlapBackgroundColor { get; set; }

        public string TextColor { get; set; }

        public Common.Templating.Presentation.Models.Context.ImageContextModel HeadImage { get; set; }

        public Common.Templating.Presentation.Models.Context.ImageContextModel BackgroundImage { get; set; }

        public bool BackgroundImageZoomingEnabled { get; set; }
    }
}
