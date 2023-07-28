namespace SmartSolucionesCuba.Viderhe.Cloud.Persistence.Entities
{
    public class PlacardTagBridge
    {
        public System.Guid PlacardId { get; set; }

        public Placard Placard { get; set; }

        public System.Guid TagId { get; set; }

        public Tag Tag { get; set; }
    }
}
