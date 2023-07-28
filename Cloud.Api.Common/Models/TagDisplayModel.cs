namespace SmartSolucionesCuba.Viderhe.Cloud.Api.Common.Models
{
    public class TagDisplayModel : MOROPO.SAPRESSC.Core.Persistence.Models.IEntityDisplayModel<Persistence.Entities.Tag, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Name { get; set; }

        public Persistence.Enumerations.TagGroup Group { get; set; }

        public string Color { get; set; }

        public void Import(Persistence.Entities.Tag entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Group = entity.Group;
            Color = entity.Color;
        }
    }
}
