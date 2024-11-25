using Microsoft.EntityFrameworkCore;

namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.WebOlupin.Persistence.ORM.EF.Repositories
{
    public class CheckInRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<InterFIDS.Persistence.Entities.CheckIn, System.Guid>
    {
        public CheckInRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<InterFIDS.Persistence.Entities.CheckIn> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.DepartureOperation).ThenInclude(entity => entity.Status)
                .Include(entity => entity.DepartureOperation).ThenInclude(entity => entity.Carrier).ThenInclude(entity => entity.Country)
                .Include(entity => entity.DepartureOperation).ThenInclude(entity => entity.Carrier).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.DepartureOperation).ThenInclude(entity => entity.Kind)
                .Include(entity => entity.DepartureOperation).ThenInclude(entity => entity.Category)
                .Include(entity => entity.DepartureOperation).ThenInclude(entity => entity.Terminal)
                .Include(entity => entity.ArrivalOperation).ThenInclude(entity => entity.Status)
                .Include(entity => entity.ArrivalOperation).ThenInclude(entity => entity.Carrier).ThenInclude(entity => entity.Country)
                .Include(entity => entity.ArrivalOperation).ThenInclude(entity => entity.Carrier).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.ArrivalOperation).ThenInclude(entity => entity.Kind)
                .Include(entity => entity.ArrivalOperation).ThenInclude(entity => entity.Category)
                .Include(entity => entity.ArrivalOperation).ThenInclude(entity => entity.Terminal);
        }
    }
}
