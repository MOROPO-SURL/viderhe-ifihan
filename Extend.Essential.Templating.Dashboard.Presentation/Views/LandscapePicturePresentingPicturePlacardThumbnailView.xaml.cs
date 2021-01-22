namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Dashboard.Presentation.Views
{
    public partial class LandscapePicturePresentingPicturePlacardThumbnailView : XFToolKit.Mvvm.Views.ContentView
    {
        public LandscapePicturePresentingPicturePlacardThumbnailView(Support.Presentation.Models.View.PlacardViewModel model, Support.Presentation.Providers.Facade.ICloudServerProviderFacade cloudServerProvider)
        {
            InitializeComponent();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Presentation.Models.Context.LandscapePicturePresentingPicturePlacardContextModel>(model.SerializedContext);

            PresentedImage.Source = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildThumbnailUri(cloudServerProvider, context.PresentedImage.ThumbnailId));

            PresenterImage.Source = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildThumbnailUri(cloudServerProvider, context.PresenterImage.ThumbnailId));
            PresenterImage.HorizontalOptions = context.PresenterSide == Templating.Presentation.Enumerations.LandscapePresentationSide.Left ? Xamarin.Forms.LayoutOptions.Start : Xamarin.Forms.LayoutOptions.End;

            BindingContext = model;
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            PresentedImage = null;
            PresenterImage = null;
        }
    }
}