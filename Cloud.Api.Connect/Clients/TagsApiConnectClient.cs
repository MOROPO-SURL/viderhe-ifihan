namespace SmartSolucionesCuba.Viderhe.Cloud.Api.Connect.Clients
{
    public class TagsApiConnectClient : MOROPO.SAPRESSC.Core.Api.Connect.Clients.AbstractEntityManagementFilteredApiConnectClient<Persistence.Entities.Tag, System.Guid, Common.Models.TagInputModel, Common.Models.TagDisplayModel, Common.Models.Filter.TagFilterModel>
    {
        public TagsApiConnectClient(MOROPO.SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "account/tags";
    }
}
