namespace SmartSolucionesCuba.Viderhe.Cloud.Persistence.EF.Configurators
{
    public class TagEntityTypeConfigurator : MOROPO.SAPRESSC.Core.Persistence.EF.Configurators.AbstractEntityTypeConfigurator<Entities.Tag>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.Tag> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasIndex(e => new { e.Group, e.Name, e.AccountId }).IsUnique();
        }
    }
}
