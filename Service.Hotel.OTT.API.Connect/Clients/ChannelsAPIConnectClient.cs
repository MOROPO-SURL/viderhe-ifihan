namespace MOROPO.VIDERHE.Service.Hotel.OTT.API.Connect.Clients
{
    public class ChannelsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.AbstractEntityManagementApiConnectClient<Persistence.Entities.Channel, System.Guid, Common.Models.ChannelInputModel, Common.Models.ChannelDisplayModel>
    {
        public ChannelsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "backend/channels";
    }
}
