namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Dashboard.Presentation.Views
{
    public partial class LandscapePicturePresentingVideoPlacardThumbnailView : XFToolKit.Mvvm.Views.ContentView
    {
        public LandscapePicturePresentingVideoPlacardThumbnailView(Support.Presentation.Models.View.PlacardViewModel model, Support.Presentation.Providers.Facade.ICloudServerProviderFacade cloudServerProvider)
        {
            InitializeComponent();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Presentation.Models.Context.LandscapePicturePresentingVideoPlacardContextModel>(model.SerializedContext);

            PresentedVideoThumnailImage.Source = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildThumbnailUri(cloudServerProvider, context.PresentedVideo.ThumbnailId));

            PresenterImage.Source = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildThumbnailUri(cloudServerProvider, context.PresenterImage.ThumbnailId));
            PresenterImage.HorizontalOptions = context.PresenterSide == Templating.Presentation.Enumerations.LandscapePresentationSide.Left ? Xamarin.Forms.LayoutOptions.Start : Xamarin.Forms.LayoutOptions.End;

            BindingContext = model;
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            PresentedVideoThumnailImage = null;
            PresenterImage = null;
        }
    }
}