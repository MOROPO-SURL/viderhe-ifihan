namespace SmartSolucionesCuba.Viderhe.Cloud.Persistence.EF.Repositories
{
    public class TextRepository : MOROPO.SAPRESSC.Core.Persistence.EF.Repositories.AbstractEntityRepository<Entities.Text, System.Guid>
    {
        public TextRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}