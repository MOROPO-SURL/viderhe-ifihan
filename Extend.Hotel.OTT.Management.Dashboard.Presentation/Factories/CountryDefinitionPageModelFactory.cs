namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Management.Dashboard.Presentation.Factories
{
    public static class CountryDefinitionPageModelFactory
    {
        public static Models.Page.CountryDefinitionPageModel Build(Service.Hotel.OTT.API.Common.Models.CountryDisplayModel target)
        {
            if (target == null) return new Models.Page.CountryDefinitionPageModel();

            return new Models.Page.CountryDefinitionPageModel
            {
                Id = target.Id,
                Name = target.Name,
                IsoCode = target.IsoCode
            };
        }
    }
}
