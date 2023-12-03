using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Persistence.ORM.EF.Repositories
{
    public class TextRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<Text, System.Guid>
    {
        public TextRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}