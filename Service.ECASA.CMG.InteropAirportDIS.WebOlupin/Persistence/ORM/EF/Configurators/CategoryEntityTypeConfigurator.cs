namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.WebOlupin.Persistence.ORM.EF.Configurators
{
    public class CategoryEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractEntityTypeConfigurator<InterFIDS.Persistence.Entities.Category>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InterFIDS.Persistence.Entities.Category> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasIndex(entity => entity.Discriminator).IsUnique();
        }
    }
}
