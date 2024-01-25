using Microsoft.EntityFrameworkCore;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace SmartSolucionesCuba.Viderhe.Cloud.Persistence.EF.Repositories
{
    public class ExtensionRespository : MOROPO.SAPRESSC.Core.Persistence.EF.Repositories.AbstractEntityRepository<Extension, System.Guid>
    {
        public ExtensionRespository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Extension> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Templates)
                .Include(entity => entity.Transitions)
                .Include(entity => entity.Overlays);
        }
    }
}
