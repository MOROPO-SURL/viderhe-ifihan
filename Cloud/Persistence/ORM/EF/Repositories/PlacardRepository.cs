using Microsoft.EntityFrameworkCore;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Persistence.ORM.EF.Repositories
{
    public class PlacardRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<Placard, System.Guid>
    {
        public PlacardRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Placard> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(e => e.Account)
                .Include(e => e.Template)
                .Include(e => e.ImageBridges)
                .Include(e => e.VideoBridges)
                .Include(e => e.GradientBridges)
                .Include(e => e.SoundBridges)
                .Include(e => e.TagBridges).ThenInclude(b => b.Stern);
        }

        public override System.Func<Placard, object> GetPagingOrderSelector()
        {
            return e => e.CreateAt;
        }

        public override bool IsPagingOrderDescending()
        {
            return true;
        }
    }
}
