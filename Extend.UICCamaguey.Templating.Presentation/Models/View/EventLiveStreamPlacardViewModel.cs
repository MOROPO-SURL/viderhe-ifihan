namespace SmartSolucionesCuba.Viderhe.Extend.UICCamaguey.Templating.Presentation.Models.View
{
    public class EventLiveStreamPlacardViewModel : Common.Templating.Presentation.Models.View.AbstractScreenTimedPlacardViewModel
    {
        public string EventTitle { get; set; }

        public string EventPlace { get; set; }

        public XFToolKit.Presentation.Sources.Video.VideoSource VideoSource { get; set; }
    }
}
