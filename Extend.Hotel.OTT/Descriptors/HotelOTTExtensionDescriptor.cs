namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Descriptors
{
    public class HotelOTTExtensionDescriptor : Common.Descriptors.IExtensionDescriptor
    {
        // {F96642C8-3B28-47B0-BA80-225C9D53541D}
        public static System.Guid ID = new System.Guid(0xf96642c8, 0x3b28, 0x47b0, 0xba, 0x80, 0x22, 0x5c, 0x9d, 0x53, 0x54, 0x1d);

        public System.Guid Id => ID;

        public string Name => "Televisor Hotelero (OTT)";

        // TODO Define upperviewing description
        public string Description => "Extensión para generar en pantallas gestionadas con VIDERHE el concepto Over-The-Top para la televisión en instalaciones hoteleras.";
    }
}
