using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Api.Common.Models.Filter
{
    public class PlayerFilterModel : Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Player, string>
    {
        public string Name { get; set; }

        public TagDisplayModel[] Tags { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Player, bool>> GetSelector()
        {
            return entity => true;
        }
    }
}
