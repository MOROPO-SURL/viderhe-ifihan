using MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities.Contract;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities
{
    public class ZoneScheduleBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Zone, System.Guid, Schedule, int>
    {
        public System.Guid ProwId { get; set; }
        public Zone Prow { get; set; }

        public int SternId { get; set; }
        public Schedule Stern { get; set; }
    }
}