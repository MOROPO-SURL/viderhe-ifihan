using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Templating.Dashboard.Presentation.Views
{
    public partial class ClassicOperationsPlacardThumbnailView : XFToolKit.Mvvm.Views.ContentView
    {
        public ClassicOperationsPlacardThumbnailView(Support.Presentation.Models.View.PlacardViewModel model)
        {
            InitializeComponent();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.Placard.ClassicOperationsPlacardContextModel>(model.SerializedContext);

            if (context.Background == null)
            {
                BackgroundColor = Xamarin.Forms.Color.FromHex(context.TableBackgroundColor);

                return;
            }

            switch (context.Background.Kind)
            {
                case Enumerations.BackgroundKind.Gradient:
                    var gradientModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Common.Templating.Models.Context.GradientContextModel>(context.Background.SerializedContext);

                    Content = new MagicGradients.GradientView
                    {
                        GradientSource = MagicGradients.CssGradientSource.Parse(gradientModel.Data)
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

            if (Content is Templating.Presentation.Views.Background.ImageBackgroundView)
            {
                (Content as Templating.Presentation.Views.Background.ImageBackgroundView).Source = null;
            }
            else if (Content is Templating.Presentation.Views.Background.GradientBackgroundView)
            {
                (Content as Templating.Presentation.Views.Background.GradientBackgroundView).GradientSource = null;
            }
        }
    }
}