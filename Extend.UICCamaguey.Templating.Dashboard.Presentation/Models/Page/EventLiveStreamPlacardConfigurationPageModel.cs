namespace MOROPO.VIDERHE.Extend.UICCamaguey.Templating.Dashboard.Presentation.Models.Page
{
    public class EventLiveStreamPlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledScreenTimedPlacardConfigurationPageModel
    {
        private string eventTitle;
        private string eventPlace;
        private string streamUrl;

        public EventLiveStreamPlacardConfigurationPageModel()
        {
            ScreenPresentationTimeSecounds = 15;
        }

        public string EventTitle { get => eventTitle; set => SetProperty(ref eventTitle, value); }

        public string EventPlace { get => eventPlace; set => SetProperty(ref eventPlace, value); }

        public string StreamUrl { get => streamUrl; set => SetProperty(ref streamUrl, value); }
    }
}
