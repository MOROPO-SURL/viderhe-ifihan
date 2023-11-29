[assembly: Xamarin.Forms.Dependency(typeof(SmartSolucionesCuba.Viderhe.Terminal.Player.Droid.Providers.NativeHttpClientHandlerProvider))]

namespace SmartSolucionesCuba.Viderhe.Terminal.Player.Droid.Providers
{
    public sealed class NativeHttpClientHandlerProvider : Player.Providers.Facade.INativeHttpClientHandlerProviderFacade
    {
        public System.Net.Http.HttpClientHandler Get()
        {
            return new Xamarin.Android.Net.AndroidClientHandler();
        }
    }
}