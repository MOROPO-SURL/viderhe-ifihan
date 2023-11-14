namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.WebOlupin.Persistence.ORM.EF.Configurators
{
    public class KindEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractEntityTypeConfigurator<InterFIDS.Persistence.Entities.Kind>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InterFIDS.Persistence.Entities.Kind> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasIndex(entity => entity.Discriminator).IsUnique();
        }
    }
}
