using Microsoft.EntityFrameworkCore;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Persistence.ORM.EF.Repositories
{
    public class ScreenplayRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<Screenplay, System.Guid>
    {
        public ScreenplayRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override System.Func<Screenplay, object> GetPagingOrderSelector()
        {
            return entity => entity.Title;
        }

        protected override System.Linq.IQueryable<Screenplay> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Account)
                .Include(entity => entity.Frames).ThenInclude(entity => entity.Placard).ThenInclude(entity => entity.Template);
        }
    }
}
