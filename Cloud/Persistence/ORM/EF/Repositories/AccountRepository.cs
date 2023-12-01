using Microsoft.EntityFrameworkCore;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Persistence.ORM.EF.Repositories
{
    public class AccountRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<Account, System.Guid>
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
                .Include(entity => entity.ExtensionBridges)
                .Include(entity => entity.GradientBridges)
                .Include(entity => entity.TextBridges)
                .Include(entity => entity.ImageBridges).ThenInclude(b => b.Stern).ThenInclude(e => e.Thumbnail)
                .Include(entity => entity.VideoBridges).ThenInclude(b => b.Stern).ThenInclude(e => e.Thumbnail)
                .Include(entity => entity.ModeratorBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(e => e.Identity).ThenInclude(e => e.Image).ThenInclude(e => e.Thumbnail)
                .Include(entity => entity.Players).ThenInclude(entity => entity.Screenplay);
        }
    }
}
