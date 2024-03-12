namespace MOROPO.VIDERHE.Extend.UICCamaguey.Templating.Dashboard.Presentation.Models.Page
{
    public class AmbientalDashboardPlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledScreenTimedPlacardConfigurationPageModel
    {
        private string ioTPlatformEndpointBaseUri;
        private Enumerations.AmbientalVariable ambientalVariable;

        public AmbientalDashboardPlacardConfigurationPageModel()
        {
            ScreenPresentationTimeSecounds = 15;

            AvailableAmbientalVariables = new Enumerations.AmbientalVariable[]
            {
                Enumerations.AmbientalVariable.Temperature,
                Enumerations.AmbientalVariable.Humidity,
                Enumerations.AmbientalVariable.SmogPPM
            };
        }

        public string IoTPlatformEndpointBaseUri { get => ioTPlatformEndpointBaseUri; set => SetProperty(ref ioTPlatformEndpointBaseUri, value); }

        public Enumerations.AmbientalVariable AmbientalVariable { get => ambientalVariable; set => SetProperty(ref ambientalVariable, value); }

        public Enumerations.AmbientalVariable[] AvailableAmbientalVariables { get; set; }
    }
}
