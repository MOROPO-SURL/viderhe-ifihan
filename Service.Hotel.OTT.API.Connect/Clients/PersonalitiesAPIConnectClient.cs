namespace MOROPO.VIDERHE.Service.Hotel.OTT.API.Connect.Clients
{
    public class PersonalitiesAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.AbstractEntityManagementApiConnectClient<Persistence.Entities.Personality, System.Guid, Common.Models.PersonalityInputModel, Common.Models.PersonalityDisplayModel>
    {
        public PersonalitiesAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "backend/personalities";
    }
}
