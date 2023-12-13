namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Overlaying.Presentation.Models.Context
{
    public class DinamicAirportCheckInMonitorOverlayContextModel
    {
        public int Number { get; set; }

        public string APIServer { get; set; }

        public bool UseSSL { get; set; }

        public bool AllowAnyCertificate { get; set; }

        public string APIKey { get; set; }

        public int UpdateInterval { get; set; }

        public bool UseCarrierColors { get; set; }

        public string BackgroundColor { get; set; }

        public string AccentColor { get; set; }

        public int PrePresentationTime { get; set; }

        public int PostPresentationTime { get; set; }

        public string PreCheckInHeadLabel { get; set; }

        public string OpenCheckInLabel { get; set; }

        public string ClosedCheckInLabel { get; set; }
    }
}
