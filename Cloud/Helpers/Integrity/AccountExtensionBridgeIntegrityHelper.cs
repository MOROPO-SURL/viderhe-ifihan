using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Helpers.Integrity
{
    public static class AccountExtensionBridgeIntegrityHelper
    {
        public static string GetSignature(AccountExtensionBridge entity)
        {
            return Framework.Guama.Core.Persistence.Helpers.DataIntegrityHelper.GetEntitySignature(entity);
        }

        public static bool IsCorrectlySigned(AccountExtensionBridge entity)
        {
            return entity.Signature == GetSignature(entity);
        }
    }
}
