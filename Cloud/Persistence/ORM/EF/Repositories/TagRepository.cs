using Microsoft.EntityFrameworkCore;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Persistence.ORM.EF.Repositories
{
    public class TagRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<Tag, System.Guid>
    {
        public TagRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override System.Func<Tag, object> GetPagingOrderSelector()
        {
            return entity => entity.Name;
        }

        protected override System.Linq.IQueryable<Tag> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(entity => entity.Account);
        }
    }
}
