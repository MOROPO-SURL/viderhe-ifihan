using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Persistence.ORM.EF.Configurators
{
    public class AccountTextBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractBridgeEntityTypeConfigurator<AccountTextBridge, Account, System.Guid, Text, System.Guid>
    {
        public AccountTextBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.TextBridges;
            sternNavigationExpression = entity => entity.AccountBridges;
        }
    }
}
