namespace SmartSolucionesCuba.Viderhe.Extend.HotelOTT.Management.Dashboard.Presentation.Factories
{
    public static class ChannelDefinitionPageModelFactory
    {
        public static Models.Page.ChannelDefinitionPageModel Build(MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models.ChannelDisplayModel target)
        {
            if (target == null) return new Models.Page.ChannelDefinitionPageModel();

            var model = new Models.Page.ChannelDefinitionPageModel
            {
                Id = target.Id,
                Name = target.Name,
                Enabled = target.Enabled,
                FeatureImageId = target.FeatureImageId,
                FeatureImageExtension = target.FeatureImageExtension,
                Kind = target.Kind,
                Description = target.Description
            };

            if (target.Kind == MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Enumerations.ChannelKind.IPTV)
            {
                model.IPTVUrl = new System.Uri(target.SourceSerialization);
            }
            else
            {
                model.RadioFrecuencyBand = int.Parse(target.SourceSerialization);
            }

            return model;
        }
    }
}
