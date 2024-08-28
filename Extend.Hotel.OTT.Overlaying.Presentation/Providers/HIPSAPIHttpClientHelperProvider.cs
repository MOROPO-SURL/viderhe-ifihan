using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Helpers;

namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Overlaying.Presentation.Providers
{
    public class HIPSAPIHttpClientHelperProvider : Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade
    {
        private static HIPSAPIHttpClientHelperProvider instance;

        public static HIPSAPIHttpClientHelperProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HIPSAPIHttpClientHelperProvider();
                }

                return instance;
            }
        }

        private HttpClientHelper httpClientHelper;

        public HIPSAPIHttpClientHelperProvider()
        {
            BaseUrl = "http://127.0.0.1:5251/";

            httpClientHelper = new HttpClientHelper(BaseUrl);
        }

        public HttpClientHelper HttpClientHelper => httpClientHelper;

        public string BaseUrl { get; private set; }
    }
}
