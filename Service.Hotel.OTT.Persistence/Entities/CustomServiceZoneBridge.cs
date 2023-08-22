using MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities.Contract;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities
{
    public class CustomServiceZoneBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<CustomService, System.Guid, Zone, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public CustomService Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Zone Stern { get; set; }
    }
}
