using SmartSolucionesCuba.Viderhe.Terminal.Player.Extensions;

namespace SmartSolucionesCuba.Viderhe.Terminal.Player.Managers
{
    public class ConfigurationManager : Support.Presentation.Providers.Facade.ICloudServerProviderFacade
    {
        private static ConfigurationManager instance;

        public static ConfigurationManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConfigurationManager();
                }

                return instance;
            }
        }

        private string playerId;
        private string protectedPlayerId;

        public string PlayerId
        {
            get
            {
                if (playerId == null)
                {
                    var hashResult = (long)Security.Cryptography.Algorithms.Fnv1a.Hash32(System.Text.Encoding.UTF8.GetBytes(Xamarin.Forms.DependencyService.Get<Providers.Facade.IHostEnvironmentInfoProviderFacade>().GetHardwareIdentifier()));

                    playerId = hashResult.ToBase36String().ToUpper();

                    if (playerId.Length > 7) throw new System.InvalidOperationException();

                    while (playerId.Length < 7)
                    {
                        playerId = string.Format("0{0}", playerId);
                    }
                }

                return playerId;
            }
        }

        public string ProtectedPlayerId
        {
            get
            {
                if (protectedPlayerId == null)
                {
                    protectedPlayerId = ProtectedData(PlayerId);
                }

                return protectedPlayerId;
            }
        }

        private string ProtectedData(string data)
        {
            // TODO Implement spected behavior!!
            return data;
        }

        // TODO Restore to spected behavior!!
        //public string CloudServerHost => "cloud.viderhe.net";
        public string CloudServerHost => "192.168.200.200";
        //public string CloudServerHost => "192.168.200.201";
        //public string CloudServerHost => "localhost";
    }
}
