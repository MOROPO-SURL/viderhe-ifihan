using MOROPO.VIDERHE.Cloud.Persistence.Entities;
using MOROPO.VIDERHE.Cloud.Persistence.Enumerations;

namespace MOROPO.VIDERHE.Cloud.Api.Common.Models.Filter
{
    public class TagFilterModel : Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Tag, System.Guid>
    {
        public TagGroup Group { get; set; }

        public string Name { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Tag, bool>> GetSelector()
        {
            if (string.IsNullOrEmpty(Name))
            {
                return entity => entity.Group == Group;
            }

            return entity => entity.Group == Group && entity.Name.Contains(Name);
        }
    }
}
