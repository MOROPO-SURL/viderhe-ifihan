namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.SyncWorker.Extensiones
{
    internal static class CheckInDisplayModelExtensions
    {
        internal static bool IsUpdateRequired(this API.Common.Models.CheckInDisplayModel model, Persistence.Entities.CheckIn entity)
        {
            if (model.IsOpen)
            {
                if (entity.Abierto == null || !entity.Abierto.Value) return true;
            }
            else
            {
                if (entity.Abierto != null && entity.Abierto.Value) return true;
            }

            if (model.IsVIP)
            {
                if (entity.Vip == null || !entity.Vip.Value) return true;
            }
            else
            {
                if (entity.Vip != null && entity.Vip.Value) return true;
            }

            if (model.DepartureOperation.Id.ToString() != entity.IdOper) return true;

            if (model.EndAt != entity.FechaFin) return true;

            if (model.StartAt != entity.FechaIni) return true;

            return false;
        }
    }
}
