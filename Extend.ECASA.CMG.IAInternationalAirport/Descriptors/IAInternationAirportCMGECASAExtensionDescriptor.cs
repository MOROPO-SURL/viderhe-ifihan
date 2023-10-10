namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Descriptors
{
    public sealed class IAInternationAirportCMGECASAExtensionDescriptor : Common.Descriptors.IExtensionDescriptor
    {
        // {C192E5EF-0020-497F-B6D3-053213F4B3C4}
        public static System.Guid ID = new System.Guid(0xc192e5ef, 0x20, 0x497f, 0xb6, 0xd3, 0x5, 0x32, 0x13, 0xf4, 0xb3, 0xc4);

        public System.Guid Id => ID;

        public string Name => "ECASA Aeropuerto Ignacio Agramonte";

        // TODO Define upperviewing description
        public string Description => "Extensión para elementos personalizados de la plataforma VIDERHE para el aeropuerto internacional Ignacio Agramonte de la ciudad de Camagüey operado por ECASA.";
    }
}
