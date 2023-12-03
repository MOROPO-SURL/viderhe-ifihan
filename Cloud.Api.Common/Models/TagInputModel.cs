using MOROPO.VIDERHE.Cloud.Persistence.Entities;
using MOROPO.VIDERHE.Cloud.Persistence.Enumerations;

namespace MOROPO.VIDERHE.Cloud.Api.Common.Models
{
    public class TagInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Tag, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public TagGroup Group { get; set; }

        public string Color { get; set; }

        public Tag Export()
        {
            var entity = new Tag
            {
                Id = Id
            };

            Mergue(entity);

            return entity;
        }

        public void Import(Tag entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Tag entity)
        {
            entity.Name = Name;
            entity.Color = Color;
            entity.Group = Group;
        }
    }
}
