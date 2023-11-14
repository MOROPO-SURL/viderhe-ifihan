namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.WebOlupin.Persistence.ORM.EF.Configurators
{
    public class TerminalEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractEntityTypeConfigurator<InterFIDS.Persistence.Entities.Terminal>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InterFIDS.Persistence.Entities.Terminal> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasIndex(entity => entity.Discriminator).IsUnique();
        }
    }
}
