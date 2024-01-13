using Microsoft.EntityFrameworkCore;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;
using System.Linq;

namespace MOROPO.VIDERHE.Cloud.Persistence.ORM.EF.Repositories
{
    public class AccountImageBridgeRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractBridgeRepository<Entities.AccountImageBridge, Entities.Account, System.Guid, Framework.Guama.Media.Persistence.Entities.Image, System.Guid>
    {
        public AccountImageBridgeRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<AccountImageBridge> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(bridge => bridge.Stern).ThenInclude(entity => entity.Thumbnail);
        }
    }
}
