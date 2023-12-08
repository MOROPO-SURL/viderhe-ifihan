namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Overlaying.Descriptors
{
    public class DinamicAirportCheckInMonitorOverlayDescriptor : Common.Overlaying.Descriptors.IOverlayDescriptor
    {
        // {C6320FD3-5D0E-4714-815E-1BD4A149910D}
        public static System.Guid ID = new System.Guid(0xc6320fd3, 0x5d0e, 0x4714, 0x81, 0x5e, 0x1b, 0xd4, 0xa1, 0x49, 0x91, 0xd);

        public System.Guid Id => ID;

        public string Name => "Monitor Dinámico de Check-in en Aeropuerto";

        public string Description => "Presentación dinámica del estado de una estación de check-in en el aeropuerto.";
    }
}
