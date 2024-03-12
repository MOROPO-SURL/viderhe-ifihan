using Microsoft.EntityFrameworkCore;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace SmartSolucionesCuba.Viderhe.Cloud.Persistence.EF.Repositories
{
    public class TagRepository : MOROPO.SAPRESSC.Core.Persistence.EF.Repositories.AbstractEntityRepository<Tag, System.Guid>
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
