namespace MOROPO.VIDERHE.Service.Hotel.OTT.API.Connect.Clients
{
    public class AVGenresAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.AbstractEntityManagementApiConnectClient<Persistence.Entities.AVGenre, int, Common.Models.AVGenreInputModel, Common.Models.AVGenreDisplayModel>
    {
        public AVGenresAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "backend/avgenres";
    }
}
