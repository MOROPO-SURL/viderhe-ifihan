using MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Enumerations;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities
{
    public class CustomServiceLanguageBridge
    {
        public System.Guid ServiceId { get; set; }
        public CustomService Service { get; set; }

        public Language Language { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
