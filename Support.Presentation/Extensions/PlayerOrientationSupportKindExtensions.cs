namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Extensions
{
    public static class PlayerOrientationSupportKindExtensions
    {
        public static string ToImageResourceNameSufix(this Viderhe.Extend.Common.Templating.Enumerations.PlayerOrientationSupportKind target)
        {
            if (target == Viderhe.Extend.Common.Templating.Enumerations.PlayerOrientationSupportKind.Portrait) return "-portrait";

            return "-landscape";
        }
    }
}
