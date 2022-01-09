namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Extensions
{
    public static class OverlapSizeExtensions
    {
        public static int ToColumnCount(this Enumerations.OverlapSize target)
        { 
            switch (target)
            {
                case Enumerations.OverlapSize.Short:
                    return 3;

                case Enumerations.OverlapSize.Medium:
                    return 4;

                case Enumerations.OverlapSize.Large:
                default:
                    return 5;
            };
        }
    }
}
