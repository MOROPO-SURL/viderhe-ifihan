namespace MOROPO.VIDERHE.Service.Hotel.OTT.Web.Persistence.ORM.EF.Repositories
{
    public class AVCategoryRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<OTT.Persistence.Entities.AVCategory, int>
    {
        public AVCategoryRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}
