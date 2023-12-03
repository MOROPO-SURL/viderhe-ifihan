namespace MOROPO.VIDERHE.Cloud.Persistence.Entities
{
    public class AccountModeratorBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Account, System.Guid, Moderator, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public Account Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Moderator Stern { get; set; }
    }
}
