namespace SmartSolucionesCuba.Viderhe.Extend.HotelOTT.Management.Dashboard.Presentation.Factories
{
    public static class AVGenreDefinitionPageModelFactory
    {
        public static Models.Page.AVGenreDefinitionPageModel Build(MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models.AVGenreDisplayModel target)
        {
            if (target == null) return new Models.Page.AVGenreDefinitionPageModel();

            return new Models.Page.AVGenreDefinitionPageModel
            {
                Id = target.Id,
                Name = target.Name
            };
        }
    }
}
