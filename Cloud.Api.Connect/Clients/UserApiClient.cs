using SmartSolucionesCuba.Videre.Cloud.Api.Common.Models;

namespace SmartSolucionesCuba.Videre.Cloud.Api.Connect.Clients
{
    public class UserApiClient
    {
        private readonly SAPRESSC.Core.Api.Connect.Helpers.HttpClientHelper httpClientHelper;

        public UserApiClient(SAPRESSC.Core.Api.Connect.Helpers.HttpClientHelper httpClientHelper)
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
