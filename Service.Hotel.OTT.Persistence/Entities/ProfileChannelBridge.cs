namespace MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities
{
    public class ProfileChannelBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Profile, System.Guid, Channel, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public Profile Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Channel Stern { get; set; }
    }
}
