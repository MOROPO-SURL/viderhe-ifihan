namespace MOROPO.VIDERHE.Extend.Essential.Templating.Presentation.Extensions
{
    public static class PictureLayoutModeExtensions
    {
        public static Xamarin.Forms.Aspect ToXamarinFormsAspect(this Enumerations.PictureLayoutMode target)
        {
            switch (target)
            {
                case Enumerations.PictureLayoutMode.Fill:
                    return Xamarin.Forms.Aspect.Fill;

                case Enumerations.PictureLayoutMode.AspectFill:
                    return Xamarin.Forms.Aspect.AspectFill;

                case Enumerations.PictureLayoutMode.AspectFit:
                default:
                    return Xamarin.Forms.Aspect.AspectFit;
            }
        }
    }
}
