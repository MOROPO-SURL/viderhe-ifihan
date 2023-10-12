using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.Framework.Guama.Location.Persistence.Entities;

namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Web.Persistence.ORM.EF.Configurators
{
    public class MunicipalityLocationEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractEntityTypeConfigurator<MunicipalityLocation>
    {
        protected override void ApplayRules(EntityTypeBuilder<MunicipalityLocation> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasOne(entity => entity.Municipality).WithMany().HasForeignKey(entity => entity.MunicipalityId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
        }
    }
}
