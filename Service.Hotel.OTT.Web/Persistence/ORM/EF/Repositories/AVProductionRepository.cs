using Microsoft.EntityFrameworkCore;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.Web.Persistence.ORM.EF.Repositories
{
    public class AVProductionRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<OTT.Persistence.Entities.AVProduction, System.Guid>
    {
        public AVProductionRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<OTT.Persistence.Entities.AVProduction> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Country)
                .Include(entity => entity.CountryBridges).ThenInclude(bridge => bridge.Stern)
                .Include(entity => entity.Category)
                .Include(entity => entity.GenreBridges).ThenInclude(bridge => bridge.Stern)
                .Include(entity => entity.PosterImage)
                .Include(entity => entity.PlacardImage)
                .Include(entity => entity.TrailerVideo)
                .Include(entity => entity.Video)
                .Include(entity => entity.ProducerHouseBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image);
        }
    }
}
