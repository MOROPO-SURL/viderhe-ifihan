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
        public string AuthenticationType { get; set; }
        public string AuthenticationToken { get; set; }

        public MOROPO.SAPRESSC.Core.Api.Connect.Helpers.HttpClientHelper HttpClientHelper
        {
            get
            {
                System.Func<System.Collections.Generic.KeyValuePair<string, string>> authorizationFunction = null;

                if (!string.IsNullOrEmpty(AuthenticationToken))
                {
                    authorizationFunction = GetAuthorizeHeader;
                }

                return new MOROPO.SAPRESSC.Core.Api.Connect.Helpers.HttpClientHelper(string.Format("{0}://{1}/api/", Support.Presentation.Managers.SessionMemoryManager.Instance.UseSSL ? "https" : "http", Support.Presentation.Managers.SessionMemoryManager.Instance.Host), authorizationFunction, GetExtraHeaders);
            }
        }

        private System.Collections.Generic.KeyValuePair<string, string> GetAuthorizeHeader()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>(AuthenticationType, AuthenticationToken);
        }

        public System.Collections.Generic.KeyValuePair<string, string>[] GetExtraHeaders()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>[]
            {
                new System.Collections.Generic.KeyValuePair<string, string>(Cloud.Api.Common.Providers.Constant.SecurityConstantProvider.ACCOUNT_ID_HEADER_KEY, Account?.Id.ToString()),
                new System.Collections.Generic.KeyValuePair<string, string>(Cloud.Api.Common.Providers.Constant.SecurityConstantProvider.PROTECTED_PLAYER_ID_HEADER_KEY, ConfigurationManager.Instance.ProtectedPlayerId)
            };
        }
    }
}
