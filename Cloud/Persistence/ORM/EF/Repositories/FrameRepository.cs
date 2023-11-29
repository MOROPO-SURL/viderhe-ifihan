using Microsoft.EntityFrameworkCore;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Persistence.ORM.EF.Repositories
{
    public class FrameRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<Frame, long>
    {
        public FrameRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override System.Func<Frame, object> GetPagingOrderSelector()
        {
            return e => e.Priority;
        }

        protected override System.Linq.IQueryable<Frame> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entiy => entiy.Screenplay).ThenInclude(e => e.Frames)
                .Include(entity => entity.Placard).ThenInclude(entity => entity.Template)
                .Include(entity => entity.Placard).ThenInclude(entity => entity.Account);
        }
    }
}
