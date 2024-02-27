namespace MOROPO.VIDERHE.Cloud.Persistence.Entities
{
    public class AccountTextBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Account, System.Guid, Text, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public Account Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Text Stern { get; set; }
    }
}
