[assembly: Xamarin.Forms.Dependency(typeof(SmartSolucionesCuba.Videre.Terminal.Player.UWP.Providers.HostEnvironmentInfoProvider))]

namespace SmartSolucionesCuba.Videre.Terminal.Player.UWP.Providers
{
    public class HostEnvironmentInfoProvider : Player.Providers.Facade.IHostEnvironmentInfoProviderFacade
    {
        public string GetHardwareIdentifier()
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
