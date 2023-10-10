namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Web.Persistence.ORM.EF.Repositories
{
    public class ApiKeyRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<InterFIDS.Persistence.Entities.ApiKey, System.Guid>
    {
        public ApiKeyRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}
