namespace MOROPO.VIDERHE.Terminal.Player.UWP.Extensions
{
    public static class XamarinFormsAspectExtensions
    {
        public static Windows.UI.Xaml.Media.Stretch ToUWP(this Xamarin.Forms.Aspect target)
        {
            switch (target)
            {
                case Xamarin.Forms.Aspect.Fill:
                    return Windows.UI.Xaml.Media.Stretch.Fill;

                case Xamarin.Forms.Aspect.AspectFill:
                    return Windows.UI.Xaml.Media.Stretch.UniformToFill;

                case Xamarin.Forms.Aspect.AspectFit:
                default:
                    return Windows.UI.Xaml.Media.Stretch.Uniform;
            }
        }
    }
}
