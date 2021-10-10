namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Transitioning.Transitions
{
    public class FadeInTransitionDescriptor : Common.Transitioning.Descriptors.ITransitionDescriptor
    {
        public static System.Guid ID = System.Guid.Parse("875A1B4D-B024-45C4-B606-1356192FD025");

        public System.Guid Id => ID;

        public string Name => "Aparición";

        public string Description => "Se muestra el contenido con una aparición suave en el lugar con desplazamiento vertical de manera opcional.";
    }
}
