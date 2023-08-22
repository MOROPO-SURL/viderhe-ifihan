namespace MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities
{
    public class AVProductionAVGenreBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<AVProduction, System.Guid, AVGenre, int>
    {
        public System.Guid ProwId { get; set; }
        public AVProduction Prow { get; set; }

        public int SternId { get; set; }
        public AVGenre Stern { get; set; }
    }
}
