using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace SmartSolucionesCuba.Viderhe.Cloud.Persistence.EF.Repositories
{
    public class ScheduledRelaunchRepository : MOROPO.SAPRESSC.Core.Persistence.EF.Repositories.AbstractEntityRepository<ScheduledRelaunch, System.Guid>
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
