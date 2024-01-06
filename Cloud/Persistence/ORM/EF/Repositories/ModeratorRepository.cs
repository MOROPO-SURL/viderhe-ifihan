using Microsoft.EntityFrameworkCore;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Persistence.ORM.EF.Repositories
{
    public class ModeratorRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<Moderator, System.Guid>
    {
        public ModeratorRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Moderator> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(e => e.User)
                .Include(e => e.Identity).ThenInclude(e => e.Image)
                .Include(e => e.AccountBridges);
        }
    }
}
