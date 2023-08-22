namespace MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities
{
    public class AVProductionAVProducerHouseBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<AVProduction, System.Guid, AVProducerHouse, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public AVProduction Prow { get; set; }

        public System.Guid SternId { get; set; }
        public AVProducerHouse Stern { get; set; }
    }
}
