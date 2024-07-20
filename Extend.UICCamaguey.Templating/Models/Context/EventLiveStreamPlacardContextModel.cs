namespace MOROPO.VIDERHE.Extend.UICCamaguey.Templating.Models.Context
{
    public class EventLiveStreamPlacardContextModel : Common.Templating.Models.Context.AbstractScreenTimedPlacardContextModel
    {
        public string EventTitle { get; set; }

        public string EventPlace { get; set; }

        public string StreamUrl { get; set; }

        public bool IsFullScreen { get; set; }
    }
}
