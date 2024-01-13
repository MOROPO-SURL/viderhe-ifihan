using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Persistence.ORM.EF.Repositories
{
    public class TextRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Text, System.Guid>
    {
        public TextRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }

        public override System.Func<Text, object> GetPagingOrderSelector()
        {
            return entity => entity.CreateAt;
        }

        public override bool IsPagingOrderDescending()
        {
            return true;
        }
    }
}