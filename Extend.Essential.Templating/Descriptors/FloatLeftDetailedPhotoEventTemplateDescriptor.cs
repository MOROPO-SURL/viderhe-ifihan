namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Descriptors
{
    public class FloatLeftDetailedPhotoEventTemplateDescriptor : AbstractPhotoEventDescriptor
    {
        public static System.Guid ID = System.Guid.Parse("D6856FBB-194B-40FA-9FF9-A16EA09F446A");

        public override System.Guid Id => ID;

        public override Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupport => Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape;

        public override string Name => "Evento con Foto | Detalles flotando";

        public override string Description => "Muestra títutlo, fecha, lugar, imagen y descripción de un evento detallado con panel flotando a la izquierda o derecha.";
    }
}
