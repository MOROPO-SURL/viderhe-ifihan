using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Enumerations;
using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Models.Context.Placard;
using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Views.Background;
using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Extensions;

namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Dashboard.Presentation.Views
{
    public partial class ClassicOperationsPlacardThumbnailView : SmartSolucionesCuba.XFToolKit.Mvvm.Views.ContentView
    {
        public ClassicOperationsPlacardThumbnailView(Support.Presentation.Models.View.PlacardViewModel model)
        {
            InitializeComponent();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<ClassicOperationsPlacardContextModel>(model.SerializedContext);

            if (context.Background == null)
            {
                BackgroundColor = Xamarin.Forms.Color.FromHex(context.TableBackgroundColor);

                return;
            }

            switch (context.Background.Kind)
            {
                case BackgroundKind.Gradient:
                    var gradientModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Common.Templating.Models.Context.GradientContextModel>(context.Background.SerializedContext);

                    Content = new MagicGradients.GradientView
                    {
                        GradientSource = MagicGradients.CssGradientSource.Parse(gradientModel.Data)
                    };

                    break;

                case BackgroundKind.Image:
                    var imageModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Common.Templating.Models.Context.ImageContextModel>(context.Background.SerializedContext).ToViewModel();

                    Content = new FFImageLoading.Forms.CachedImage
                    {
                        Source = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildImageThumbnailUri(imageModel.ThumbnailId)),
                        FadeAnimationEnabled = false,
                        Aspect = Xamarin.Forms.Aspect.AspectFill,
                        CacheType = FFImageLoading.Cache.CacheType.Disk,
                        CacheDuration = System.TimeSpan.MaxValue
                    };

                    break;

                case BackgroundKind.Video:
                    var videoModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Common.Templating.Models.Context.VideoContextModel>(context.Background.SerializedContext).ToViewModel();

                    Content = new FFImageLoading.Forms.CachedImage
                    {
                        Source = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildImageThumbnailUri(videoModel.ThumbnailId)),
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

            if (Content is ImageBackgroundView)
            {
                (Content as ImageBackgroundView).Source = null;
            }
            else if (Content is GradientBackgroundView)
            {
                (Content as GradientBackgroundView).GradientSource = null;
            }
        }
    }
}