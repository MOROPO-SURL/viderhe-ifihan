namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Extensions
{
    public static class MediaContextOverlaySizeExtensions
    {
        public static int ToColumnCount(this Enumerations.MediaContextOverlaySize target)
        { 
            switch (target)
            {
                case Enumerations.MediaContextOverlaySize.Short:
                    return 3;

                case Enumerations.MediaContextOverlaySize.Medium:
                    return 4;

                case Enumerations.MediaContextOverlaySize.Large:
                default:
                    return 5;
            };
        }
    }
}
