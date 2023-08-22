namespace MOROPO.VIDERHE.Service.Hotel.OTT.Web.Persistence.ORM.EF.Configurators
{
    public class ApiKeyPermissionBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractBridgeEntityTypeConfigurator<OTT.Persistence.Entities.ApiKeyPermissionBridge, OTT.Persistence.Entities.ApiKey, System.Guid, Framework.Guama.Core.Security.Common.Persistence.Entities.Permission, int>
    {
        public ApiKeyPermissionBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.PermissionBridges;
        }
    }
}
