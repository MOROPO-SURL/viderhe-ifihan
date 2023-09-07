using Microsoft.EntityFrameworkCore;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.Web.Persistence.ORM.EF.Repositories
{
    public class AVProducerHouseRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<OTT.Persistence.Entities.AVProducerHouse, System.Guid>
    {
        public AVProducerHouseRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<OTT.Persistence.Entities.AVProducerHouse> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(entity => entity.Identity).ThenInclude(entity => entity.Image);
        }
    }
}
