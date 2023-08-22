using MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities.Contract;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities
{
    public class ZoneImageBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Zone, System.Guid, Framework.Guama.Media.Persistence.Entities.Image, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public Zone Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Framework.Guama.Media.Persistence.Entities.Image Stern { get; set; }
    }
}
