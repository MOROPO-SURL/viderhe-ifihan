namespace MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models
{
    public class PersonalityDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Personality, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Alias { get; set; }

        public System.DateTime? BornDate { get; set; }

        public Framework.Guama.Identity.Persistence.Enumerations.Sex Sex { get; set; }

        public string About { get; set; }

        public ImageDisplayModel Image { get; set; }

        public void Import(Persistence.Entities.Personality entity)
        {
            Id = entity.Id;
            Name = entity.Identity.Name;
            LastName = entity.Identity.LastName;
            Alias = entity.Identity.Alias;
            BornDate = entity.Identity.BornDate;
            Sex = entity.Identity.Sex;
            About = entity.Identity.About;
        }
    }
}
