namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Overlaying.Dashboard.Presentation.Factories
{
    public static class OTTHotelTVOverlayConfigurationPageModelFactory
    {
        public static Models.Page.OTTHotelTVOverlayConfigurationPageModel Build(string serializedContext)
        {
            try
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Overlaying.Presentation.Models.Context.OTTHotelTVOverlayContextModel>(serializedContext);

                return new Models.Page.OTTHotelTVOverlayConfigurationPageModel
                {
                    RoomId = context.RoomId,
                    BackgroundScreenplayId = context.BackgroundScreenplayId,
                    BrandChannelScreenplayId = context.BrandChannelScreenplayId
                };
            }
            catch
            {
                return new Models.Page.OTTHotelTVOverlayConfigurationPageModel();
            }
        }
    }
}
