namespace MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities
{
    public class AVProductionCountryBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<AVProduction, System.Guid, Framework.Guama.Location.Persistence.Entities.Country, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public AVProduction Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Framework.Guama.Location.Persistence.Entities.Country Stern { get; set; }
    }
}
