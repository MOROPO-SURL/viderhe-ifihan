namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Dashboard.Presentation.Extensions
{
    public static class AspectExtensions
    {
        public static Essential.Templating.Enumerations.PictureLayoutMode ToPictureLayoutMode(this Xamarin.Forms.Aspect target)
        {
            switch (target)
            {
                case Xamarin.Forms.Aspect.Fill:
                    return Essential.Templating.Enumerations.PictureLayoutMode.Fill;

                case Xamarin.Forms.Aspect.AspectFill:
                    return Essential.Templating.Enumerations.PictureLayoutMode.AspectFill;

                case Xamarin.Forms.Aspect.AspectFit:
                default:
                    return Essential.Templating.Enumerations.PictureLayoutMode.AspectFit;
            }
        }
    }
}
