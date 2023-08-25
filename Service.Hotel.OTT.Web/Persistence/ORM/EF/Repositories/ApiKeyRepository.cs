namespace MOROPO.VIDERHE.Service.Hotel.OTT.Web.Persistence.ORM.EF.Repositories
{
    public class ApiKeyRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<OTT.Persistence.Entities.ApiKey, System.Guid>
    {
        public ApiKeyRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}
