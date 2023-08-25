using System.Collections.Generic;

namespace SmartSolucionesCuba.Viderhe.Extend.HotelOTT.Management.Dashboard.Presentation.Managers
{
    public class SessionManager : MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade
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

        private SessionManager()
        {
#if DEBUG
            Configure("localhost:5071", "3f85dc10ff3f273c743ad32e1b42951e4b9568228e98f6cc707a7c8255d56326");
#endif
        }

        public MOROPO.Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper HttpClientHelper { get; private set; }

        private string apiKeyToken;

        public void Configure(string server, string apiKeyToken, bool isPersistent = false)
        {
            this.apiKeyToken = apiKeyToken;

            HttpClientHelper = new MOROPO.Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper(string.Format("http://{0}/api/", server), null, GetExtraHeaders);
        }

        public KeyValuePair<string, string>[] GetExtraHeaders()
        {
            return new KeyValuePair<string, string>[] { new KeyValuePair<string, string>(MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Constants.Authorization.API_KEY_HEADER_PROPERTY, apiKeyToken) };
        }
    }
}
