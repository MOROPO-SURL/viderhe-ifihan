using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Persistence.ORM.EF.Configurators
{
    public class PlayerTagBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractBridgeEntityTypeConfigurator<PlayerTagBridge, Player, string, Tag, System.Guid>
    {
        public PlayerTagBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.TagBridges;
        }

        protected override ReferenceCollectionBuilder<Player, PlayerTagBridge> ExtendProwDefaultRelationshipConfiguration(ReferenceCollectionBuilder<Player, PlayerTagBridge> builder)
        {
            return base.ExtendProwDefaultRelationshipConfiguration(builder).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }

        protected override ReferenceCollectionBuilder<Tag, PlayerTagBridge> ExtendSternDefaultRelationshipConfiguration(ReferenceCollectionBuilder<Tag, PlayerTagBridge> builder)
        {
            return base.ExtendSternDefaultRelationshipConfiguration(builder).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }
    }
}
