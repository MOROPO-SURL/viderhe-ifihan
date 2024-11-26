using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Overlaying.Presentation.Enumerations;

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
        private Xamarin.Forms.Color primaryBackgroundColor;
        private Xamarin.Forms.Color primaryTextColor;
        private Xamarin.Forms.Color secondaryBackgroundColor;
        private Xamarin.Forms.Color secoundaryTextColor;
        private Xamarin.Forms.Color accentColor;
        private int prePresentationTime;
        private int postPresentationTime;
        private string preCheckInHeadLabel;
        private string openCheckInLabel;
        private string closedCheckInLabel;
        private bool showClock;
        private DinamicAirportCheckInMonitorInactivePresentationMode inactivePresentationMode;
        private DinamicAirportCheckInMonitorActivePresentationMode activePresentationMode;

        public DinamicAirportCheckInMonitorOverlayConfigurationPageModel()
        {
            updateInterval = 60;
            number = -1;
            prePresentationTime = 0;
            postPresentationTime = 0;
            primaryBackgroundColor = Xamarin.Forms.Color.Black;
            primaryTextColor = Xamarin.Forms.Color.White;
            secondaryBackgroundColor = Xamarin.Forms.Color.LightGray;
            secoundaryTextColor = Xamarin.Forms.Color.DimGray;
            accentColor = Xamarin.Forms.Color.Accent;
            preCheckInHeadLabel = "PROXIMA SALIDA EN CHECK-IN ...";
            openCheckInLabel = "ABIERTO / OPEN";
            closedCheckInLabel = "CERRADO / CERRADO";
        }

        public string APIServer { get => apiServer; set => SetProperty(ref apiServer, value); }

        public bool UseSSL { get => useSSL; set => SetProperty(ref useSSL, value); }

        public bool AllowAnyCertificate { get => allowAnyCertificate; set => SetProperty(ref allowAnyCertificate, value); }

        public string APIKey { get => apiKey; set => SetProperty(ref apiKey, value); }

        public int UpdateInterval { get => updateInterval; set => SetProperty(ref updateInterval, value); }

        public int Number { get => number; set => SetProperty(ref number, value); }

        public int[] AvailableNumbers { get => availableNumbers; set => SetProperty(ref availableNumbers, value); }

        public bool UseCarrierColors { get => useCarrierColors; set => SetProperty(ref useCarrierColors, value); }

        public Xamarin.Forms.Color PrimaryBackgroundColor { get => primaryBackgroundColor; set => SetProperty(ref primaryBackgroundColor, value); }

        public Xamarin.Forms.Color PrimaryTextColor { get => primaryTextColor; set => SetProperty(ref primaryTextColor, value); }

        public Xamarin.Forms.Color SecoundaryBackgroundColor { get => secondaryBackgroundColor; set => SetProperty(ref secondaryBackgroundColor, value); }

        public Xamarin.Forms.Color SecoundaryTextColor { get => secoundaryTextColor; set => SetProperty(ref secoundaryTextColor, value); }

        public Xamarin.Forms.Color AccentColor { get => accentColor; set => SetProperty(ref accentColor, value); }

        public int PrePresentationTime { get => prePresentationTime; set => SetProperty(ref prePresentationTime, value); }

        public int PostPresentationTime { get => postPresentationTime; set => SetProperty(ref postPresentationTime, value); }

        public string PreCheckInHeadLabel { get => preCheckInHeadLabel; set => SetProperty(ref preCheckInHeadLabel, value); }

        public string OpenCheckInLabel { get => openCheckInLabel; set => SetProperty(ref openCheckInLabel, value); }

        public string ClosedCheckInLabel { get => closedCheckInLabel; set => SetProperty(ref closedCheckInLabel, value); }

        public bool ShowClock { get => showClock; set => SetProperty(ref showClock, value); }

        public DinamicAirportCheckInMonitorInactivePresentationMode InactivePresentationMode { get => inactivePresentationMode; set => SetProperty(ref inactivePresentationMode, value); }

        public DinamicAirportCheckInMonitorActivePresentationMode ActivePresentationMode { get => activePresentationMode; set => SetProperty(ref activePresentationMode, value); }

        public DinamicAirportCheckInMonitorInactivePresentationMode[] AvailableInactivePresentationModes { get; } = new DinamicAirportCheckInMonitorInactivePresentationMode[]
        {
            DinamicAirportCheckInMonitorInactivePresentationMode.EdgeNumeric,
            DinamicAirportCheckInMonitorInactivePresentationMode.FloatNumeric,
            DinamicAirportCheckInMonitorInactivePresentationMode.NoNumeric
        };

        public DinamicAirportCheckInMonitorActivePresentationMode[] AvailableActivePresentationModes { get; } = new DinamicAirportCheckInMonitorActivePresentationMode[]
        {
            DinamicAirportCheckInMonitorActivePresentationMode.CheckInTimes,
            DinamicAirportCheckInMonitorActivePresentationMode.FlyTimes
        };
    }
}
