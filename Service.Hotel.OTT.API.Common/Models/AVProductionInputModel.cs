using MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models
{
    public class AVProductionInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<AVProduction, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Title { get; set; }

        public bool Enabled { get; set; }

        public int Duration { get; set; }

        public int Year { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string About { get; set; }

        public string Argument { get; set; }

        public Persistence.Enumerations.Language Language { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public int? CategoryId { get; set; }

        [System.ComponentModel.DataAnnotations.Range(1, 5)]
        public int Rate { get; set; }

        public int? AgeEdge { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public System.Guid? CountryId { get; set; }

        public AVGenreDisplayModel[] Genres { get; set; }

        public AVProducerHouseDisplayModel[] ProducerHouses { get; set; }

        public CountryDisplayModel[] Countries { get; set; }

        public AVProduction Export()
        {
            var entity = new AVProduction();

            Mergue(entity);

            return entity;
        }

        public void Import(AVProduction entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(AVProduction entity)
        {
            entity.Title = Title;
            entity.Enabled = Enabled;
            entity.Duration = Duration;
            entity.Year = Year;
            entity.About = About;
            entity.Argument = Argument;
            entity.Language = Language;
            entity.CategoryId = CategoryId;
            entity.Rate = Rate;
            entity.AgeEdge = AgeEdge;
            entity.CountryId = CountryId;
        }
    }
}
