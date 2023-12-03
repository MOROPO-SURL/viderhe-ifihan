using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Persistence.ORM.EF.Configurators
{
    public class AccountModeratorBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractBridgeEntityTypeConfigurator<AccountModeratorBridge, Account, System.Guid, Moderator, System.Guid>
    {
        public AccountModeratorBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ModeratorBridges;
            sternNavigationExpression = entity => entity.AccountBridges;
        }
    }
}
