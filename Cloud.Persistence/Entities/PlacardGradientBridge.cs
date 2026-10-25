namespace MOROPO.VIDERHE.Cloud.Persistence.Entities
{
    public class PlacardGradientBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Placard, System.Guid, Gradient, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public Placard Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Gradient Stern { get; set; }
    }
}
