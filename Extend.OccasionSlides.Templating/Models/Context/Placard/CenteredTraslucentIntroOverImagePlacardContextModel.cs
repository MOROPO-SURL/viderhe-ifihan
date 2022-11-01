namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Models.Context.Placard
{
    public class CenteredTraslucentIntroOverImagePlacardContextModel : Common.Templating.Models.Context.AbstractScreenTimedPlacardContextModel
    {
        public Block.Contract.AbstractContentBlockContextModel[] ContentBlocks { get; set; }

        public Enumerations.CenteredContentBoxPresentationKind ContentBoxPresentationKind { get; set; }

        public double OverlapOpacity { get; set; }

        public string OverlapBackgroundColor { get; set; }

        public Common.Templating.Models.Context.ImageContextModel HeadImage { get; set; }

        public Common.Templating.Models.Context.ImageContextModel BackgroundImage { get; set; }

        public bool BackgroundImageZoomingEnabled { get; set; }
    }
}
