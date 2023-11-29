using Microsoft.EntityFrameworkCore;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Persistence.ORM.EF.Repositories
{
    public class PlayerRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<Player, string>
    {
        public PlayerRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Player> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Account).ThenInclude(entity => entity.Logo)
                .Include(entity => entity.Account).ThenInclude(entity => entity.HorizontalSplash)
                .Include(entity => entity.Account).ThenInclude(entity => entity.ExtensionBridges)
                .Include(entity => entity.Screenplay).ThenInclude(entity => entity.Frames).ThenInclude(entity => entity.Placard).ThenInclude(entity => entity.Template)
                .Include(entity => entity.ScheduledRelaunches)
                .Include(entity => entity.TagBridges).ThenInclude(bridge => bridge.Stern);
        }

        public override System.Func<Player, object> GetPagingOrderSelector()
        {
            return entity => entity.Name;
        }

        public override bool IsPagingOrderDescending()
        {
            return true;
        }
    }
}
