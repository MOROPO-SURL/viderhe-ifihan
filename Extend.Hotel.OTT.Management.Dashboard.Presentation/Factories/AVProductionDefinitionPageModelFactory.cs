using MOROPO.VIDERHE.Extend.Hotel.OTT.Management.Dashboard.Presentation.Models.Page;

namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Management.Dashboard.Presentation.Factories
{
    public static class AVProductionDefinitionPageModelFactory
    {
        public static AVProductionGeneralDefinitionPageModel Build(Service.Hotel.OTT.API.Common.Models.AVProductionDisplayModel target)
        {
            if (target == null) return new AVProductionGeneralDefinitionPageModel();

            return new AVProductionGeneralDefinitionPageModel
            {
                Id = target.Id,
                Title = target.Title,
                Year = target.Year,
                AgeEdge = target.AgeEdge,
                Rate = target.Rate,
                About = target.About,
                Argument = target.Argument,
                Duration = System.TimeSpan.FromSeconds(target.Duration),
                Language = target.Language,
                Enabled = target.Enabled,
                Countries = new System.Collections.ObjectModel.ObservableCollection<Service.Hotel.OTT.API.Common.Models.CountryDisplayModel>(target.Countries),
                ProducerHouses = new System.Collections.ObjectModel.ObservableCollection<Service.Hotel.OTT.API.Common.Models.AVProducerHouseDisplayModel>(target.ProducerHouses),
                Genres = new System.Collections.ObjectModel.ObservableCollection<Service.Hotel.OTT.API.Common.Models.AVGenreDisplayModel>(target.Genres)
            };
        }
    }
}
