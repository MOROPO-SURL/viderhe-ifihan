using SmartSolucionesCuba.Viderhe.Extend.HotelOTT.Management.Dashboard.Presentation.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.HotelOTT.Management.Dashboard.Presentation.Factories
{
    public static class PersonalityDefinitionPageModelFactory
    {
        public static Models.Page.PersonalityDefinitionPageModel Build(MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models.PersonalityDisplayModel target)
        {
            if (target == null) return new Models.Page.PersonalityDefinitionPageModel();

            var model = new Models.Page.PersonalityDefinitionPageModel
            {
                Id = target.Id,
                Name = target.Name,
                LastName = target.LastName,
                Alias = target.Alias,
                Sex = target.Sex,
                HasBornDate = target.BornDate != null,
                ImageId = target.Image?.Id,
                ImageExtension = target.Image?.Extension,
                ImageSource = target.Image?.ToImageSource(),
                About = target.About
            };

            if (model.HasBornDate)
            {
                model.BornDate = target.BornDate.Value;
            }

            return model;
        }
    }
}
