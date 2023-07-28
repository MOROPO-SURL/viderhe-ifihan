namespace SmartSolucionesCuba.Viderhe.Cloud.Persistence.Entities
{
    public class PlayerTagBridge
    {
        public string PlayerId { get; set; }

        public Player Player { get; set; }

        public System.Guid TagId { get; set; }

        public Tag Tag { get; set; }
    }
}
