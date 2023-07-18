namespace SmartSolucionesCuba.Viderhe.Cloud.Persistence.EF.Configurators
{
    public class AccountSoundBridgeEntityTypeConfigurator : MOROPO.SAPRESSC.Core.Persistence.EF.Configurators.AbstractEntityTypeConfigurator<Entities.AccountSoundBridge>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.AccountSoundBridge> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasKey(e => new { e.AccountId, e.SoundId });

            entityTypeBuilder.HasOne(e => e.Account).WithMany(b => b.SoundBridges).HasForeignKey(e => e.AccountId);
            entityTypeBuilder.HasOne(e => e.Sound).WithMany().HasForeignKey(e => e.SoundId);
        }
    }
}
