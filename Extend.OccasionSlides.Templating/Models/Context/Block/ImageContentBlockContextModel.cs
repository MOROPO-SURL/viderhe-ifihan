namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Models.Context.Block
{
    public class ImageContentBlockContextModel : Contract.AbstractContentBlockContextModel
    {
        public double HeightByScreenVerticalSizePercent { get; set; }

        public Common.Templating.Models.Context.ImageContextModel Image { get; set; }

        public Essential.Templating.Enumerations.PictureLayoutMode LayoutMode { get; set; }

        public Enumerations.ContentHorizontalAlignament? HorizontalAlignament { get; set; }

        public Enumerations.ImageFilterKind? FilterKind { get; set; }

        public string FilterSerializationContext { get; set; }
    }
}
