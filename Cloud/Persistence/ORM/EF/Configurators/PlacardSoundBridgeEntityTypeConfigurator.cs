using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Persistence.ORM.EF.Configurators
{
    public class PlacardSoundBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractBridgeEntityTypeConfigurator<PlacardSoundBridge, Placard, System.Guid, Sound, System.Guid>
    {
        public PlacardSoundBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.SoundBridges;
        }

        protected override ReferenceCollectionBuilder<Placard, PlacardSoundBridge> ExtendProwDefaultRelationshipConfiguration(ReferenceCollectionBuilder<Placard, PlacardSoundBridge> builder)
        {
            return base.ExtendProwDefaultRelationshipConfiguration(builder).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }

        protected override ReferenceCollectionBuilder<Sound, PlacardSoundBridge> ExtendSternDefaultRelationshipConfiguration(ReferenceCollectionBuilder<Sound, PlacardSoundBridge> builder)
        {
            return base.ExtendSternDefaultRelationshipConfiguration(builder).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
