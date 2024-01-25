using MOROPO.VIDERHE.Extend.Hotel.OTT.Management.Dashboard.Presentation.Extensions;

namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Management.Dashboard.Presentation.Factories
{
    public static class AVProducerHouseDefinitionPageModelFactory
    {
        public static Models.Page.AVProducerHouseDefinitionPageModel Build(Service.Hotel.OTT.API.Common.Models.AVProducerHouseDisplayModel target)
        {
            if (target == null) return new Models.Page.AVProducerHouseDefinitionPageModel();

            var model = new Models.Page.AVProducerHouseDefinitionPageModel
            {
                Id = target.Id,
                Name = target.Name,
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
