using MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Enumerations;
using System.Collections.Generic;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities
{
    public class AVProduction : Framework.Guama.Core.Persistence.Entities.Contract.IHabilitableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Title { get; set; }

        public bool Enabled { get; set; }

        public int Year { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string About { get; set; }

        public string Argument { get; set; }

        public Language Language { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("CategoryId")]
        public AVCategory Category { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public int? CategoryId { get; set; }

        [System.ComponentModel.DataAnnotations.Range(1, 5)]
        public int Rate { get; set; }

        public int? AgeEdge { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("CountryId")]
        public Framework.Guama.Location.Persistence.Entities.Country Country { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public System.Guid? CountryId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("PosterImageId")]
        public Framework.Guama.Media.Persistence.Entities.Image PosterImage { get; set; }
        public System.Guid? PosterImageId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("PlacardImageId")]
        public Framework.Guama.Media.Persistence.Entities.Image PlacardImage { get; set; }
        public System.Guid? PlacardImageId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("TrailerVideoId")]
        public Framework.Guama.Media.Persistence.Entities.Video TrailerVideo { get; set; }
        public System.Guid? TrailerVideoId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("VideoId")]
        public Framework.Guama.Media.Persistence.Entities.Video Video { get; set; }
        public System.Guid? VideoId { get; set; }

        public List<AVProductionAVGenreBridge> GenreBridges { get; set; }

        public List<AVProductionAVProducerHouseBridge> ProducerHouseBridges { get; set; }

        public List<AVProductionCountryBridge> CountryBridges { get; set; }

        public AVProduction()
        {
            GenreBridges = new List<AVProductionAVGenreBridge>();
            ProducerHouseBridges = new List<AVProductionAVProducerHouseBridge>();
            CountryBridges = new List<AVProductionCountryBridge>();
        }
    }
}
