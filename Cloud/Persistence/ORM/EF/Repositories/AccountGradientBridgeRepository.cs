using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MOROPO.VIDERHE.Cloud.Persistence.ORM.EF.Repositories
{
    public class AccountGradientBridgeRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractBridgeRepository<Entities.AccountGradientBridge, Entities.Account, System.Guid, Entities.Gradient, System.Guid>
    {
        public AccountGradientBridgeRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<Entities.AccountGradientBridge> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(bridge => bridge.Stern);
        }
    }
}
