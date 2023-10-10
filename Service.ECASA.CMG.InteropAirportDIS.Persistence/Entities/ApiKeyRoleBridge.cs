using MOROPO.Framework.Guama.Core.Security.Common.Persistence.Entities;

namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Entities
{
    public class ApiKeyRoleBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<ApiKey, System.Guid, Role, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public ApiKey Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Role Stern { get; set; }
    }
}
