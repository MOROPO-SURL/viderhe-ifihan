namespace MOROPO.VIDERHE.Service.Hotel.OTT.Web.Persistence.ORM.EF.Configurators
{
    public class ApiKeyRoleBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractBridgeEntityTypeConfigurator<OTT.Persistence.Entities.ApiKeyRoleBridge, OTT.Persistence.Entities.ApiKey, System.Guid, Framework.Guama.Core.Security.Common.Persistence.Entities.Role, System.Guid>
    {
        public ApiKeyRoleBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.RoleBridges;
        }
    }
}
