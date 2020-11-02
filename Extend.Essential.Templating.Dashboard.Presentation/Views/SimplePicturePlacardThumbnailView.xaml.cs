namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Dashboard.Presentation.Views
{
    public partial class SimplePicturePlacardThumbnailView : XFToolKit.Mvvm.Views.ContentView
    {
        public SimplePicturePlacardThumbnailView(Support.Presentation.Models.View.PlacardViewModel model, Support.Presentation.Providers.Facade.ICloudServerProviderFacade cloudServerProvider)
        {
            InitializeComponent();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Presentation.Models.Context.SimplePicturePlacardContextModel>(model.SerializedContext);

            Image.Source = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildThumbnailUri(cloudServerProvider, context.Image.ThumbnailId));
            Image.Aspect = context.Aspect;

            BindingContext = model;
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Image.Source = null;
        }
    }
}