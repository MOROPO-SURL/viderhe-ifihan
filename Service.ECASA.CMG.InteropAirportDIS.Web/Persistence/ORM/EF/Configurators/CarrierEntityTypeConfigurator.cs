namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Web.Persistence.ORM.EF.Configurators
{
    public class CarrierEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractEntityTypeConfigurator<InterFIDS.Persistence.Entities.Carrier>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InterFIDS.Persistence.Entities.Carrier> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasOne(entity => entity.Identity).WithOne().HasForeignKey<InterFIDS.Persistence.Entities.Carrier>(entity => entity.IdentityId).IsRequired();
        }
    }
}
