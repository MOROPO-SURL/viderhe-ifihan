using Microsoft.EntityFrameworkCore;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace SmartSolucionesCuba.Viderhe.Cloud.Persistence.EF.Repositories
{
    public class FrameRepository : MOROPO.SAPRESSC.Core.Persistence.EF.Repositories.AbstractEntityRepository<Frame, long>
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
