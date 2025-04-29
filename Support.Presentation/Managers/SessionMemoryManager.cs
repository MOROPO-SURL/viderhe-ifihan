using MOROPO.VIDERHE.Support.Presentation.Providers.Facade;

namespace MOROPO.VIDERHE.Support.Presentation.Managers
{
    public class SessionMemoryManager : ICloudServerProviderFacade
    {
        private const string LAST_CLOUD_SERVER_KEY = "last-cloud-server";
        private const string LAST_CLOUD_SECURITY_KEY = "last-cloud-security";

        private static SessionMemoryManager instance;

        public static SessionMemoryManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SessionMemoryManager();
                }

                return instance;
            }
        }

        private SessionMemoryManager()
        {
            if (Xamarin.Forms.Application.Current.Properties.ContainsKey(LAST_CLOUD_SERVER_KEY))
            {
                Server = Xamarin.Forms.Application.Current.Properties[LAST_CLOUD_SERVER_KEY] as string;
            }
            else if (Xamarin.Essentials.Preferences.ContainsKey(LAST_CLOUD_SECURITY_KEY))
            {
                Server = Xamarin.Essentials.Preferences.Get(LAST_CLOUD_SECURITY_KEY, null);
            }
            else
            {
                Server = "viderhe.moropo.cu";
            }

            if (Xamarin.Forms.Application.Current.Properties.ContainsKey(LAST_CLOUD_SECURITY_KEY))
            {
                UseSSL = (bool)Xamarin.Forms.Application.Current.Properties[LAST_CLOUD_SECURITY_KEY];
            }
            else if (Xamarin.Essentials.Preferences.ContainsKey(LAST_CLOUD_SECURITY_KEY))
            {
                UseSSL = Xamarin.Essentials.Preferences.Get(LAST_CLOUD_SECURITY_KEY, false);
            }
            else
            {
                UseSSL = true;
            }
        }

        public string Server { get; set; }

        public void Persist()
        {
            Xamarin.Forms.Application.Current.Properties[LAST_CLOUD_SERVER_KEY] = Server;
            Xamarin.Forms.Application.Current.Properties[LAST_CLOUD_SECURITY_KEY] = UseSSL;

            Xamarin.Forms.Application.Current.SavePropertiesAsync();

            Xamarin.Essentials.Preferences.Set(LAST_CLOUD_SERVER_KEY, Server);
            Xamarin.Essentials.Preferences.Set(LAST_CLOUD_SECURITY_KEY, UseSSL);
        }

        #region ICloudServerProviderFacade implementation

        public string Host => Server;

        public bool UseSSL { get; set; }

        #endregion
    }
}
