namespace MOROPO.VIDERHE.Cloud.Persistence.Entities
{
    public class Player : Framework.Guama.Core.Persistence.Entities.Contract.INamedEntity<string>, Framework.Guama.Core.Persistence.Entities.Contract.IPersistenceSignable
    {
        public Player()
        {
            ScheduledRelaunches = new System.Collections.Generic.List<ScheduledRelaunch>();
            TagBridges = new System.Collections.Generic.List<PlayerTagBridge>();
        }

        [System.ComponentModel.DataAnnotations.Key, System.ComponentModel.DataAnnotations.RegularExpression(@"^[0-9A-Z]{7}$")]
        public string Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public System.Guid AccountId { get; set; }

        public Account Account { get; set; }

        public System.Guid? ScreenplayId { get; set; }

        public Screenplay Screenplay { get; set; }

        public System.Guid? OverlayId { get; set; }

        public Overlay Overlay { get; set; }

        public string SerializedOverlayContext { get; set; }

        public string About { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Signature { get; set; }

        public System.Collections.Generic.List<ScheduledRelaunch> ScheduledRelaunches { get; set; }

        public System.Collections.Generic.List<PlayerTagBridge> TagBridges { get; set; }

        public object GetSignableEntityModel()
        {
            return new { Id, Name, AccountId = Account.Id };
        }
    }
}
