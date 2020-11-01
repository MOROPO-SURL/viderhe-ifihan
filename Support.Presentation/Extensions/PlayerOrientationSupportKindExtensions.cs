namespace SmartSolucionesCuba.Videre.Support.Presentation.Extensions
{
    public static class PlayerOrientationSupportKindExtensions
    {
        public static string ToImageResourceNameSufix(this Videre.Extend.Common.Templating.Enumerations.PlayerOrientationSupportKind target)
        {
            if (target == Videre.Extend.Common.Templating.Enumerations.PlayerOrientationSupportKind.Portrait) return "-portrait";

            return "-landscape";
        }
    }
}
