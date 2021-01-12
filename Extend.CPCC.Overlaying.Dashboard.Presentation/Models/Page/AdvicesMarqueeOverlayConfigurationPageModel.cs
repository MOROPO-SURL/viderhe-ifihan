namespace SmartSolucionesCuba.Videre.Extend.CPCC.Overlaying.Dashboard.Presentation.Models.Page
{
    public class AdvicesMarqueeOverlayConfigurationPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private string serverName;
        private bool isSecureServer;
        private string head;
        private string tail;
        private string adviseSeparator;

        public string ServerName { get => serverName; set => SetProperty(ref serverName, value); }

        public bool IsSecureServer { get => isSecureServer; set => SetProperty(ref isSecureServer, value); }

        public string Head { get => head; set => SetProperty(ref head, value); }

        public string Tail { get => tail; set => SetProperty(ref tail, value); }

        public string AdviseSeparator { get => adviseSeparator; set => SetProperty(ref adviseSeparator, value); }
    }
}
