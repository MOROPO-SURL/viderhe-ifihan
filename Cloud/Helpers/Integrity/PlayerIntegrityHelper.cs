using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Helpers.Integrity
{
    public class PlayerIntegrityHelper
    {
        public static string GetSignature(Player entity)
        {
            return Framework.Guama.Core.Persistence.Helpers.DataIntegrityHelper.GetEntitySignature(entity);
        }

        public static bool IsCorrectlySigned(Player entity)
        {
            return entity.Signature == GetSignature(entity);
        }
    }
}
