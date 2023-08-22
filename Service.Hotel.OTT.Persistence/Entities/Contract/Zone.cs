using System.Collections.Generic;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities.Contract
{
    public abstract class Zone : Framework.Guama.Core.Persistence.Entities.Contract.INamedEntity<System.Guid>, Framework.Guama.Core.Persistence.Entities.Contract.IHabilitableEntity<System.Guid>
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

        public List<ZoneImageBridge> ImageBridges { get; set; }

        public List<ZoneScheduleBridge> ScheduleBridges { get; set; }

        public Zone()
        {
            ImageBridges = new List<ZoneImageBridge>();
            ScheduleBridges = new List<ZoneScheduleBridge>();
        }
    }
}
