namespace SmartSolucionesCuba.Viderhe.Cloud.Api.Common.Models
{
    public class ComplementationInputModel
    {
        public System.Guid PlacardId { get; set; }

        public Persistence.Enumerations.PlacardComplementationKind? ComplementationKind { get; set; }

        public string SerializedComplementation { get; set; }
    }
}
