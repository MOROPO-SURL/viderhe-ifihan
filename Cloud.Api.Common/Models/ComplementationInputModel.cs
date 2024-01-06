using MOROPO.VIDERHE.Cloud.Persistence.Enumerations;

namespace MOROPO.VIDERHE.Cloud.Api.Common.Models
{
    public class ComplementationInputModel
    {
        public System.Guid PlacardId { get; set; }

        public PlacardComplementationKind? ComplementationKind { get; set; }

        public string SerializedComplementation { get; set; }
    }
}
