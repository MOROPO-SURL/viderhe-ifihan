using MOROPO.Framework.Guama.Location.Persistence.Entities;

namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models
{
    public class CountryInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Country, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.RegularExpression("^[A-Z]{2}$")]
        public string IsoCode { get; set; }

        public Country Export()
        {
            var entity = new Country();

            Mergue(entity);

            return entity;
        }

        public void Import(Country entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Country entity)
        {
            entity.Name = Name;
            entity.IsoCode = IsoCode;
        }
    }
}
