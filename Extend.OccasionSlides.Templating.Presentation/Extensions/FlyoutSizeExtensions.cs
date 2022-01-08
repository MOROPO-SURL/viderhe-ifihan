namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Extensions
{
    public static class FlyoutSizeExtensions
    {
        public static int ToColumnCount(this Enumerations.FlyoutSize target)
        { 
            switch (target)
            {
                case Enumerations.FlyoutSize.Short:
                    return 3;

                case Enumerations.FlyoutSize.Medium:
                    return 4;

                case Enumerations.FlyoutSize.Large:
                default:
                    return 5;
            };
        }
    }
}
