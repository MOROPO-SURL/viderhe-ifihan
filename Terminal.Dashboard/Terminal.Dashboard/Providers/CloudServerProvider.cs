namespace SmartSolucionesCuba.Videre.Terminal.Dashboard.Providers
{
    public sealed class CloudServerProvider : Support.Presentation.Providers.Facade.ICloudServerProviderFacade
    {
        private static CloudServerProvider instance;

        public static CloudServerProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CloudServerProvider();
                }

                return instance;
            }
        }

        public string CloudServerHost => Managers.SessionManager.Instance.Server;
    }
}
