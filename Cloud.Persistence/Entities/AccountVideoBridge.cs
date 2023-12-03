using MOROPO.Framework.Guama.Media.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Persistence.Entities
{
    public class AccountVideoBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Account, System.Guid, Video, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public Account Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Video Stern { get; set; }
    }
}
