using System.Linq;

[assembly: Xamarin.Forms.Dependency(typeof(SmartSolucionesCuba.Viderhe.Terminal.Player.Droid.Providers.HostEnvironmentInfoProvider))]

namespace SmartSolucionesCuba.Viderhe.Terminal.Player.Droid.Providers
{
    public class HostEnvironmentInfoProvider : Player.Providers.Facade.IHostEnvironmentInfoProviderFacade
    {
        public string GetHardwareIdentifier()
        {
            var result = Android.OS.Build.Serial;

            if (result != null && result != Android.OS.Build.Unknown) return result;

            result = Android.Provider.Settings.Secure.GetString(Android.App.Application.Context.ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            if (result != null) return result;

            var networkInterfaces = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces().Where(item => item.NetworkInterfaceType == System.Net.NetworkInformation.NetworkInterfaceType.Ethernet || item.NetworkInterfaceType == System.Net.NetworkInformation.NetworkInterfaceType.Wireless80211);

            foreach (var networkInterface in networkInterfaces)
            {
                result = networkInterface.GetPhysicalAddress().ToString();

                break;
            }

            // TODO Set it with generated GUID !!

            return result;
        }
    }
}