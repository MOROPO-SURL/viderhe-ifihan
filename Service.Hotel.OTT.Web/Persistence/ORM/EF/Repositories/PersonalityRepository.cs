using Microsoft.EntityFrameworkCore;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.Web.Persistence.ORM.EF.Repositories
{
    public class PersonalityRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<OTT.Persistence.Entities.Personality, System.Guid>
    {
        public PersonalityRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<OTT.Persistence.Entities.Personality> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(entity => entity.Identity).ThenInclude(entity => entity.Image);
        }
    }
}
