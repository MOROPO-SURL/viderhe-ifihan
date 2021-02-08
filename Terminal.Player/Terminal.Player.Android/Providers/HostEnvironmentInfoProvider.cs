[assembly: Xamarin.Forms.Dependency(typeof(SmartSolucionesCuba.Viderhe.Terminal.Player.Droid.Providers.HostEnvironmentInfoProvider))]

namespace SmartSolucionesCuba.Viderhe.Terminal.Player.Droid.Providers
{
    public class HostEnvironmentInfoProvider : Player.Providers.Facade.IHostEnvironmentInfoProviderFacade
    {
        public string GetHardwareIdentifier()
        {
            return Android.OS.Build.Serial;
        }
    }
}