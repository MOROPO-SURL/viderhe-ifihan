using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Enumerations;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Extensions
{
    public static class OverlapSizeExtensions
    {
        public static int ToColumnCount(this OverlapSize target)
        {
            switch (target)
            {
                case OverlapSize.Short:
                    return 3;

                case OverlapSize.Medium:
                    return 4;

                case OverlapSize.Large:
                default:
                    return 5;
            };
        }
    }
}
