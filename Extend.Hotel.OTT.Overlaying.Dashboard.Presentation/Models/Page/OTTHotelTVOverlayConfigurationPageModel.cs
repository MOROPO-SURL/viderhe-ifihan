namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Overlaying.Dashboard.Presentation.Models.Page
{
    public class OTTHotelTVOverlayConfigurationPageModel : Support.Presentation.Dashboard.Models.Page.FormPageModel
    {
        private int roomId;
        private System.Guid? backgroundScreenplayId;
        private System.Guid? brandChannelScreenplayId;
        private Cloud.Api.Common.Models.ScreenplayDisplayModel[] availableScreenplays;

        public int RoomId { get => roomId; set => SetProperty(ref roomId, value); }

        public System.Guid? BackgroundScreenplayId { get => backgroundScreenplayId; set => SetProperty(ref backgroundScreenplayId, value); }

        public System.Guid? BrandChannelScreenplayId { get => brandChannelScreenplayId; set => SetProperty(ref brandChannelScreenplayId, value); }

        public Cloud.Api.Common.Models.ScreenplayDisplayModel[] AvailableScreenplays { get => availableScreenplays; set => SetProperty(ref availableScreenplays, value); }
    }
}
