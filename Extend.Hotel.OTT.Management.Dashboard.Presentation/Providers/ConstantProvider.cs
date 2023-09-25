namespace SmartSolucionesCuba.Viderhe.Extend.HotelOTT.Management.Dashboard.Presentation.Providers
{
    public static class ConstantProvider
    {
        public static MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Enumerations.ChannelKind[] CHANNEL_KINDS = new MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Enumerations.ChannelKind[] 
        {
            MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Enumerations.ChannelKind.RF,
            MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Enumerations.ChannelKind.IPTV
        };

        public static MOROPO.SAPRESSC.Middleware.Identity.Persistence.Enumerations.Sex[] SEXS = new MOROPO.SAPRESSC.Middleware.Identity.Persistence.Enumerations.Sex[]
        {
            MOROPO.SAPRESSC.Middleware.Identity.Persistence.Enumerations.Sex.Unknown,
            MOROPO.SAPRESSC.Middleware.Identity.Persistence.Enumerations.Sex.Male,
            MOROPO.SAPRESSC.Middleware.Identity.Persistence.Enumerations.Sex.Famale
        };

        public static MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Enumerations.Language[] LANGUAGES = new MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Enumerations.Language[]
        {
            MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Enumerations.Language.Spanish,
            MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Enumerations.Language.English,
            MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Enumerations.Language.French,
            MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Enumerations.Language.German,
            MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Enumerations.Language.Russian,
            MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Enumerations.Language.Mandarin
        };

        public static int[] RATES = new int[] { 5, 4, 3, 2, 1 };

        public static Xamarin.Forms.ImageSource DEFAULT_IMAGE = Xamarin.Forms.ImageSource.FromResource("SmartSolucionesCuba.Viderhe.Extend.HotelOTT.Management.Dashboard.Presentation.Assets.DefaultPicture.png");
    }
}
