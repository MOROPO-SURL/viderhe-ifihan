using MOROPO.VIDERHE.Cloud.Api.Common.Models;
using MOROPO.VIDERHE.Cloud.Api.Common.Models.Filter;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Api.Connect.Clients
{
    public class TagsApiConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.AbstractEntityManagementFilteredApiConnectClient<Tag, System.Guid, TagInputModel, TagDisplayModel, TagFilterModel>
    {
        public TagsApiConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "account/tags";
    }
}
