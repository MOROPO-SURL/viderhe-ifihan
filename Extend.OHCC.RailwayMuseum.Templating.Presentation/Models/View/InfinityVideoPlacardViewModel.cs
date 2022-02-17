namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Presentation.Models.View
{
    public class InfinityVideoPlacardViewModel : Common.Templating.Presentation.Models.View.AbstractPlacardViewModel
    {
        public XFToolKit.Presentation.Sources.Video.VideoSource VideoSource { get; set; }

        public Xamarin.Forms.ImageSource VideoThumbnailImageSource { get; set; }

        public int StartMargin { get; set; }

        public int EndMargin { get; set; }
    }
}
