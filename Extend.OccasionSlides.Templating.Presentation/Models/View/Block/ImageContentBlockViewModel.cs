namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Models.View.Block
{
    public class ImageContentBlockViewModel : Contract.AbstractContentBlockViewModel, Contract.IScreenVerticalSizePercentCalculableContentBlockViewModel
    {
        private Support.Presentation.Models.View.ImageViewModel image;

        public double HeightByScreenVerticalSizePercent { get; set; }

        public Support.Presentation.Models.View.ImageViewModel Image { get => image; set => SetProperty(ref image, value); }

        public Xamarin.Forms.Aspect LayoutMode { get; set; }

        public Xamarin.Forms.LayoutAlignment HorizontalAlignament { get; set; }

        public Enumerations.ImageFilterKind? FilterKind { get; set; }

        public string FilterSerializationContext { get; set; }
    }
}
