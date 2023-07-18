namespace SmartSolucionesCuba.Viderhe.Cloud.Persistence.Entities
{
    public class AccountSoundBridge
    {
        public System.Guid AccountId { get; set; }

        public Account Account { get; set; }

        public System.Guid SoundId { get; set; }

        public Sound Sound { get; set; }
    }
}
