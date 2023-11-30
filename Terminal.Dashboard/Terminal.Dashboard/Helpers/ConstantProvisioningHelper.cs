using MOROPO.Framework.Guama.Identity.Persistence.Enumerations;
using MOROPO.VIDERHE.Support.Presentation.Managers;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Helpers
{
    public sealed class ConstantProvisioningHelper
    {
        private static ConstantProvisioningHelper instance;

        public static ConstantProvisioningHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConstantProvisioningHelper();
                }

                return instance;
            }
        }

        private ConstantProvisioningHelper() { }

        internal const string ACTIONSHEET_PICKIMAGE_OPTION_CAMARA = "Captura con la Cámara";
        internal const string ACTIONSHEET_PICKIMAGE_OPTION_GALLERY = "Galería de Imágenes";

        public string FallbackUserProfileImageUrl => string.Format("{0}://{1}/img/default-person-picture.jpg", SessionMemoryManager.Instance.UseSSL ? "https" : "http", SessionMemoryManager.Instance.Host);

        public Sex[] Sex_All => (Sex[])System.Enum.GetValues(typeof(Sex));

        //public SAPRESSC.Middleware.Identity.Persistence.Enumerations.CivilStatus[] CivilStatus_All => (SAPRESSC.Middleware.Identity.Persistence.Enumerations.CivilStatus[])System.Enum.GetValues(typeof(SAPRESSC.Middleware.Identity.Persistence.Enumerations.CivilStatus));
    }
}
