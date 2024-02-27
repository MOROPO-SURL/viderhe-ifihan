namespace MOROPO.VIDERHE.Cloud.Persistence.Entities
{
    public class PlayerTagBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Player, string, Tag, System.Guid>
    {
        public string ProwId { get; set; }
        public Player Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Tag Stern { get; set; }
    }
}
