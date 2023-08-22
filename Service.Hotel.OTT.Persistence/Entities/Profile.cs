using MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Enumerations;
using System.Collections.Generic;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities
{
    public class Profile : Framework.Guama.Core.Persistence.Entities.Contract.INamedEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public PresentationLayout PresentationLayout { get; set; }

        public Language Language { get; set; }

        public System.Guid? PresentationCorporativeScreenplayId { get; set; }

        public List<ProfileChannelBridge> ChannelBridges { get; set; }

        public Profile()
        {
            ChannelBridges = new List<ProfileChannelBridge>();
        }
    }
}
