namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Web.Persistence.ORM.EF.Configurators
{
    public class ApiKeyRoleBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractBridgeEntityTypeConfigurator<InterFIDS.Persistence.Entities.ApiKeyRoleBridge, InterFIDS.Persistence.Entities.ApiKey, System.Guid, Framework.Guama.Core.Security.Common.Persistence.Entities.Role, System.Guid>
    {
        public ApiKeyRoleBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.RoleBridges;
        }
    }
}
