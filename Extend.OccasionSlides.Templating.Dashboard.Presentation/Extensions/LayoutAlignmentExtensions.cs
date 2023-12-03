using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Enumerations;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Dashboard.Presentation.Extensions
{
    public static class LayoutAlignmentExtensions
    {
        public static ContentHorizontalAlignament? ToContentHorizontalAlignament(this Xamarin.Forms.LayoutAlignment target)
        {
            switch (target)
            {
                case Xamarin.Forms.LayoutAlignment.Center:
                    return ContentHorizontalAlignament.Center;

                case Xamarin.Forms.LayoutAlignment.Start:
                    return ContentHorizontalAlignament.Left;

                case Xamarin.Forms.LayoutAlignment.End:
                    return ContentHorizontalAlignament.Right;

                case Xamarin.Forms.LayoutAlignment.Fill:
                default:
                    return null;
            }
        }
    }
}
