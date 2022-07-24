namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Models.Context.Placard
{
    public class CenteredTraslucentIntroOverImagePlacardContextModel : Common.Templating.Models.Context.AbstractScreenTimedPlacardContextModel
    {
        public string Title { get; set; }

        public string TitleFontFamily { get; set; }

        public int TitleFontSize { get; set; }

        public TextContentBlockContextModel[] ContentBlocks { get; set; }

        public Enumerations.CenteredContentBoxPresentationKind ContentBoxPresentationKind { get; set; }

        public double OverlapOpacity { get; set; }

        public string OverlapBackgroundColor { get; set; }

        public string TextColor { get; set; }

        public Common.Templating.Models.Context.ImageContextModel HeadImage { get; set; }

        public Common.Templating.Models.Context.ImageContextModel BackgroundImage { get; set; }

        public bool BackgroundImageZoomingEnabled { get; set; }
    }
}
