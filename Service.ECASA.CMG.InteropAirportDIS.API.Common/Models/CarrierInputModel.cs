namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models
{
    public class CarrierInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Carrier, string>
    {
        public string Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public byte[] ImageContent { get; set; }

        public string ImageExtension { get; set; }

        public System.Guid? ImageId { get; set; }

        public System.Guid? CountryId { get; set; }

        public string PrimaryColor { get; set; }

        public string SecoundaryColor { get; set; }

        public Persistence.Entities.Carrier Export()
        {
            var entity = new Persistence.Entities.Carrier { Id = Id };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Carrier entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Carrier entity)
        {
            entity.Identity.Name = Name;
            // TODO Set Image entity at Controller if
            // TODO Set Country entity at Controller if
            entity.PrimaryColor = PrimaryColor;
            entity.SecoundaryColor = SecoundaryColor;
        }
    }
}
