using Microsoft.EntityFrameworkCore;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;
using System.Linq;

namespace MOROPO.VIDERHE.Cloud.Persistence.ORM.EF.Repositories
{
    public class AccountVideoBridgeRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractBridgeRepository<Entities.AccountVideoBridge, Entities.Account, System.Guid, Framework.Guama.Media.Persistence.Entities.Video, System.Guid>
    {
        public AccountVideoBridgeRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<AccountVideoBridge> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(bridge => bridge.Stern).ThenInclude(entity => entity.Thumbnail);
        }
    }
}
