namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Dashboard.Presentation.Models.Page.Contract
{
    public abstract class AbstractInteroperablePlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledScreenTimedPlacardConfigurationPageModel
    {
        private string apiServer;
        private bool useSSL;
        private bool allowAnyCertificate;
        private string apiKey;

        public AbstractInteroperablePlacardConfigurationPageModel()
        {
            ScreenPresentationTimeSecounds = 60;
            useSSL = true;
        }

        public string APIServer { get => apiServer; set => SetProperty(ref apiServer, value); }

        public bool UseSSL { get => useSSL; set => SetProperty(ref useSSL, value); }

        public bool AllowAnyCertificate { get => allowAnyCertificate; set => SetProperty(ref allowAnyCertificate, value); }

        public string APIKey { get => apiKey; set => SetProperty(ref apiKey, value); }
    }
}
