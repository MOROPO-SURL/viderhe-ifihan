using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Persistence.ORM.EF.Configurators
{
    public class AccountGradientBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractBridgeEntityTypeConfigurator<AccountGradientBridge, Account, System.Guid, Gradient, System.Guid>
    {
        public AccountGradientBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.GradientBridges;
            sternNavigationExpression = entity => entity.AccountBridges;
        }
    }
}
