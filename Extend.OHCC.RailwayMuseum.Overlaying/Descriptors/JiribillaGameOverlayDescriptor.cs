namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Overlaying.Descriptors
{
    public class JiribillaGameOverlayDescriptor : Common.Overlaying.Descriptors.IOverlayDescriptor
    {
        public static System.Guid ID = System.Guid.Parse("841A3A9F-C055-4205-B973-9FDF87370013");

        public System.Guid Id => ID;

        public string Name => "Juego La Jiribilla";

        // TODO Define upperviewing description
        public string Description => "Inicia el juego La Jiribilla con el dispositivo como anfitrión e instruyendo a los dispositivos relacionados como invitados y expectadores a iniciar en los respectivos roles del juego.";
    }
}
