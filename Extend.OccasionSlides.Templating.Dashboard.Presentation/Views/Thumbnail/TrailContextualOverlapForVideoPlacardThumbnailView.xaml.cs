using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Models.Context.Placard;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Dashboard.Presentation.Views.Thumbnail
{
    public partial class TrailContextualOverlapForVideoPlacardThumbnailView : SmartSolucionesCuba.XFToolKit.Mvvm.Views.ContentView
    {
        public TrailContextualOverlapForVideoPlacardThumbnailView(Support.Presentation.Models.View.PlacardViewModel model)
        {
            InitializeComponent();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<TrailContextualOverlapForVideoPlacardContextModel>(model.SerializedContext, new Newtonsoft.Json.JsonSerializerSettings
            {
                TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto
            });

            ContextedVideoThumbnailImage.Source = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildImageThumbnailUri(context.ContextedVideo.Id));

            BindingContext = model;
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            ContextedVideoThumbnailImage.Source = null;
        }
    }
}