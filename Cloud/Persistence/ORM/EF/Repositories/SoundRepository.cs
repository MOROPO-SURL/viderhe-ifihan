using Microsoft.EntityFrameworkCore;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Persistence.ORM.EF.Repositories
{
    public class SoundRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<Sound, System.Guid>
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
