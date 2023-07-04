namespace SmartSolucionesCuba.Viderhe.Cloud.Persistence.EF.Configurators
{
    public class AccountGradientBridgeEntityTypeConfigurator : MOROPO.SAPRESSC.Core.Persistence.EF.Configurators.AbstractEntityTypeConfigurator<Entities.AccountGradientBridge>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.AccountGradientBridge> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasKey(b => new { b.AccountId, b.GradientId });

            entityTypeBuilder.HasOne(b => b.Account).WithMany(e => e.GradientBridges).HasForeignKey(e => e.AccountId);
            entityTypeBuilder.HasOne(b => b.Gradient).WithMany(e => e.AccountBridges).HasForeignKey(e => e.GradientId);
        }
    }
}
