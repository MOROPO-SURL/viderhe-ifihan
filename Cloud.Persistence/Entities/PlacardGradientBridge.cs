namespace SmartSolucionesCuba.Viderhe.Cloud.Persistence.Entities
{
    public class PlacardGradientBridge
    {
        public System.Guid PlacardId { get; set; }

        public Placard Placard { get; set; }

        public System.Guid GradientId { get; set; }

        public Gradient Gradient { get; set; }
    }
}
