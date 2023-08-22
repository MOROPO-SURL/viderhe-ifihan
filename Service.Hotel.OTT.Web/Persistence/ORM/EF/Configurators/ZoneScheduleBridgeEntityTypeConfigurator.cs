using MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities;
using MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities.Contract;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.Web.Persistence.ORM.EF.Configurators
{
    public class ZoneScheduleBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractBridgeEntityTypeConfigurator<ZoneScheduleBridge, Zone, System.Guid, Schedule, int>
    {
        public ZoneScheduleBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ScheduleBridges;
        }
    }
}
