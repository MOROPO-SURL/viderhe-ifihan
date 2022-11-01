namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Extensions
{
    public static class ContentHorizontalAlignamentExtensions
    {
        public static Xamarin.Forms.LayoutAlignment ToLayoutAlignment(this Enumerations.ContentHorizontalAlignament target)
        {
            switch (target)
            {
                case Enumerations.ContentHorizontalAlignament.Left:
                    return Xamarin.Forms.LayoutAlignment.Start;

                case Enumerations.ContentHorizontalAlignament.Center:
                    return Xamarin.Forms.LayoutAlignment.Center;

                case Enumerations.ContentHorizontalAlignament.Right:
                    return Xamarin.Forms.LayoutAlignment.End;

                default:
                    return Xamarin.Forms.LayoutAlignment.Fill;
            }
        }
    }
}
