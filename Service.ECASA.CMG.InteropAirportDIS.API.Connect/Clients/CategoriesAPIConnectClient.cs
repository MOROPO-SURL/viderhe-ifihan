namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Connect.Clients
{
    public class CategoriesAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.AbstractEntityManagementApiConnectClient<Persistence.Entities.Category, System.Guid, Common.Models.CategoryInputModel, Common.Models.CategoryDisplayModel>
    {
        public CategoriesAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "backend/categories";
    }
}
