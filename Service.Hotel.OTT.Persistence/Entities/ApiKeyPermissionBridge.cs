using MOROPO.Framework.Guama.Core.Security.Common.Persistence.Entities;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities
{
    public class ApiKeyPermissionBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<ApiKey, System.Guid, Permission, int>
    {
        public System.Guid ProwId { get; set; }
        public ApiKey Prow { get; set; }
        
        public int SternId { get; set; }
        public Permission Stern { get; set; }
    }
}
