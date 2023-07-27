namespace SmartSolucionesCuba.Viderhe.Cloud.Api.Common.Models
{
    public class TagInputModel : MOROPO.SAPRESSC.Core.Persistence.Models.IEntityInputModel<Persistence.Entities.Tag, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public Persistence.Enumerations.TagGroup Group { get; set; }

        public string Color { get; set; }

        public Persistence.Entities.Tag Export()
        {
            var entity = new Persistence.Entities.Tag
            {
                Id = Id
            };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Tag entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Tag entity)
        {
            entity.Name = Name;
            entity.Color = Color;
            entity.Group = Group;
        }
    }
}
