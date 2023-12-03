using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Persistence.ORM.EF.Configurators
{
    public class PlacardVideoBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractBridgeEntityTypeConfigurator<PlacardVideoBridge, Placard, System.Guid, Framework.Guama.Media.Persistence.Entities.Video, System.Guid>
    {
        public PlacardVideoBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.VideoBridges;
        }

        protected override ReferenceCollectionBuilder<Placard, PlacardVideoBridge> ExtendProwDefaultRelationshipConfiguration(ReferenceCollectionBuilder<Placard, PlacardVideoBridge> builder)
        {
            return base.ExtendProwDefaultRelationshipConfiguration(builder).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }

        protected override ReferenceCollectionBuilder<Video, PlacardVideoBridge> ExtendSternDefaultRelationshipConfiguration(ReferenceCollectionBuilder<Video, PlacardVideoBridge> builder)
        {
            return base.ExtendSternDefaultRelationshipConfiguration(builder).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
