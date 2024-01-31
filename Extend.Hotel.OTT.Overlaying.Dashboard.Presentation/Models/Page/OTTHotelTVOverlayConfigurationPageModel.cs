namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Overlaying.Dashboard.Presentation.Models.Page
{
    public class OTTHotelTVOverlayConfigurationPageModel : Support.Presentation.Dashboard.Models.Page.FormPageModel
    {
        private int roomId;
        private Cloud.Api.Common.Models.ScreenplayDisplayModel brandChannelScreenplay;
        private Cloud.Api.Common.Models.ScreenplayDisplayModel[] availableScreenplays;

        public int RoomId { get => roomId; set => SetProperty(ref roomId, value); }

        public Cloud.Api.Common.Models.ScreenplayDisplayModel BrandChannelScreenplay { get => brandChannelScreenplay; set => SetProperty(ref brandChannelScreenplay, value); }

        public Cloud.Api.Common.Models.ScreenplayDisplayModel[] AvailableScreenplays { get => availableScreenplays; set => SetProperty(ref availableScreenplays, value); }
    }
}
