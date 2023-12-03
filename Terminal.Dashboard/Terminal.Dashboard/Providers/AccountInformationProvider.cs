using MOROPO.VIDERHE.Terminal.Dashboard.Managers;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Providers
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

        public System.Guid Id => SessionManager.Instance.AccountId;

        public string Name => SessionManager.Instance.AccountName;

        public Xamarin.Forms.ImageSource LogoImageSource => SessionManager.Instance.AccountLogoImageSource;

        public Xamarin.Forms.ImageSource HorizontalSplashImageSource => SessionManager.Instance.AccountHorizontalSplashImageSource;

        public Xamarin.Forms.ImageSource VerticalSplashImageSource => SessionManager.Instance.AccountVerticalSplashImageSource;

        public Xamarin.Forms.Color PrimaryColor => SessionManager.Instance.AccountPrimaryColor;

        public Xamarin.Forms.Color SecoundaryColor => SessionManager.Instance.AccountSecoundaryColor;

        public System.Guid? AccountDefaultOverlayId => SessionManager.Instance.AccountDefaultOverlayId;

        public string AccountSerializedOverlayContext => SessionManager.Instance.AccountSerializedOverlayContext;
    }
}
