using Microsoft.EntityFrameworkCore;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace SmartSolucionesCuba.Viderhe.Cloud.Persistence.EF.Repositories
{
    public class SoundRepository : MOROPO.SAPRESSC.Core.Persistence.EF.Repositories.AbstractEntityRepository<Sound, System.Guid>
    {
        public SoundRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override System.Func<Sound, object> GetPagingOrderSelector()
        {
            return entity => entity.CreateAt;
        }

        public override bool IsPagingOrderDescending()
        {
            return true;
        }

        protected override System.Linq.IQueryable<Sound> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(entiy => entiy.Thumbnail);
        }
    }
}
