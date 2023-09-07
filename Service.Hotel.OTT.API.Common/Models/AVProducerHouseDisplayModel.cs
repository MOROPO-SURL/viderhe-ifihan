namespace MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models
{
    public class AVProducerHouseDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.AVProducerHouse, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Name { get; set; }

        public System.DateTime? BornDate { get; set; }

        public string About { get; set; }

        public ImageDisplayModel Image { get; set; }

        public void Import(Persistence.Entities.AVProducerHouse entity)
        {
            Id = entity.Id;
            Name = entity.Identity.Name;
            BornDate = entity.Identity.BornDate;
            About = entity.Identity.About;
        }
    }
}
