using MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.Web.Persistence.ORM.EF.Configurators
{
    public class AVProductionAVProducerHouseBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractBridgeEntityTypeConfigurator<AVProductionAVProducerHouseBridge, AVProduction, System.Guid, AVProducerHouse, System.Guid>
    {
        public AVProductionAVProducerHouseBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ProducerHouseBridges;
        }
    }
}
