namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Presentation.Models.Context
{
    public class PhotoEventPlacardContextModel : Common.Templating.Presentation.Models.Context.AbstractScreenTimedPlacardContextModel
    {
        public string Title { get; set; }

        public string When { get; set; }

        public string Where { get; set; }

        public string About { get; set; }

        public Common.Templating.Presentation.Models.Context.ImageContextModel Image { get; set; }

        public Xamarin.Forms.Aspect ImageAspect { get; set; }

        public bool ImageZoomingEnabled { get; set; }
    }
}
