namespace MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models
{
    public class AVGenreDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.AVGenre, int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void Import(Persistence.Entities.AVGenre entity)
        {
            Id = entity.Id;
            Name = entity.Name;
        }
    }
}
