using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Persistence.ORM.EF.Configurators
{
    public class PlacardGradientBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractBridgeEntityTypeConfigurator<PlacardGradientBridge, Placard, System.Guid, Gradient, System.Guid>
    {
        public PlacardGradientBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.GradientBridges;            
        }

        protected override ReferenceCollectionBuilder<Placard, PlacardGradientBridge> ExtendProwDefaultRelationshipConfiguration(ReferenceCollectionBuilder<Placard, PlacardGradientBridge> builder)
        {
            return base.ExtendProwDefaultRelationshipConfiguration(builder).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }

        protected override ReferenceCollectionBuilder<Gradient, PlacardGradientBridge> ExtendSternDefaultRelationshipConfiguration(ReferenceCollectionBuilder<Gradient, PlacardGradientBridge> builder)
        {
            return base.ExtendSternDefaultRelationshipConfiguration(builder).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
