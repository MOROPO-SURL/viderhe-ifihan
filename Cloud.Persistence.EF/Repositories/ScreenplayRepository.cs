using Microsoft.EntityFrameworkCore;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace SmartSolucionesCuba.Viderhe.Cloud.Persistence.EF.Repositories
{
    public class ScreenplayRepository : MOROPO.SAPRESSC.Core.Persistence.EF.Repositories.AbstractEntityRepository<Screenplay, System.Guid>
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
