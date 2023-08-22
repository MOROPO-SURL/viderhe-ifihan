namespace MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities
{
    public class AVGenre : Framework.Guama.Core.Persistence.Entities.Contract.INamedEntity<int>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }
    }
}
