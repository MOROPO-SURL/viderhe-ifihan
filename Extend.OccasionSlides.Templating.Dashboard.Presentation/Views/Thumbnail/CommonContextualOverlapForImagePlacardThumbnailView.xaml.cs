using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Models.Context.Placard;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Dashboard.Presentation.Views.Thumbnail
{
    public partial class CommonContextualOverlapForImagePlacardThumbnailView : SmartSolucionesCuba.XFToolKit.Mvvm.Views.ContentView
    {
        public CommonContextualOverlapForImagePlacardThumbnailView(Support.Presentation.Models.View.PlacardViewModel model)
        {
            InitializeComponent();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<TranslucentContextualOverlapForImagePlacardContextModel>(model.SerializedContext, new Newtonsoft.Json.JsonSerializerSettings
            {
                TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto
            });

            ContextedImage.Source = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildImageThumbnailUri(context.ContextedImage.Id));

            BindingContext = model;
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            ContextedImage.Source = null;
        }
    }
}