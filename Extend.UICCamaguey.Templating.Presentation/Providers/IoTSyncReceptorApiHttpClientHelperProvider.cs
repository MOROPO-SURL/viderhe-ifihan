namespace SmartSolucionesCuba.Viderhe.Extend.UICCamaguey.Templating.Presentation.Providers
{
    internal sealed class IoTSyncReceptorApiHttpClientHelperProvider : MOROPO.SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade
    {
        private readonly MOROPO.SAPRESSC.Core.Api.Connect.Helpers.HttpClientHelper httpClientHelper;

        internal IoTSyncReceptorApiHttpClientHelperProvider(System.Uri uri)
        {
            httpClientHelper = new MOROPO.SAPRESSC.Core.Api.Connect.Helpers.HttpClientHelper(uri.ToString());
        }

        public MOROPO.SAPRESSC.Core.Api.Connect.Helpers.HttpClientHelper HttpClientHelper => httpClientHelper;
    }
}
