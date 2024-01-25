using Microsoft.EntityFrameworkCore;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.Web.Persistence.ORM.EF.Repositories
{
    public class CustmoServiceRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<OTT.Persistence.Entities.CustomService, System.Guid>
    {
        public CustmoServiceRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<OTT.Persistence.Entities.CustomService> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(entity => entity.FeatureImage);
        }
    }
}
