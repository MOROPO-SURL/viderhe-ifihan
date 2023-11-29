using MOROPO.SAPRESSC.Core.Api.Connect.Helpers;

namespace SmartSolucionesCuba.Viderhe.Terminal.Player.Managers
{
    public sealed class SessionManager : MOROPO.SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade
    {
        private static SessionManager instance;

        public static SessionManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SessionManager();
                }

                return instance;
            }
        }

        public Models.View.AccountViewModel Account { get; set; }

        public HttpClientHelper HttpClientHelper { get; private set; }

        private SessionManager()
        {
            if (Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.Android)
            {
                HttpClientHelper = new HttpClientHelper(Xamarin.Forms.DependencyService.Get<Providers.Facade.INativeHttpClientHandlerProviderFacade>().Get(), string.Format("{0}://{1}/api/", Support.Presentation.Managers.SessionMemoryManager.Instance.UseSSL ? "https" : "http", Support.Presentation.Managers.SessionMemoryManager.Instance.Host), null, () => ExtraHeaders);
            }
            else
            {
                HttpClientHelper = new HttpClientHelper(string.Format("{0}://{1}/api/", Support.Presentation.Managers.SessionMemoryManager.Instance.UseSSL ? "https" : "http", Support.Presentation.Managers.SessionMemoryManager.Instance.Host), null, () => ExtraHeaders);
            }
        }

        public System.Collections.Generic.KeyValuePair<string, string>[] ExtraHeaders
        {
            get
            {
                return new System.Collections.Generic.KeyValuePair<string, string>[]
                {
                    new System.Collections.Generic.KeyValuePair<string, string>(Cloud.Api.Common.Providers.Constant.SecurityConstantProvider.ACCOUNT_ID_HEADER_KEY, Account?.Id.ToString()),
                    new System.Collections.Generic.KeyValuePair<string, string>(Cloud.Api.Common.Providers.Constant.SecurityConstantProvider.PROTECTED_PLAYER_ID_HEADER_KEY, ConfigurationManager.Instance.ProtectedPlayerId)
                };
            }
        }
    }
}
