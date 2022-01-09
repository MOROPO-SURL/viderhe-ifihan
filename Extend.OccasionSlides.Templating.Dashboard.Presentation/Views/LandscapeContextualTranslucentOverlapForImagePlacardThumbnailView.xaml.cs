namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Views
{
    public partial class LandscapeContextualTranslucentOverlapForImagePlacardThumbnailView : XFToolKit.Mvvm.Views.ContentView
    {
        public LandscapeContextualTranslucentOverlapForImagePlacardThumbnailView(Support.Presentation.Models.View.PlacardViewModel model, Support.Presentation.Providers.Facade.ICloudServerProviderFacade cloudServerProvider)
        {
            InitializeComponent();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Presentation.Models.Context.LandscapeContextualTranslucentOverlapForImagePlacardContextModel>(model.SerializedContext);

            ContextedImage.Source = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildThumbnailUri(cloudServerProvider, context.ContextedImage.ThumbnailId));

            BindingContext = model;
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            ContextedImage.Source = null;
        }
    }
}