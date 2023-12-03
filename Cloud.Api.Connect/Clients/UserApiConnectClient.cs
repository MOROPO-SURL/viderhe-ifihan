using MOROPO.VIDERHE.Cloud.Api.Common.Models;

namespace MOROPO.VIDERHE.Cloud.Api.Connect.Clients
{
    public class UserApiConnectClient
    {
        private readonly Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper httpClientHelper;

        public UserApiConnectClient(Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper httpClientHelper)
        {
            this.httpClientHelper = httpClientHelper;
        }

        public async System.Threading.Tasks.Task<AuthenticatedSessionModel> AuthenticateAsync(AuthenticationIntentModel modelInput)
        {
            return await httpClientHelper.PostAsync<AuthenticationIntentModel, AuthenticatedSessionModel>("security/authenticate", modelInput);
        }

        public async System.Threading.Tasks.Task ChangePasswordAsync(UserPasswordChangeRequestModel model)
        {
            await httpClientHelper.PostAsync("security/changepassword", model);
        }
    }
}
