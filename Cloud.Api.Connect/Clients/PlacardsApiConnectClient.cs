using MOROPO.VIDERHE.Cloud.Api.Common.Models;
using MOROPO.VIDERHE.Cloud.Api.Common.Models.Filter;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Api.Connect.Clients
{
    public class PlacardsApiConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.AbstractEntityManagementFilteredApiConnectClient<Placard, System.Guid, PlacardInputModel, PlacardDisplayModel, PlacardFilterModel>
    {
        public PlacardsApiConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "account/placards";
    }
}
