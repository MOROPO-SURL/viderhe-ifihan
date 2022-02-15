namespace SmartSolucionesCuba.Viderhe.Cloud.Persistence.EF.Repositories
{
    public class TemplateRepository : SAPRESSC.Core.Persistence.EF.Repositories.AbstractEntityRepository<Entities.Template, System.Guid>
    {
        public TemplateRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}
