namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Presentation.Models.Context
{
    public class SimplePicturePlacardContextModel : Common.Templating.Presentation.Models.Context.AbstractScreenTimedPlacardContextModel
    {
        public SimplePicturePlacardContextModel()
        {
            ZoomingEnabled = false;
        }

        public Common.Templating.Presentation.Models.Context.ImageContextModel Image { get; set; }

        public Xamarin.Forms.Aspect Aspect { get; set; }

        public bool ZoomingEnabled { get; set; }
    }
}
