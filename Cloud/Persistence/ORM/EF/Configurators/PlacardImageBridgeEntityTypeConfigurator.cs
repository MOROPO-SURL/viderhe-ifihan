using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Persistence.ORM.EF.Configurators
{
    public class PlacardImageBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractBridgeEntityTypeConfigurator<PlacardImageBridge, Placard, System.Guid, Framework.Guama.Media.Persistence.Entities.Image, System.Guid>
    {
        public PlacardImageBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ImageBridges;
        }

        protected override ReferenceCollectionBuilder<Placard, PlacardImageBridge> ExtendProwDefaultRelationshipConfiguration(ReferenceCollectionBuilder<Placard, PlacardImageBridge> builder)
        {
            return base.ExtendProwDefaultRelationshipConfiguration(builder).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }

        protected override ReferenceCollectionBuilder<Image, PlacardImageBridge> ExtendSternDefaultRelationshipConfiguration(ReferenceCollectionBuilder<Image, PlacardImageBridge> builder)
        {
            return base.ExtendSternDefaultRelationshipConfiguration(builder).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
