namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Extensions
{
    public static class LayoutAlignmentExtensions
    {
        public static Enumerations.ContentHorizontalAlignament? ToContentHorizontalAlignament(this Xamarin.Forms.LayoutAlignment target)
        {
            switch (target)
            {
                case Xamarin.Forms.LayoutAlignment.Center: 
                    return Enumerations.ContentHorizontalAlignament.Center;

                case Xamarin.Forms.LayoutAlignment.Start:
                    return Enumerations.ContentHorizontalAlignament.Left;

                case Xamarin.Forms.LayoutAlignment.End:
                    return Enumerations.ContentHorizontalAlignament.Right;

                case Xamarin.Forms.LayoutAlignment.Fill:
                default:
                    return null;
            }
        }
    }
}
