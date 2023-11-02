using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Factories
{
    public static class CountryDefinitionPageModelFactory
    {
        public static Models.Page.CountryDefinitionPageModel Build(MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.CountryDisplayModel target)
        {
            if (target == null) return new Models.Page.CountryDefinitionPageModel();

            var country = ISO3166.Country.List.First(item => item.TwoLetterCode == target.IsoCode);

            return new Models.Page.CountryDefinitionPageModel
            {
                Id = target.Id,
                Country = country,
                LocalizedName = target.Name == country.Name ? null : target.Name
            };
        }
    }
}
