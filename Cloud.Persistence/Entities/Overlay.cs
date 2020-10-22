namespace SmartSolucionesCuba.Videre.Cloud.Persistence.Entities
{
    public class Overlay : SAPRESSC.Core.Persistence.Entities.IHabilitableEntity<System.Guid>
    {
        public Overlay()
        {
            Enabled = true;
        }

        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }
    }
}
