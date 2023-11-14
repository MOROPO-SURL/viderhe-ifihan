using Microsoft.EntityFrameworkCore;

namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.WebOlupin.Persistence.ORM.EF.Repositories
{
    public class OperationRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<InterFIDS.Persistence.Entities.Operation, long>
    {
        public OperationRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<InterFIDS.Persistence.Entities.Operation> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Status)
                .Include(entity => entity.Carrier).ThenInclude(entity => entity.Country)
                .Include(entity => entity.Carrier).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.Kind)
                .Include(entity => entity.Category)
                .Include(entity => entity.Terminal);
        }
    }
}
