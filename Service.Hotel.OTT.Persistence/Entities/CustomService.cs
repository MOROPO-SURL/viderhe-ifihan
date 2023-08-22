using System.Collections.Generic;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities
{
    public class CustomService : Framework.Guama.Core.Persistence.Entities.Contract.INamedEntity<System.Guid>, Framework.Guama.Core.Persistence.Entities.Contract.IHabilitableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public bool Enabled { get; set; }

        public string Description { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("FeatureImageId")]
        public Framework.Guama.Media.Persistence.Entities.Image FeatureImage { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public System.Guid? FeatureImageId { get; set; }

        public List<CustomServiceLanguageBridge> LanguageBridges { get; set; }

        public List<CustomServiceZoneBridge> ZoneBridges { get; set; }

        public CustomService()
        {
            LanguageBridges = new List<CustomServiceLanguageBridge>();
            ZoneBridges = new List<CustomServiceZoneBridge>();
        }
    }
}
