using MOROPO.VIDERHE.Extend.Hotel.OTT.Management.Dashboard.Presentation.Extensions;

namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Management.Dashboard.Presentation.Factories
{
    public static class ChannelDefinitionPageModelFactory
    {
        public static Models.Page.ChannelDefinitionPageModel Build(Service.Hotel.OTT.API.Common.Models.ChannelDisplayModel target)
        {
            if (target == null) return new Models.Page.ChannelDefinitionPageModel();

            var model = new Models.Page.ChannelDefinitionPageModel
            {
                Id = target.Id,
                Name = target.Name,
                Enabled = target.Enabled,
                FeatureImageId = target.FeatureImage?.Id,
                FeatureImageExtension = target.FeatureImage?.Extension,
                FeatureImageSource = target.FeatureImage?.ToImageSource(),
                Kind = target.Kind,
                Description = target.Description
            };

            if (target.Kind == Service.Hotel.OTT.Persistence.Enumerations.ChannelKind.IPTV)
            {
                model.IPTVUrl = target.SourceSerialization;
            }
            else
            {
                model.RadioFrecuencyBand = int.Parse(target.SourceSerialization);
            }

            return model;
        }
    }
}
