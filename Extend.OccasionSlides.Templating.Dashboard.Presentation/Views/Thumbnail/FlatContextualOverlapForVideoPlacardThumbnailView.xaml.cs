using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Models.Context.Placard;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Dashboard.Presentation.Views.Thumbnail
{
    public partial class FlatContextualOverlapForVideoPlacardThumbnailView : SmartSolucionesCuba.XFToolKit.Mvvm.Views.ContentView
    {
        public FlatContextualOverlapForVideoPlacardThumbnailView(Support.Presentation.Models.View.PlacardViewModel model)
        {
            InitializeComponent();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<FlatContextualOverlapForVideoPlacardContextModel>(model.SerializedContext, new Newtonsoft.Json.JsonSerializerSettings
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