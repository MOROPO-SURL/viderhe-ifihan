using SmartSolucionesCuba.Viderhe.Support.Presentation.Models.View;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Models.View.Block
{
    public class ImageSetContentBlockViewModel : Contract.AbstractContentBlockViewModel, Contract.IScreenVerticalSizePercentCalculableContentBlockViewModel
    {
        public double HeightByScreenVerticalSizePercent { get; set; }

        public double ImageSeparationWidthByScreenVerticalSizePercent { get; set; }

        public ImageViewModel[] Images { get; set; }

        // TODO Incluir soporte para filtro a las imagenes

        public Xamarin.Forms.LayoutAlignment HorizontalAlignament { get; set; }
    }
}
