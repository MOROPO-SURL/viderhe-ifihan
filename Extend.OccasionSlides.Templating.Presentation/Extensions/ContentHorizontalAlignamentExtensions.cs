using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Enumerations;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Extensions
{
    public static class ContentHorizontalAlignamentExtensions
    {
        public static Xamarin.Forms.LayoutAlignment ToLayoutAlignment(this ContentHorizontalAlignament target)
        {
            switch (target)
            {
                case ContentHorizontalAlignament.Left:
                    return Xamarin.Forms.LayoutAlignment.Start;

                case ContentHorizontalAlignament.Center:
                    return Xamarin.Forms.LayoutAlignment.Center;

                case ContentHorizontalAlignament.Right:
                    return Xamarin.Forms.LayoutAlignment.End;

                default:
                    return Xamarin.Forms.LayoutAlignment.Fill;
            }
        }
    }
}
