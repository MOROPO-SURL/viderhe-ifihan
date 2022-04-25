using System.Linq;

[assembly: Xamarin.Forms.Dependency(typeof(SmartSolucionesCuba.Viderhe.Terminal.Player.UWP.Providers.HostEnvironmentInfoProvider))]

namespace SmartSolucionesCuba.Viderhe.Terminal.Player.UWP.Providers
{
    public class HostEnvironmentInfoProvider : Player.Providers.Facade.IHostEnvironmentInfoProviderFacade
    {
        public string GetHardwareIdentifier()
        {
            try
            {
                var netInterfaces = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();

                var ethNetInterfaces = netInterfaces.Where(item => item.NetworkInterfaceType == System.Net.NetworkInformation.NetworkInterfaceType.Ethernet).ToArray();

                if (ethNetInterfaces.Length > 0) return ethNetInterfaces[0].GetPhysicalAddress().ToString().Replace("-", string.Empty);

                var wlanNetInterfaces = netInterfaces.Where(item => item.NetworkInterfaceType == System.Net.NetworkInformation.NetworkInterfaceType.Wireless80211).ToArray();

                if (wlanNetInterfaces.Length > 0) return wlanNetInterfaces[0].GetPhysicalAddress().ToString().Replace("-", string.Empty);

                throw new System.InvalidOperationException();
            }
            catch 
            {
                byte[] data = null;

                var packageSpecificToken = Windows.System.Profile.HardwareIdentification.GetPackageSpecificToken(null);

                using (var dataReader = Windows.Storage.Streams.DataReader.FromBuffer(packageSpecificToken.Id))
                {
                    data = new byte[packageSpecificToken.Id.Length];

                    dataReader.ReadBytes(data);
                }

                return System.BitConverter.ToString(data).Replace("-", string.Empty).Substring(0, 16);
            }
        }
    }
}
