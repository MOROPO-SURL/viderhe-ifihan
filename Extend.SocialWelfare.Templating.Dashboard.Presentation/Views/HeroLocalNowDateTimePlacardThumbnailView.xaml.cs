using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Dashboard.Presentation.Views
{
    public partial class HeroLocalNowDateTimePlacardThumbnailView : XFToolKit.Mvvm.Views.ContentView
    {
        public HeroLocalNowDateTimePlacardThumbnailView(Support.Presentation.Models.View.PlacardViewModel model)
        {
            InitializeComponent();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.Placard.HeroLocalNowDateTimePlacardContextModel>(model.SerializedContext);

            switch (context.Background.Kind)
            {
                case Enumerations.BackgroundKind.Solid:
                    BackgroundColor = Xamarin.Forms.Color.FromHex(context.Background.SerializedContext);

                    break;

                case Enumerations.BackgroundKind.Gradient:
                    Content = new MagicGradients.GradientView
                    {
                        GradientSource = MagicGradients.CssGradientSource.Parse(context.Background.SerializedContext)
                    };

                    break;

                case Enumerations.BackgroundKind.Image:
                    var imageModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Common.Templating.Models.Context.ImageContextModel>(context.Background.SerializedContext).ToViewModel();

                    Content = new FFImageLoading.Forms.CachedImage
                    {
                        Source = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildThumbnailUri(imageModel.ThumbnailId)),
                        FadeAnimationEnabled = false,
                        Aspect = Xamarin.Forms.Aspect.AspectFill,
                        CacheType = FFImageLoading.Cache.CacheType.Disk,
                        CacheDuration = System.TimeSpan.MaxValue
                    };

                    break;

                case Enumerations.BackgroundKind.Video:
                    var videoModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Common.Templating.Models.Context.VideoContextModel>(context.Background.SerializedContext).ToViewModel();

                    Content = new FFImageLoading.Forms.CachedImage
                    {
                        Source = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildThumbnailUri(videoModel.ThumbnailId)),
                        FadeAnimationEnabled = false,
                        Aspect = Xamarin.Forms.Aspect.AspectFill,
                        CacheType = FFImageLoading.Cache.CacheType.Disk,
                        CacheDuration = System.TimeSpan.MaxValue
                    };

                    break;
            }
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();
        }
    }
}