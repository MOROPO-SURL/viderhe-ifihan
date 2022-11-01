namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Models.View.Block
{
    public class ImageContentBlockViewModel : Contract.AbstractContentBlockViewModel, Contract.IScreenVerticalSizePercentCalculableContentBlockViewModel
    {
        public double HeightByScreenVerticalSizePercent { get; set; }

        public Support.Presentation.Models.View.ImageViewModel Image { get; set; }

        public Xamarin.Forms.Aspect LayoutMode { get; set; }

        public Xamarin.Forms.LayoutAlignment HorizontalAlignament { get; set; }

        public Enumerations.ImageFilterKind? FilterKind { get; set; }

        public string FilterSerializationContext { get; set; }
    }
}
