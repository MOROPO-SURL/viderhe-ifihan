using MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models
{
    public class AVProducerHouseInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<AVProducerHouse, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public System.DateTime? BornDate { get; set; }

        public string About { get; set; }

        public byte[] ImageContent { get; set; }

        public string ImageExtension { get; set; }

        public System.Guid? ImageId { get; set; }

        public AVProducerHouse Export()
        {
            var entity = new AVProducerHouse
            {
                Identity = new Framework.Guama.Identity.Persistence.Entities.OrganizationIdentity()
            };

            Mergue(entity);

            return entity;
        }

        public void Import(AVProducerHouse entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(AVProducerHouse entity)
        {
            entity.Identity.Name = Name;
            entity.Identity.BornDate = BornDate;
            entity.Identity.About = About;
        }
    }
}
