using MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities;
using MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities.Contract;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.Web.Persistence.ORM.EF.Configurators
{
    public class CustomServiceZoneBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractBridgeEntityTypeConfigurator<CustomServiceZoneBridge, CustomService, System.Guid, Zone, System.Guid>
    {
        public CustomServiceZoneBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ZoneBridges;
        }
    }
}
