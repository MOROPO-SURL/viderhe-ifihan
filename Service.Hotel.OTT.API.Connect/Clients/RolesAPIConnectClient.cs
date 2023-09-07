namespace MOROPO.VIDERHE.Service.Hotel.OTT.API.Connect.Clients
{
    public class RolesAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.AbstractEntityManagementApiConnectClient<Framework.Guama.Core.Security.Common.Persistence.Entities.Role, System.Guid, Common.Models.RoleInputModel, Common.Models.RoleDisplayModel>
    {
        public RolesAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "backend/roles";
    }
}
