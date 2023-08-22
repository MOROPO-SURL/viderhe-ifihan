using MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities.Contract;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.Web.Persistence.ORM.EF.Configurators
{
    public class ZoneImageBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractBridgeEntityTypeConfigurator<OTT.Persistence.Entities.ZoneImageBridge, Zone, System.Guid, Framework.Guama.Media.Persistence.Entities.Image, System.Guid>
    {
        public ZoneImageBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ImageBridges;
        }
    }
}
