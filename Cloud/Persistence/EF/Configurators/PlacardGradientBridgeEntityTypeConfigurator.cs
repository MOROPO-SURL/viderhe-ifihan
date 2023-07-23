namespace SmartSolucionesCuba.Viderhe.Cloud.Persistence.EF.Configurators
{
    public class PlacardGradientBridgeEntityTypeConfigurator : MOROPO.SAPRESSC.Core.Persistence.EF.Configurators.AbstractEntityTypeConfigurator<Entities.PlacardGradientBridge>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.PlacardGradientBridge> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasKey(e => new { e.PlacardId, e.GradientId });

            entityTypeBuilder.HasOne(e => e.Placard).WithMany(b => b.GradientBridges).HasForeignKey(e => e.PlacardId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
            entityTypeBuilder.HasOne(e => e.Gradient).WithMany().HasForeignKey(e => e.GradientId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
