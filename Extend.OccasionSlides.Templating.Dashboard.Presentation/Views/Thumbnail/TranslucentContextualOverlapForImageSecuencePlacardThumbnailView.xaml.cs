using MOROPO.VIDERHE.Extend.Essential.Templating.Presentation.Extensions;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Models.Context.Placard;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Dashboard.Presentation.Views.Thumbnail
{
    public partial class TranslucentContextualOverlapForImageSecuencePlacardThumbnailView : SmartSolucionesCuba.XFToolKit.Mvvm.Views.ContentView
    {
        public TranslucentContextualOverlapForImageSecuencePlacardThumbnailView(Support.Presentation.Models.View.PlacardViewModel model)
        {
            InitializeComponent();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<TranslucentContextualOverlapForImageSecuencePlacardContextModel>(model.SerializedContext, new Newtonsoft.Json.JsonSerializerSettings
            {
                TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto
            });

            var iterationCount = context.PresentedPictureSlideSecuence.Slides.Length;

            if (iterationCount > 4)
            {
                iterationCount = 4;
            }

            for (int i = 0; i < iterationCount; i++)
            {
                var slide = context.PresentedPictureSlideSecuence.Slides[i];

                var iterationImage = new FFImageLoading.Forms.CachedImage
                {
                    Source = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildImageThumbnailUri(slide.Image.Id)),
                    Aspect = slide.LayoutMode.ToXamarinFormsAspect(),
                    CacheType = FFImageLoading.Cache.CacheType.Disk,
                    CacheDuration = System.TimeSpan.MaxValue
                };

                switch (i)
                {
                    case 0:
                        Xamarin.Forms.Grid.SetColumn(iterationImage, 0);
                        Xamarin.Forms.Grid.SetRow(iterationImage, 0);

                        break;

                    case 1:
                        Xamarin.Forms.Grid.SetColumn(iterationImage, 1);
                        Xamarin.Forms.Grid.SetRow(iterationImage, 0);

                        break;

                    case 2:
                        Xamarin.Forms.Grid.SetColumn(iterationImage, 0);
                        Xamarin.Forms.Grid.SetRow(iterationImage, 1);

                        break;

                    case 3:
                        Xamarin.Forms.Grid.SetColumn(iterationImage, 1);
                        Xamarin.Forms.Grid.SetRow(iterationImage, 1);

                        break;
                }

                Wrapper.Children.Insert(i, iterationImage);
            }

            BindingContext = model;
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            foreach (var item in Wrapper.Children)
            {
                if (item is FFImageLoading.Forms.CachedImage)
                {
                    (item as FFImageLoading.Forms.CachedImage).Source = null;
                }
            }
        }
    }
}