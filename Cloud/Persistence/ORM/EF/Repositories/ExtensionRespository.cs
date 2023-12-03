using Microsoft.EntityFrameworkCore;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Persistence.ORM.EF.Repositories
{
    public class ExtensionRespository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<Extension, System.Guid>
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
