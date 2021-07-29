namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Transitioning.Transitions
{
    public class ArriveTransitionDescriptor : Common.Transitioning.Descriptors.ITransitionDescriptor
    {
        public static System.Guid ID = System.Guid.Parse("CA93001F-1E26-4D67-8CE7-B9DC9B4D2E58");

        public System.Guid Id => ID;

        public string Name => "Llegada";

        public string Description => "Se muestra el contenido llegando con desplazamiento vertical u horizontal.";
    }
}
