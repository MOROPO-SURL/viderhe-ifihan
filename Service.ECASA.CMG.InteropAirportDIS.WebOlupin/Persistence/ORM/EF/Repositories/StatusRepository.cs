namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.WebOlupin.Persistence.ORM.EF.Repositories
{
    public class StatusRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<InterFIDS.Persistence.Entities.Status, System.Guid>
    {
        public StatusRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}
