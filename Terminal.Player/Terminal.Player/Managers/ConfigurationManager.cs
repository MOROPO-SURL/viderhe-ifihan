using SmartSolucionesCuba.Viderhe.Terminal.Player.Extensions;

namespace SmartSolucionesCuba.Viderhe.Terminal.Player.Managers
{
    public class ConfigurationManager
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
                    var hostEnvironmentInfoProvider = Xamarin.Forms.DependencyService.Get<Providers.Facade.IHostEnvironmentInfoProviderFacade>();

                    var hwId = hostEnvironmentInfoProvider.GetHardwareIdentifier();

                    var hashResult = (long)Security.Cryptography.Algorithms.Fnv1a.Hash32(System.Text.Encoding.UTF8.GetBytes(hwId));

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
    }
}

