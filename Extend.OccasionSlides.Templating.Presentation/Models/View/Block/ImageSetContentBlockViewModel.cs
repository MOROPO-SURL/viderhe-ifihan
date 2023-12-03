using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Models.View.Block.Contract;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Models.View.Block
{
    public class ImageSetContentBlockViewModel : AbstractContentBlockViewModel, IScreenVerticalSizePercentCalculableContentBlockViewModel
    {
        public double HeightByScreenVerticalSizePercent { get; set; }

        public double ImageSeparationWidthByScreenVerticalSizePercent { get; set; }

        public Support.Presentation.Models.View.ImageViewModel[] Images { get; set; }

        // TODO Incluir soporte para filtro a las imagenes

        public Xamarin.Forms.LayoutAlignment HorizontalAlignament { get; set; }
    }
}
