namespace SmartSolucionesCuba.Viderhe.Extend.HotelOTT.Management.Dashboard.Presentation.Providers
{
    public static class ConstantProvider
    {
        public static MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Enumerations.ChannelKind[] CHANNEL_KINDS = new MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Enumerations.ChannelKind[] 
        {
            MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Enumerations.ChannelKind.RF,
            MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Enumerations.ChannelKind.IPTV
        };

        public static Xamarin.Forms.ImageSource DEFAULT_IMAGE = Xamarin.Forms.ImageSource.FromResource("SmartSolucionesCuba.Viderhe.Extend.HotelOTT.Management.Dashboard.Presentation.Assets.DefaultPicture.png");
    }
}
