using MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models
{
    public class AVGenreInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<AVGenre, int>
    {
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public AVGenre Export()
        {
            var entity = new AVGenre();

            Mergue(entity);

            return entity;
        }

        public void Import(AVGenre entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(AVGenre entity)
        {
            entity.Name = Name;
        }
    }
}
