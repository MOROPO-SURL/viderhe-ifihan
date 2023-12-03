using MOROPO.VIDERHE.Cloud.Persistence.Entities;
using MOROPO.VIDERHE.Cloud.Persistence.Enumerations;

namespace MOROPO.VIDERHE.Cloud.Api.Common.Models
{
    public class TagDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Tag, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Name { get; set; }

        public TagGroup Group { get; set; }

        public string Color { get; set; }

        public void Import(Tag entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Group = entity.Group;
            Color = entity.Color;
        }
    }
}
