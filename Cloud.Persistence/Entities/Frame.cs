namespace MOROPO.VIDERHE.Cloud.Persistence.Entities
{
    public class Frame : Framework.Guama.Core.Persistence.Entities.Contract.IEntity<long>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public long Id { get; set; }

        public System.Guid ScreenplayId { get; set; }

        public Screenplay Screenplay { get; set; }

        public System.Guid PlacardId { get; set; }

        public Placard Placard { get; set; }

        public int Priority { get; set; }
    }
}
