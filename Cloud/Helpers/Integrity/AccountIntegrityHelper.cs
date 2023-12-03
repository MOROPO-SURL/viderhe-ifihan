using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Helpers.Integrity
{
    public static class AccountIntegrityHelper
    {
        public static string GetSignature(Account entity)
        {
            return Framework.Guama.Core.Persistence.Helpers.DataIntegrityHelper.GetEntitySignature(entity);
        }

        public static bool IsCorrectlySigned(Account entity)
        {
            return entity.Signature == GetSignature(entity);
        }
    }
}
