using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Persistence.ORM.EF.Repositories
{
    public class ScheduledRelaunchRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<ScheduledRelaunch, System.Guid>
    {
        public ScheduledRelaunchRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }

        public override System.Func<ScheduledRelaunch, object> GetPagingOrderSelector()
        {
            return entity => entity.Time;
        }
    }
}
