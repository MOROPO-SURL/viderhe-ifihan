namespace SmartSolucionesCuba.Videre.Cloud.Persistence.EF.Configurators
{
    public class AccountModeratorBridgeEntityTypeConfigurator : SAPRESSC.Core.Persistence.EF.Configurators.AbstractEntityTypeConfigurator<Entities.AccountModeratorBridge>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.AccountModeratorBridge> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasKey(bridge => new { bridge.AccountId, bridge.ModeratorId });

            entityTypeBuilder.HasOne(bridge => bridge.Account).WithMany(group => group.ModeratorBridges).HasForeignKey(bridge => bridge.AccountId);
            entityTypeBuilder.HasOne(bridge => bridge.Moderator).WithMany().HasForeignKey(bridge => bridge.ModeratorId);
        }
    }
}
