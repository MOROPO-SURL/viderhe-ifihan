namespace SmartSolucionesCuba.Viderhe.Cloud.Persistence.Entities
{
    public class PlacardSoundBridge
    {
        public System.Guid PlacardId { get; set; }

        public Placard Placard { get; set; }

        public System.Guid SoundId { get; set; }

        public Sound Sound { get; set; }
    }
}
