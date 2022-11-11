namespace SmartSolucionesCuba.Viderhe.Extend.UICCamaguey.Templating.Presentation.Providers
{
    internal sealed class IoTSyncReceptorApiHttpClientHelperProvider : SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade
    {
        private readonly SAPRESSC.Core.Api.Connect.Helpers.HttpClientHelper httpClientHelper;

        internal IoTSyncReceptorApiHttpClientHelperProvider(System.Uri uri)
        {
            httpClientHelper = new SAPRESSC.Core.Api.Connect.Helpers.HttpClientHelper(uri.ToString());
        }

        public SAPRESSC.Core.Api.Connect.Helpers.HttpClientHelper HttpClientHelper => httpClientHelper;
    }
}
