using MOROPO.VIDERHE.Extend.Common.Templating.Enumerations;

namespace MOROPO.VIDERHE.Support.Presentation.Extensions
{
    public static class PlayerOrientationSupportKindExtensions
    {
        public static string ToImageResourceNameSufix(this PlayerOrientationSupportKind target)
        {
            if (target == PlayerOrientationSupportKind.Portrait) return "-portrait";

            return "-landscape";
        }
    }
}
