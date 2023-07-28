namespace SmartSolucionesCuba.Viderhe.Cloud.Persistence.Entities
{
    public class Tag : MOROPO.SAPRESSC.Core.Persistence.Entities.INamedEntity<System.Guid>
    {
        public Tag()
        {
            Id = System.Guid.NewGuid();
        }

        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public Enumerations.TagGroup Group { get; set; }

        public string Color { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("AccountId")]
        public Account Account { get; set; }
        public System.Guid AccountId { get; set; }
    }
}
