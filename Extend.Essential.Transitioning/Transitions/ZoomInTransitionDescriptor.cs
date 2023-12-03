namespace MOROPO.VIDERHE.Extend.Essential.Transitioning.Transitions
{
    public class ZoomInTransitionDescriptor : Common.Transitioning.Descriptors.ITransitionDescriptor
    {
        public static System.Guid ID = System.Guid.Parse("8419A4AE-D95C-46E3-967D-505C29D7CACF");

        public System.Guid Id => ID;

        public string Name => "Maximización";

        public string Description => "Se muestra el contenido apliandoce desde el centro hasta ocupar su espacio designado.";
    }
}
