namespace MOROPO.VIDERHE.Extend.CPCC.Descriptors
{
    public class CPCCExtensionDescriptor : Common.Descriptors.IExtensionDescriptor
    {
        public static System.Guid ID = System.Guid.Parse("C33D8EDE-4853-4407-8F14-7E363F1D4161");

        public System.Guid Id => ID;

        public string Name => "Cartelera CPCC";

        // TODO Define upperviewing description
        public string Description => "Extensión para la plataforma Viderhe del Centro Provincial de Cine de Camagüey para la promoción de su cartelera cultural.";
    }
}