using MOROPO.VIDERHE.Terminal.Player.Providers.Facade;

[assembly: Xamarin.Forms.Dependency(typeof(MOROPO.VIDERHE.Terminal.Player.Droid.Providers.NativeHttpClientHandlerProvider))]

namespace MOROPO.VIDERHE.Terminal.Player.Droid.Providers
{
    public sealed class NativeHttpClientHandlerProvider : INativeHttpClientHandlerProviderFacade
    {
        public System.Net.Http.HttpClientHandler Get()
        {
            return new Xamarin.Android.Net.AndroidClientHandler();
        }
    }
}