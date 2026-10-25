using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Persistence.ORM.EF.Configurators
{
    public class AccountVideoBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractBridgeEntityTypeConfigurator<AccountVideoBridge, Account, System.Guid, Framework.Guama.Media.Persistence.Entities.Video, System.Guid>
    {
        public AccountVideoBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.VideoBridges;
        }
    }
}
