namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Overlaying.Presentation.Models.Context
{
    public class DinamicAirportCheckInMonitorOverlayContextModel
    {
        private System.DateTime nowAt;

        public int Number { get; set; }

        public System.DateTime NowAt { get => nowAt; set => nowAt = value; }

        public string APIServer { get; set; }

        public bool UseSSL { get; set; }

        public bool AllowAnyCertificate { get; set; }

        public string APIKey { get; set; }

        public int UpdateInterval { get; set; }

        public bool UseCarrierColors { get; set; }

        public string PrimaryBackgroundColor { get; set; }

        public string PrimaryTextColor { get; set; }

        public string SecoundaryBackgroundColor { get; set; }

        public string SecoundaryTextColor { get; set; }

        public string AccentColor { get; set; }

        public int PrePresentationTime { get; set; }

        public int PostPresentationTime { get; set; }

        public string PreCheckInHeadLabel { get; set; }

        public string OpenCheckInLabel { get; set; }

        public string ClosedCheckInLabel { get; set; }

        public bool ShowClock { get; set; }
    }
}
