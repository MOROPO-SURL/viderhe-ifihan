namespace MOROPO.VIDERHE.Service.Hotel.OTT.Web.Persistence.ORM.EF.Configurators
{
    public class CustomServiceLanguageBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractEntityTypeConfigurator<OTT.Persistence.Entities.CustomServiceLanguageBridge>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<OTT.Persistence.Entities.CustomServiceLanguageBridge> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasKey(bridge => new { bridge.ServiceId, bridge.Language });

            entityTypeBuilder.HasOne(bridge => bridge.Service).WithMany(entity => entity.LanguageBridges).HasForeignKey(bridge => bridge.ServiceId);
        }
    }
}
