using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Models.View.Background;

namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Views.Background
{
    public class ImageBackgroundView : FFImageLoading.Forms.CachedImage
    {
        public ImageBackgroundView(ImageBackgroundViewModel model)
        {
            Source = model.Source;

            FadeAnimationEnabled = false;
            Aspect = Xamarin.Forms.Aspect.AspectFill;
            CacheType = FFImageLoading.Cache.CacheType.Disk;
            CacheDuration = System.TimeSpan.MaxValue;
        }
    }
}
