namespace MOROPO.VIDERHE.Service.Hotel.OTT.Web.Persistence.ORM.EF.Configurators
{
    public class AVProductionCountryBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractBridgeEntityTypeConfigurator<OTT.Persistence.Entities.AVProductionCountryBridge, OTT.Persistence.Entities.AVProduction, System.Guid, Framework.Guama.Location.Persistence.Entities.Country, System.Guid>
    {
        public AVProductionCountryBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.CountryBridges;
        }
    }
}
