namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.SyncWorker.Extensiones
{
    internal static class OperationDisplayModelExtensions
    {
        internal static bool IsUpdateRequired(this API.Common.Models.OperationDisplayModel model, Persistence.Entities.Departure entity)
        {
            if (model.PlannedAt != entity.DateTimeP) return true;

            if (model.EstimatedAt != entity.DateTimeR) return true;

            if (model.Status.Discriminator != entity.Estado) return true;

            if (model.Carrier.Id != entity.Compania) return true;

            if (model.Category.Discriminator != entity.Categoria) return true;

            if (model.Context != entity.OrigDest) return true;

            if (model.Flight.ToString() != entity.NumeroVuelo.Trim()) return true;

            if (model.Terminal.Discriminator != entity.Terminal) return true;

            return false;
        }

        internal static bool IsUpdateRequired(this API.Common.Models.OperationDisplayModel model, Persistence.Entities.Arrival entity)
        {
            if (model.PlannedAt != entity.DateTimeP) return true;

            if (model.EstimatedAt != entity.DateTimeR) return true;

            if (model.Status.Discriminator != entity.Estado) return true;

            if (model.Carrier.Id != entity.Compania) return true;

            if (model.Category.Discriminator != entity.Categoria) return true;

            if (model.Context != entity.OrigDest) return true;

            if (model.Flight.ToString() != entity.NumeroVuelo.Trim()) return true;

            if (model.Terminal.Discriminator != entity.Terminal) return true;

            return false;
        }
    }
}
