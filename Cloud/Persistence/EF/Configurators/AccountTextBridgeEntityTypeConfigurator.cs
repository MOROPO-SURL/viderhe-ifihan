namespace SmartSolucionesCuba.Viderhe.Cloud.Persistence.EF.Configurators
{
    public class AccountTextBridgeEntityTypeConfigurator : MOROPO.SAPRESSC.Core.Persistence.EF.Configurators.AbstractEntityTypeConfigurator<Entities.AccountTextBridge>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.AccountTextBridge> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasKey(b => new { b.AccountId, b.TextId });

            entityTypeBuilder.HasOne(b => b.Account).WithMany(e => e.TextBridges).HasForeignKey(b => b.AccountId);
            entityTypeBuilder.HasOne(b => b.Text).WithMany(e => e.AccountBridges).HasForeignKey(e => e.TextId);
        }
    }
}
