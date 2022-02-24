namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Overlaying.Descriptors
{
    public class InformationMenuOverlayDescriptor : Common.Overlaying.Descriptors.IOverlayDescriptor
    {
        public static System.Guid ID = System.Guid.Parse("98BF5422-C805-4632-AB78-195D31878358");

        public System.Guid Id => ID;

        public string Name => "Menú Informativo del Museo Ferroviario y la OHCC";

        public string Description => "Muestra un menú interactivo con secciones informativas relativas al Museo Ferroviario y la Oficina del Historiador de la Ciudad de Camagüey.";
    }
}
