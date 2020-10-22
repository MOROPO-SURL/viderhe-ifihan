using Microsoft.EntityFrameworkCore;

namespace SmartSolucionesCuba.Videre.Cloud.Persistence.EF.Repositories
{
    public class ExtensionRespository : SAPRESSC.Core.Persistence.EF.Repositories.AbstractEntityRepository<Entities.Extension, System.Guid>
    {
        public ExtensionRespository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.Extension> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Templates)
                .Include(entity => entity.Transitions)
                .Include(entity => entity.Overlays);
        }
    }
}
