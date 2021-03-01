namespace SmartSolucionesCuba.Viderhe.Weather.Api.Common.Models
{
    public class CityModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public System.Globalization.RegionInfo Region { get; set; }

        public LocationModel Location { get; set; }
    }
}
