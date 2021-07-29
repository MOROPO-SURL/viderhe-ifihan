namespace SmartSolucionesCuba.Viderhe.Terminal.Player.Providers
{
    public class AccountInformationProvider : Extend.Common.Presentation.Providers.Facade.IAccountInformationProviderFacade
    {
        private static AccountInformationProvider instance;

        public static AccountInformationProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountInformationProvider();
                }

                return instance;
            }
        }

        public System.Guid Id => Managers.SessionManager.Instance.AccountId;

        public string Name => Managers.SessionManager.Instance.AccountName;

        public Xamarin.Forms.ImageSource LogoImageSource => Managers.SessionManager.Instance.AccountLogoImageSource;

        public Xamarin.Forms.ImageSource HorizontalSplashImageSource => Managers.SessionManager.Instance.AccountHorizontalSplashImageSource;

        public Xamarin.Forms.ImageSource VerticalSplashImageSource => Managers.SessionManager.Instance.AccountVerticalSplashImageSource;

        public Xamarin.Forms.Color PrimaryColor => Managers.SessionManager.Instance.AccountPrimaryColor;

        public Xamarin.Forms.Color SecoundaryColor => Managers.SessionManager.Instance.AccountSecoundaryColor;

        public System.Guid? AccountDefaultOverlayId => Managers.SessionManager.Instance.AccountDefaultOverlayId;

        public string AccountSerializedOverlayContext => Managers.SessionManager.Instance.AccountSerializedOverlayContext;
    }
}
