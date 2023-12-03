using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Persistence.ORM.EF.Configurators
{
    public class AccountImageBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractBridgeEntityTypeConfigurator<AccountImageBridge, Account, System.Guid, Framework.Guama.Media.Persistence.Entities.Image, System.Guid>
    {
        public AccountImageBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ImageBridges;
        }
    }
}
