namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Models.Context.Block
{
    public class ImageSetContentBlockContextModel : Contract.AbstractContentBlockContextModel
    {
        public double HeightByScreenVerticalSizePercent { get; set; }

        public double ImageSeparationWidthByScreenVerticalSizePercent { get; set; }

        public Common.Templating.Models.Context.ImageContextModel[] Images { get; set; }

        // TODO Incluir soporte para filtro a las imagenes

        public Enumerations.ContentHorizontalAlignament HorizontalAlignament { get; set; }
    }
}
