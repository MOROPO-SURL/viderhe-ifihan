using SmartSolucionesCuba.Videre.Support.Presentation.Dashboard.Extensions;
using Xamarin.Forms;

namespace SmartSolucionesCuba.Videre.Terminal.Dashboard.Managers
{
    public sealed class SessionManager : SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade
    {
        private const string LAST_CLOUD_SERVER_KEY = "last-cloud-server";

        private static SessionManager instance;

        public static SessionManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SessionManager();
                }

                return instance;
            }
        }

        private SessionManager()
        {
            if (Application.Current.Properties.ContainsKey(LAST_CLOUD_SERVER_KEY))
            {
                Server = Application.Current.Properties[LAST_CLOUD_SERVER_KEY] as string;
            }
        }

        private System.Collections.Generic.KeyValuePair<string, string> AuthorizeHeader
        {
            get
            {
                if (!HasAuthenticatedIdentity)
                {
                    return new System.Collections.Generic.KeyValuePair<string, string>();
                }
                else
                {
                    var type = AuthenticationType;
                    var token = AuthorizationToken;

                    return new System.Collections.Generic.KeyValuePair<string, string>(type, token);
                }
            }
        }

        public bool HasAuthenticatedIdentity => ModeratorLogin != null;

        public SAPRESSC.Core.Api.Connect.Helpers.HttpClientHelper HttpClientHelper => new SAPRESSC.Core.Api.Connect.Helpers.HttpClientHelper(string.Format("http://{0}/api/", Server), () => AuthorizeHeader, null);

        public string Server { get; private set; }
        public string AuthenticationType { get; private set; }
        public string AuthorizationToken { get; private set; }
        public string ModeratorLogin { get; private set; }
        public string ModeratorName { get; private set; }
        public ImageSource ModeratorPictureImageSource { get; private set; }
        public System.Guid AccountId { get; private set; }
        public string AccountName { get; private set; }
        public Color AccountPrimaryColor { get; private set; }
        public Color AccountSecoundaryColor { get; private set; }
        public ImageSource AccountLogoImageSource { get; private set; }
        public ImageSource AccountSplashImageSource { get; private set; }
        public System.Guid AccountDefaultOverlayId { get; private set; }
        public string AccountSerializedOverlayContext { get; private set; }
        public Cloud.Api.Common.Models.ExtensionDisplayModel[] AccountPlugins { get; private set; }

        public void SyncronizeRequiredAccountInformation(string name, Color primaryColor, Color secoundaryColor, System.Guid logoImageId, System.Guid splashImageId)
        {
            AccountName = name;
            AccountPrimaryColor = primaryColor;
            AccountSecoundaryColor = secoundaryColor;
            AccountLogoImageSource = ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(Providers.CloudServerProvider.Instance, logoImageId));
            AccountSplashImageSource = ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(Providers.CloudServerProvider.Instance, splashImageId));
        }

        public async System.Threading.Tasks.Task UpdateAccountInformationAsync(string name, Color primaryColor, Color secoundaryColor, Plugin.FilePicker.Abstractions.FileData logoFileData, Plugin.FilePicker.Abstractions.FileData splashFileData)
        {
            var client = new Cloud.Api.Connect.Clients.AccountApiClient(this);

            var input = new Cloud.Api.Common.Models.AccountInputModel
            {
                Id = AccountId,
                Name = name,
                PrimaryColor = primaryColor.ToSolidHex(),
                SecoundaryColor = secoundaryColor.ToSolidHex()
            };

            if (logoFileData != null)
            {
                var imageFormat = System.IO.Path.GetExtension(logoFileData.FilePath).Substring(1);

                input.LogoImageContentType = string.Format("images/{0}", imageFormat == "jpg" ? "jpeg" : imageFormat);

                using (var imageFileStream = logoFileData.GetStream())
                {
                    imageFileStream.Position = 0;

                    input.LogoImageData = new byte[imageFileStream.Length];

                    imageFileStream.Read(input.LogoImageData, 0, input.LogoImageData.Length);
                }
            }

            if (splashFileData != null)
            {
                var imageFormat = System.IO.Path.GetExtension(splashFileData.FilePath).Substring(1);

                input.SplashImageContentType = string.Format("images/{0}", imageFormat == "jpg" ? "jpeg" : imageFormat);

                using (var imageFileStream = splashFileData.GetStream())
                {
                    imageFileStream.Position = 0;

                    input.SplashImageData = new byte[imageFileStream.Length];

                    imageFileStream.Read(input.SplashImageData, 0, input.SplashImageData.Length);
                }
            }

            await client.EditAsync(input);

            var model = await client.GetCurrentAsync();

            SyncronizeRequiredAccountInformation(model.Name, Color.FromHex(model.PrimaryColor), Color.FromHex(model.SecoundaryColor), model.LogoImageId, model.SplashImageId);
        }

        public async System.Threading.Tasks.Task SignInAsync(string server, string login, string password)
        {
            Server = server;

            var userApiClient = new Cloud.Api.Connect.Clients.UserApiClient(HttpClientHelper);

            var result = await userApiClient.AuthenticateAsync(new Cloud.Api.Common.Models.AuthenticationIntentModel
            {
                User = login,
                Password = password
            });

            Application.Current.Properties[LAST_CLOUD_SERVER_KEY] = server;

            await Application.Current.SavePropertiesAsync();

            AuthenticationType = result.Type;
            AuthorizationToken = result.Token;
            ModeratorLogin = login;
            ModeratorName = result.Identity.LastName == null ? result.Identity.Name : string.Format("{0} {1}", result.Identity.Name, result.Identity.LastName);
            ModeratorPictureImageSource = ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(Providers.CloudServerProvider.Instance, result.Identity.Image.Id));

            try
            {
                var accountApiClient = new Cloud.Api.Connect.Clients.AccountApiClient(this);

                var model = await accountApiClient.GetCurrentAsync();

                AccountId = model.Id;

                SyncronizeRequiredAccountInformation(model.Name, Color.FromHex(model.PrimaryColor), Color.FromHex(model.SecoundaryColor), model.LogoImageId, model.SplashImageId);

                AccountDefaultOverlayId = model.DefaultOverlayId;
                AccountSerializedOverlayContext = model.SerializedOverlayContext;
                AccountPlugins = model.Extensions.ToArray();
            }
            catch (System.Exception e)
            {
                SignOut();

                throw e;
            }
        }

        public void SignOut()
        {
            AuthenticationType = null;
            AuthorizationToken = null;
            ModeratorLogin = null;
            ModeratorName = null;
            ModeratorPictureImageSource = null;

            AccountId = System.Guid.Empty;
            AccountName = null;
            AccountPrimaryColor = Color.Default;
            AccountSecoundaryColor = Color.Default;
            AccountLogoImageSource = null;
            AccountSplashImageSource = null;
            AccountDefaultOverlayId = System.Guid.Empty;
            AccountSerializedOverlayContext = null;
            AccountPlugins = null;
        }

        public async System.Threading.Tasks.Task ChangePasswordAsync(string oldPassword, string newPassword)
        {
            var client = new Cloud.Api.Connect.Clients.UserApiClient(HttpClientHelper);

            await client.ChangePasswordAsync(new Cloud.Api.Common.Models.UserPasswordChangeRequestModel
            {
                OldPassword = oldPassword,
                NewPassword = newPassword
            });
        }
    }
}
