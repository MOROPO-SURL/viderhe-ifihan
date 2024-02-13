using MOROPO.VIDERHE.Extend.Hotel.OTT.Management.Dashboard.Presentation.Extensions;
using MOROPO.VIDERHE.Extend.Hotel.OTT.Management.Dashboard.Presentation.Models.Page;

namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Management.Dashboard.Presentation.Factories
{
    public static class AVProductionImagesDefinitionPageModelFactory
    {
        public static AVProductionImagesDefinitionPageModel Build(Service.Hotel.OTT.API.Common.Models.AVProductionDisplayModel target)
        {
            return new AVProductionImagesDefinitionPageModel
            {
                Id = target.Id,
                PosterImageSource = target.PosterImage?.ToImageSource(),
                PosterImageId = target.PosterImage?.Id,
                PosterImageExtension = target.PosterImage?.Extension,
                PlacardImageSource = target.PlacardImage?.ToImageSource(),
                PlacardImageId = target.PlacardImage?.Id,
                PlacardImageExtension = target.PlacardImage?.Extension
            };
        }
    }
}
