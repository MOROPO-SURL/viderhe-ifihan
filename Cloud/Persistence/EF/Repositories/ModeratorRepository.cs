namespace SmartSolucionesCuba.Videre.Cloud.Persistence.EF.Repositories
{
    public class ModeratorRepository : SAPRESSC.Core.Persistence.EF.Repositories.AbstractEntityRepository<Entities.Moderator, System.Guid>
    {
        public ModeratorRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}
