using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Persistence.ORM.EF.Configurators
{
    public class PlacardTagBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractBridgeEntityTypeConfigurator<PlacardTagBridge, Placard, System.Guid, Tag, System.Guid>
    {
        public PlacardTagBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.TagBridges;
        }

        protected override ReferenceCollectionBuilder<Placard, PlacardTagBridge> ExtendProwDefaultRelationshipConfiguration(ReferenceCollectionBuilder<Placard, PlacardTagBridge> builder)
        {
            return base.ExtendProwDefaultRelationshipConfiguration(builder).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }

        protected override ReferenceCollectionBuilder<Tag, PlacardTagBridge> ExtendSternDefaultRelationshipConfiguration(ReferenceCollectionBuilder<Tag, PlacardTagBridge> builder)
        {
            return base.ExtendSternDefaultRelationshipConfiguration(builder).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }
    }
}
