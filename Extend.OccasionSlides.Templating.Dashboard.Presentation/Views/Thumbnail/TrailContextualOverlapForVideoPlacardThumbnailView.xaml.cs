using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Models.Context.Placard;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Views.Thumbnail
{
    public partial class TrailContextualOverlapForVideoPlacardThumbnailView : XFToolKit.Mvvm.Views.ContentView
    {
        public TrailContextualOverlapForVideoPlacardThumbnailView(Support.Presentation.Models.View.PlacardViewModel model)
        {
            InitializeComponent();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<TrailContextualOverlapForVideoPlacardContextModel>(model.SerializedContext, new Newtonsoft.Json.JsonSerializerSettings
            {
                TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto
            });

            ContextedVideoThumbnailImage.Source = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildThumbnailUri(context.ContextedVideo.ThumbnailId));

            BindingContext = model;
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            ContextedVideoThumbnailImage.Source = null;
        }
    }
}