using MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.Web.Persistence.ORM.EF.Configurators
{
    public class AVProductionAVGenreBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractBridgeEntityTypeConfigurator<AVProductionAVGenreBridge, AVProduction, System.Guid, AVGenre, int>
    {
        public AVProductionAVGenreBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.GenreBridges;
        }
    }
}
