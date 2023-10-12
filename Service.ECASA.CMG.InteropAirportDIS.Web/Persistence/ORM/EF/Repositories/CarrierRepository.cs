using Microsoft.EntityFrameworkCore;

namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Web.Persistence.ORM.EF.Repositories
{
    public class CarrierRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<InterFIDS.Persistence.Entities.Carrier, string>
    {
        public CarrierRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<InterFIDS.Persistence.Entities.Carrier> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.Country);
        }
    }
}
