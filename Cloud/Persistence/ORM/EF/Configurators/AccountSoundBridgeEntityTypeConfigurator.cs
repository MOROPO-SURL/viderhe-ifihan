using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Persistence.ORM.EF.Configurators
{
    public class AccountSoundBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractBridgeEntityTypeConfigurator<AccountSoundBridge, Account, System.Guid, Sound, System.Guid>
    {
        public AccountSoundBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.SoundBridges;
        }
    }
}
