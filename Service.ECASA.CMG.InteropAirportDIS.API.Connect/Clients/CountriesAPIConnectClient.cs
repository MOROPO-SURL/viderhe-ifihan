namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Connect.Clients
{
    public class CountriesAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.AbstractEntityManagementApiConnectClient<Framework.Guama.Location.Persistence.Entities.Country, System.Guid, Common.Models.CountryInputModel, Common.Models.CountryDisplayModel>
    {
        public CountriesAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "backend/countries";
    }
}
