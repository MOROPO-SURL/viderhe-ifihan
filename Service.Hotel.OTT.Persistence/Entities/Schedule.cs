namespace MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities
{
    public class Schedule : Framework.Guama.Core.Persistence.Entities.Contract.IEntity<int>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }

        public System.TimeSpan BeginTime { get; set; }

        public System.TimeSpan EndTime { get; set; }

        public string Description { get; set; }
    }
}
