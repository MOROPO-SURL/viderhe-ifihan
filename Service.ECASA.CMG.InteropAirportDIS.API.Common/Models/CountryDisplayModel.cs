namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models
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

        public override bool Equals(object obj)
        {
            if (!(obj is CountryDisplayModel)) return false;

            return Id == (obj as CountryDisplayModel).Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
