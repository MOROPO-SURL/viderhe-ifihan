namespace MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities
{
    public class AVCategory : Framework.Guama.Core.Persistence.Entities.Contract.INamedEntity<int>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("ParentId")]
        public AVCategory Parent { get; set; }
        public int? ParentId { get; set; }

        public System.Collections.Generic.List<AVCategory> Children { get; set; }
    }
}
