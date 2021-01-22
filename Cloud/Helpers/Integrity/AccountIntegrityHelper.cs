namespace SmartSolucionesCuba.Viderhe.Cloud.Helpers.Integrity
{
    public static class AccountIntegrityHelper
    {
        public static string GetSignature(Persistence.Entities.Account entity)
        {
            return SAPRESSC.Core.Persistence.Helpers.DataIntegrityHelper.GetEntitySignature(entity);
        }

        public static bool IsCorrectlySigned(Persistence.Entities.Account entity)
        {
            return entity.Signature == GetSignature(entity);
        }
    }
}
