using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Persistence.ORM.EF.Configurators
{
    public class PlayerEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractEntityTypeConfigurator<Player>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Player> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasOne(entity => entity.Screenplay).WithMany().HasForeignKey(entity => entity.ScreenplayId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.SetNull);
            entityTypeBuilder.HasOne(entity => entity.Account).WithMany(entity => entity.Players).HasForeignKey(entity => entity.AccountId);
            entityTypeBuilder.HasOne(entity => entity.Overlay).WithMany().HasForeignKey(entity => entity.OverlayId);
        }
    }
}
