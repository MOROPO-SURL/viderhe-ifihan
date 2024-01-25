namespace MOROPO.VIDERHE.Service.Hotel.OTT.Web.Persistence.ORM.EF.Repositories
{
    public class AVGenreRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<OTT.Persistence.Entities.AVGenre, int>
    {
        public AVGenreRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}
