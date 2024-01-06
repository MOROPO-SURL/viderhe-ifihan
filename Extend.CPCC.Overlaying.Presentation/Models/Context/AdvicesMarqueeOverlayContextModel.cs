namespace MOROPO.VIDERHE.Extend.CPCC.Overlaying.Presentation.Models.Context
{
    public class AdvicesMarqueeOverlayContextModel
    {
        public string ServerName { get; set; }

        public bool IsSecureServer { get; set; }

        public bool IsRequiredSecurityStrict { get; set; }

        public string Head { get; set; }

        public string Tail { get; set; }

        public string Separator { get; set; }

        public string FailbackMessage { get; set; }
    }
}
