namespace SmartSolucionesCuba.Viderhe.Extend.CPCC.Overlaying.Dashboard.Presentation.Models.Page
{
    public class AdvicesMarqueeOverlayConfigurationPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private string serverName;
        private bool isSecureServer;
        private bool isRequiredSecurityStrict;
        private string head;
        private string tail;
        private string separator;
        private string failbackMessage;

        public string ServerName { get => serverName; set => SetProperty(ref serverName, value); }

        public bool IsSecureServer { get => isSecureServer; set => SetProperty(ref isSecureServer, value); }

        public bool IsRequiredSecurityStrict { get => isRequiredSecurityStrict; set => SetProperty(ref isRequiredSecurityStrict, value); }

        public string Head { get => head; set => SetProperty(ref head, value); }

        public string Tail { get => tail; set => SetProperty(ref tail, value); }

        public string Separator { get => separator; set => SetProperty(ref separator, value); }

        public string FailbackMessage { get => failbackMessage; set => SetProperty(ref failbackMessage, value); }
    }
}
