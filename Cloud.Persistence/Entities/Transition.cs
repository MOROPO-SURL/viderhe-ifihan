namespace SmartSolucionesCuba.Videre.Cloud.Persistence.Entities
{
    public class Transition : SAPRESSC.Core.Persistence.Entities.IHabilitableEntity<System.Guid>
    {
        public Transition()
        {
            Enabled = true;
        }

        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }
    }
}
