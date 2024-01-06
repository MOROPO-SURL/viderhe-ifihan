namespace MOROPO.VIDERHE.Cloud.Persistence.Entities
{
    public class PlacardTagBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Placard, System.Guid, Tag, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public Placard Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Tag Stern { get; set; }
    }
}
