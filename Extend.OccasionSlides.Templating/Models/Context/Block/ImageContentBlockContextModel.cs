using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Enumerations;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Models.Context.Block
{
    public class ImageContentBlockContextModel : Contract.AbstractContentBlockContextModel
    {
        public double HeightByScreenVerticalSizePercent { get; set; }

        public Common.Templating.Models.Context.ImageContextModel Image { get; set; }

        public Essential.Templating.Enumerations.PictureLayoutMode LayoutMode { get; set; }

        public ContentHorizontalAlignament? HorizontalAlignament { get; set; }

        public ImageFilterKind? FilterKind { get; set; }

        public string FilterSerializationContext { get; set; }
    }
}
