using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace SmartSolucionesCuba.Viderhe.Cloud.Persistence.EF.Repositories
{
    public class GradientRepository : MOROPO.SAPRESSC.Core.Persistence.EF.Repositories.AbstractEntityRepository<Gradient, System.Guid>
    {
        public GradientRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }

        public override System.Func<Gradient, object> GetPagingOrderSelector()
        {
            return entity => entity.CreateAt;
        }

        public override bool IsPagingOrderDescending()
        {
            return true;    
        }
    }
}
