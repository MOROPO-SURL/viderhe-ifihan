namespace MOROPO.VIDERHE.Cloud.Persistence.Entities
{
    public class AccountExtensionBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Account, System.Guid, Extension, System.Guid>, Framework.Guama.Core.Persistence.Entities.Contract.IPersistenceSignable
    {
        public System.Guid ProwId { get; set; }
        public Account Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Extension Stern { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Signature { get; set; }

        public object GetSignableEntityModel()
        {
            return new { ProwId, SternId };
        }
    }
}
