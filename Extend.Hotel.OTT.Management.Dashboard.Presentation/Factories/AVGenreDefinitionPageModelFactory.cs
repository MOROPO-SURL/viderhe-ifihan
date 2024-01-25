using MOROPO.VIDERHE.Extend.Hotel.OTT.Management.Dashboard.Presentation.Models.Page;

namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Management.Dashboard.Presentation.Factories
{
    public static class AVGenreDefinitionPageModelFactory
    {
        public static AVGenreDefinitionPageModel Build(Service.Hotel.OTT.API.Common.Models.AVGenreDisplayModel target)
        {
            if (target == null) return new AVGenreDefinitionPageModel();

            return new AVGenreDefinitionPageModel
            {
                Id = target.Id,
                Name = target.Name
            };
        }
    }
}
