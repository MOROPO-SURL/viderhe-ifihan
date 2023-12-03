namespace MOROPO.VIDERHE.Cloud.Persistence.Entities
{
    public class PlacardSoundBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Placard, System.Guid, Sound, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public Placard Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Sound Stern { get; set; }
    }
}
