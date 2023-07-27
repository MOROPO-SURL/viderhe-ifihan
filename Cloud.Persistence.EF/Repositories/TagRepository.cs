using Microsoft.EntityFrameworkCore;

namespace SmartSolucionesCuba.Viderhe.Cloud.Persistence.EF.Repositories
{
    public class TagRepository : MOROPO.SAPRESSC.Core.Persistence.EF.Repositories.AbstractEntityRepository<Entities.Tag, System.Guid>
    {
        public TagRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override System.Func<Entities.Tag, object> GetPagingOrderSelector()
        {
            return entity => entity.Name;
        }

        protected override System.Linq.IQueryable<Entities.Tag> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(entity => entity.Account);
        }
    }
}
