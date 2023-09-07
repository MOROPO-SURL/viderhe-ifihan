namespace MOROPO.VIDERHE.Service.Hotel.OTT.API.Connect.Clients
{
    public class AVCategoriesAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.AbstractEntityManagementApiConnectClient<Persistence.Entities.AVCategory, int, Common.Models.AVCategoryInputModel, Common.Models.AVCategoryDisplayModel>
    {
        public AVCategoriesAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "backend/avcategories";
    }
}
