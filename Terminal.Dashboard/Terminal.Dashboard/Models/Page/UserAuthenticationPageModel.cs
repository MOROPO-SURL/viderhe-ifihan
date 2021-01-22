namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Models.Page
{
    public class UserAuthenticationPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private string targetCloudHostName;

        private string userName;

        private string password;

        public string TargetCloudHostName
        {
            get => targetCloudHostName;
            set => SetProperty(ref targetCloudHostName, value);
        }

        public string UserName
        {
            get => userName;
            set => SetProperty(ref userName, value);
        }

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }
    }
}
