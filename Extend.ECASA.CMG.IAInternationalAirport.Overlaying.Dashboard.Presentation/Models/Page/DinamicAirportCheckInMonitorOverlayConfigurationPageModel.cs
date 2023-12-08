namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Overlaying.Dashboard.Presentation.Models.Page
{
    public class DinamicAirportCheckInMonitorOverlayConfigurationPageModel : Support.Presentation.Dashboard.Models.Page.FormPageModel
    {
        private string apiServer;
        private bool useSSL;
        private bool allowAnyCertificate;
        private string apiKey;
        private int updateInterval;
        private int number;
        private int[] availableNumbers;
        private bool useCarrierColors;
        private Xamarin.Forms.Color backgroundColor;
        private Xamarin.Forms.Color accentColor;
        private int prePresentationTime;
        private int postPresentationTime;

        public DinamicAirportCheckInMonitorOverlayConfigurationPageModel()
        {
            updateInterval = 60;
            Number = -1;
            backgroundColor = Xamarin.Forms.Color.White;
            accentColor = Xamarin.Forms.Color.CadetBlue;
        }

        public string APIServer { get => apiServer; set => SetProperty(ref apiServer, value); }

        public bool UseSSL { get => useSSL; set => SetProperty(ref useSSL, value); }

        public bool AllowAnyCertificate { get => allowAnyCertificate; set => SetProperty(ref allowAnyCertificate, value); }

        public string APIKey { get => apiKey; set => SetProperty(ref apiKey, value); }

        public int UpdateInterval { get => updateInterval; set => SetProperty(ref updateInterval, value); }

        public int Number { get => number; set => SetProperty(ref number, value); }

        public int[] AvailableNumbers { get => availableNumbers; set => SetProperty(ref availableNumbers, value); }

        public bool UseCarrierColors { get => useCarrierColors; set => SetProperty(ref useCarrierColors, value); }

        public Xamarin.Forms.Color BackgroundColor { get => backgroundColor; set => SetProperty(ref backgroundColor, value); }

        public Xamarin.Forms.Color AccentColor { get => accentColor; set => SetProperty(ref accentColor, value); }

        public int PrePresentationTime { get => prePresentationTime; set => SetProperty(ref prePresentationTime, value); }

        public int PostPresentationTime { get => postPresentationTime; set => SetProperty(ref postPresentationTime, value); }
    }
}
