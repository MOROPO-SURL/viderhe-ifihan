using MOROPO.Framework.Guama.Identity.Persistence.Enumerations;

namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Management.Dashboard.Presentation.Providers
{
    public static class ConstantProvider
    {
        public static Service.Hotel.OTT.Persistence.Enumerations.ChannelKind[] CHANNEL_KINDS = new Service.Hotel.OTT.Persistence.Enumerations.ChannelKind[]
        {
            Service.Hotel.OTT.Persistence.Enumerations.ChannelKind.RF,
            Service.Hotel.OTT.Persistence.Enumerations.ChannelKind.IPTV
        };

        public static Sex[] SEXS = new Sex[]
        {
            Sex.Unknown,
            Sex.Male,
            Sex.Famale
        };

        public static Service.Hotel.OTT.Persistence.Enumerations.Language[] LANGUAGES = new Service.Hotel.OTT.Persistence.Enumerations.Language[]
        {
            Service.Hotel.OTT.Persistence.Enumerations.Language.Spanish,
            Service.Hotel.OTT.Persistence.Enumerations.Language.English,
            Service.Hotel.OTT.Persistence.Enumerations.Language.French,
            Service.Hotel.OTT.Persistence.Enumerations.Language.German,
            Service.Hotel.OTT.Persistence.Enumerations.Language.Russian,
            Service.Hotel.OTT.Persistence.Enumerations.Language.Mandarin
        };

        public static int[] RATES = new int[] { 5, 4, 3, 2, 1 };

        public static Xamarin.Forms.ImageSource DEFAULT_IMAGE = Xamarin.Forms.ImageSource.FromResource("SmartSolucionesCuba.Viderhe.Extend.HotelOTT.Management.Dashboard.Presentation.Assets.DefaultPicture.png");
    }
}
