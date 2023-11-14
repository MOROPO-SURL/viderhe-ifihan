namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.WebOlupin.Persistence.ORM.EF.Repositories
{
    public class KindRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<InterFIDS.Persistence.Entities.Kind, InterFIDS.Persistence.Enumerations.OperationKind>
    {
        public KindRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}
