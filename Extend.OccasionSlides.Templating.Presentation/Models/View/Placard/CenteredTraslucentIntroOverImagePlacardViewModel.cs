namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Models.View.Placard
{
    public class CenteredTraslucentIntroOverImagePlacardViewModel : Common.Templating.Presentation.Models.View.AbstractScreenTimedPlacardViewModel
    {
        public Block.Contract.AbstractContentBlockViewModel[] ContentBlocks { get; set; }

        public Enumerations.CenteredContentBoxPresentationKind ContentBoxPresentationKind { get; set; }

        public double OverlapOpacity { get; set; }

        public Xamarin.Forms.Color OverlapBackgroundColor { get; set; }

        public Xamarin.Forms.ImageSource HeadImageSource { get; set; }

        public Xamarin.Forms.ImageSource BackgroundImageSource { get; set; }

        public bool BackgroundImageZoomingEnabled { get; set; }
    }
}
