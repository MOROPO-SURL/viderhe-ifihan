using Microsoft.EntityFrameworkCore;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Persistence.ORM.EF.Repositories
{
    public class AccountRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Account, System.Guid>
    {
        public AccountRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Account> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Logo).ThenInclude(e => e.Thumbnail)
                .Include(entity => entity.HorizontalSplash).ThenInclude(e => e.Thumbnail)
                .Include(entity => entity.VerticalSplash).ThenInclude(e => e.Thumbnail)
                .Include(entity => entity.Screenplays)
                .Include(entity => entity.DefaultOverlay)
                .Include(entity => entity.ExtensionBridges).ThenInclude(bridge => bridge.Stern);
        }
    }
}
