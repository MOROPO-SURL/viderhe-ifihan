using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MOROPO.VIDERHE.Cloud.Persistence.ORM.EF.Repositories
{
    public class AccountModeratorBridgeRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractBridgeRepository<Entities.AccountModeratorBridge, Entities.Account, System.Guid, Entities.Moderator, System.Guid>
    {
        public AccountModeratorBridgeRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<Entities.AccountModeratorBridge> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(bridge => bridge.Stern).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image);
        }
    }
}
