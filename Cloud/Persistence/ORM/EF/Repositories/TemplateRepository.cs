using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Persistence.ORM.EF.Repositories
{
    public class TemplateRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<Template, System.Guid>
    {
        public TemplateRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}
