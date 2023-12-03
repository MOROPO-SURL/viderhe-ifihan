namespace MOROPO.VIDERHE.Cloud.Persistence.Entities
{
    public class AccountGradientBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Account, System.Guid, Gradient, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public Account Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Gradient Stern { get; set; }
    }
}
