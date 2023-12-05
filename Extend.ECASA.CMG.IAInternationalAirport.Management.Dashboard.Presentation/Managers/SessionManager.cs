using System.Collections.Generic;

namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Managers
{
    public class SessionManager : Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade
    {
        private const string LAST_INTEROP_SERVER_KEY = "last-interop-fids-server";
        private const string LAST_INTEROP_USE_SSL_KEY = "last-interop-fids-ssl";
        private const string LAST_INTEROP_ALLOW_CERTIFICATE_KEY = "last-interop-fids-certificate";
        private const string LAST_INTEROP_API_TOKEN_KEY = "last-interop-fids-apikey";

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

        private SessionManager()
        {
            if (Xamarin.Forms.Application.Current.Properties.ContainsKey(LAST_INTEROP_SERVER_KEY))
            {
                Server = Xamarin.Forms.Application.Current.Properties[LAST_INTEROP_SERVER_KEY] as string;
            }
            else
            {
                Server = "fids.service.viderhe.net";
            }

            if (Xamarin.Forms.Application.Current.Properties.ContainsKey(LAST_INTEROP_USE_SSL_KEY))
            {
                UseSSL = (bool)Xamarin.Forms.Application.Current.Properties[LAST_INTEROP_USE_SSL_KEY];
            }
            else
            {
                UseSSL = true;
            }

            if (Xamarin.Forms.Application.Current.Properties.ContainsKey(LAST_INTEROP_ALLOW_CERTIFICATE_KEY))
            {
                AllowAnyCertificate = (bool)Xamarin.Forms.Application.Current.Properties[LAST_INTEROP_ALLOW_CERTIFICATE_KEY];
            }
            else
            {
                AllowAnyCertificate = false;
            }

            if (Xamarin.Forms.Application.Current.Properties.ContainsKey(LAST_INTEROP_API_TOKEN_KEY))
            {
                APIKeyToken = Xamarin.Forms.Application.Current.Properties[LAST_INTEROP_API_TOKEN_KEY] as string;
            }
            else
            {
                APIKeyToken = null;
            }

            if (Server == null || APIKeyToken == null) return;

            InitializeHttpClientHelper();
        }

        public Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper HttpClientHelper { get; private set; }

        public string Server { get; private set; }

        public bool UseSSL { get; private set; }

        public bool AllowAnyCertificate { get; private set; }

        public string APIKeyToken { get; private set; }

        public async System.Threading.Tasks.Task ConfigureAsync(string server, string apiKeyToken, bool useSSL, bool allowAnyCertificate)
        {
            Server = server;
            UseSSL = useSSL;
            AllowAnyCertificate = allowAnyCertificate;
            APIKeyToken = apiKeyToken;

            Xamarin.Forms.Application.Current.Properties[LAST_INTEROP_SERVER_KEY] = Server;
            Xamarin.Forms.Application.Current.Properties[LAST_INTEROP_USE_SSL_KEY] = UseSSL;
            Xamarin.Forms.Application.Current.Properties[LAST_INTEROP_ALLOW_CERTIFICATE_KEY] = AllowAnyCertificate;
            Xamarin.Forms.Application.Current.Properties[LAST_INTEROP_API_TOKEN_KEY] = APIKeyToken;

            await Xamarin.Forms.Application.Current.SavePropertiesAsync();

            InitializeHttpClientHelper();
        }

        private KeyValuePair<string, string>[] GetExtraHeaders()
        {
            return new KeyValuePair<string, string>[] { new KeyValuePair<string, string>(Service.ECASA.CMG.InterFIDS.API.Common.Constants.Authentication.API_KEY_HEADER_PROPERTY, APIKeyToken) };
        }

        private void InitializeHttpClientHelper()
        {
            if (UseSSL && AllowAnyCertificate)
            {
                HttpClientHelper = new Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper(new System.Net.Http.HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (message, certificate, chain, errors) => true
                }, string.Format("{0}://{1}/api/", UseSSL ? "https" : "http", Server), null, GetExtraHeaders);
            }
            else
            {
                HttpClientHelper = new Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper(string.Format("{0}://{1}/api/", UseSSL ? "https" : "http", Server), null, GetExtraHeaders);
            }
        }
    }
}
