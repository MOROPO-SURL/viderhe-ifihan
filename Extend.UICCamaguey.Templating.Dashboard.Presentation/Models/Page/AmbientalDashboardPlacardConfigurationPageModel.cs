namespace SmartSolucionesCuba.Viderhe.Extend.UICCamaguey.Templating.Dashboard.Presentation.Models.Page
{
    public class AmbientalDashboardPlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledScreenTimedPlacardConfigurationPageModel
    {
        private string ioTPlatformEndpointBaseUri;

        public string IoTPlatformEndpointBaseUri { get => ioTPlatformEndpointBaseUri; set => SetProperty(ref ioTPlatformEndpointBaseUri, value); }
    }
}
