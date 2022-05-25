namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Views
{
    public partial class PortraitTranslucentContextualOverlapForImagePlacardThumbnailView : XFToolKit.Mvvm.Views.ContentView
    {
        public PortraitTranslucentContextualOverlapForImagePlacardThumbnailView(Support.Presentation.Models.View.PlacardViewModel model)
        {
            InitializeComponent();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.PortraitTranslucentContextualOverlapForImagePlacardContextModel>(model.SerializedContext);

            ContextedImage.Source = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildThumbnailUri(context.ContextedImage.ThumbnailId));

            BindingContext = model;
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            ContextedImage.Source = null;
        }
    }
}