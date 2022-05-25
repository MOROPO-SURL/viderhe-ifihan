namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Models.Context
{
    public class SimplePicturePlacardContextModel : Common.Templating.Models.Context.AbstractScreenTimedPlacardContextModel
    {
        public SimplePicturePlacardContextModel()
        {
            IsZoomingEnabled = false;
        }

        public Common.Templating.Models.Context.ImageContextModel Image { get; set; }

        public Enumerations.PictureLayoutMode LayoutMode { get; set; }

        public bool IsZoomingEnabled { get; set; }
    }
}
