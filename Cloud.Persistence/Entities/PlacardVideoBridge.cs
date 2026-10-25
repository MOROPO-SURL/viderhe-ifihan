using MOROPO.Framework.Guama.Media.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Persistence.Entities
{
    public class PlacardVideoBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Placard, System.Guid, Video, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public Placard Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Video Stern { get; set; }
    }
}
