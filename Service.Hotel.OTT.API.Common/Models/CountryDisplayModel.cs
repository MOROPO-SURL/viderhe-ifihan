namespace MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models
{
    public class CountryDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Framework.Guama.Location.Persistence.Entities.Country, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Name { get; set; }

        public string IsoCode { get; set; }

        public void Import(Framework.Guama.Location.Persistence.Entities.Country entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            IsoCode = entity.IsoCode;
        }
    }
}
