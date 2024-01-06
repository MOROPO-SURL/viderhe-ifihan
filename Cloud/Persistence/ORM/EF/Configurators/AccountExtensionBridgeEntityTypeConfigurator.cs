using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Persistence.ORM.EF.Configurators
{
    public class AccountExtensionBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractBridgeEntityTypeConfigurator<AccountExtensionBridge, Account, System.Guid, Extension, System.Guid>
    {
        public AccountExtensionBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ExtensionBridges;
        }
    }
}
