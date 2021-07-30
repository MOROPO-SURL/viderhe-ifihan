namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Presentation.Models.Context
{
    public class SimplePicturePlacardContextModel : Common.Templating.Presentation.Models.Context.AbstractScreenTimedPlacardContextModel
    {
        public SimplePicturePlacardContextModel()
        {
            IsZoomingEnabled = false;
        }

        public Common.Templating.Presentation.Models.Context.ImageContextModel Image { get; set; }

        public Enumerations.PictureLayoutMode LayoutMode { get; set; }

        public bool IsZoomingEnabled { get; set; }
    }
}
