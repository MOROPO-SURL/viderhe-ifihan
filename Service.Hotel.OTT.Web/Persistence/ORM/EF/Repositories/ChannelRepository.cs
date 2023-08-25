using Microsoft.EntityFrameworkCore;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.Web.Persistence.ORM.EF.Repositories
{
    public class ChannelRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<OTT.Persistence.Entities.Channel, System.Guid>
    {
        public ChannelRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<OTT.Persistence.Entities.Channel> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(entity => entity.FeatureImage);
        }
    }
}
