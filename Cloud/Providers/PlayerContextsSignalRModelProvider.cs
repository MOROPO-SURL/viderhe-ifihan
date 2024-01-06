namespace MOROPO.VIDERHE.Cloud.Providers
{
    public class PlayerContextsSignalRModelProvider
    {
        private static PlayerContextsSignalRModelProvider instance;

        public static PlayerContextsSignalRModelProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlayerContextsSignalRModelProvider();
                }

                return instance;
            }
        }

        public PlayerContextsSignalRModelProvider()
        {
            Contexts = new System.Collections.Generic.List<Models.SignalR.PlayerContextSignalRModel>();
        }

        public System.Collections.Generic.List<Models.SignalR.PlayerContextSignalRModel> Contexts { get; private set; }
    }
}
