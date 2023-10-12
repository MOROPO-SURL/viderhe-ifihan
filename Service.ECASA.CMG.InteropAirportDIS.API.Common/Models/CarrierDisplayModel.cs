namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models
{
    public class CarrierDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Carrier, string>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public System.Guid? ImageId { get; set; }

        public string ImageExtension { get; set; }

        public CountryDisplayModel Country { get; set; }

        public string PrimaryColor { get; set; }

        public string SecoundaryColor { get; set; }

        public void Import(Persistence.Entities.Carrier entity)
        {
            Id = entity.Id;
            Name = entity.Identity.Name;
            ImageId = entity.Identity.ImageId;
            // TODO Set ImageExtension value at Controller 
            PrimaryColor = entity.PrimaryColor;
            SecoundaryColor = entity.SecoundaryColor;

            Country = new CountryDisplayModel();

            Country.Import(entity.Country);
        }
    }
}
