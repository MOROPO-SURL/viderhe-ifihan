namespace MOROPO.VIDERHE.Cloud.Persistence.Entities
{
    public class AccountSoundBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Account, System.Guid, Sound, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public Account Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Sound Stern { get; set; }
    }
}
