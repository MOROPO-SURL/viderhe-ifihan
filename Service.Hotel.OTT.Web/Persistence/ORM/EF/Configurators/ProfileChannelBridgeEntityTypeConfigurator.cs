using MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.Web.Persistence.ORM.EF.Configurators
{
    public class ProfileChannelBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractBridgeEntityTypeConfigurator<ProfileChannelBridge, Profile, System.Guid, Channel, System.Guid>
    {
        public ProfileChannelBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ChannelBridges;
        }
    }
}
