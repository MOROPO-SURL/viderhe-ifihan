using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MOROPO.VIDERHE.Cloud.Persistence.ORM.EF.Repositories
{
    public class AccountTextBridgeRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractBridgeRepository<Entities.AccountTextBridge, Entities.Account, System.Guid, Entities.Text, System.Guid>
    {
        public AccountTextBridgeRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<Entities.AccountTextBridge> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(bridge => bridge.Stern);
        }
    }
}
