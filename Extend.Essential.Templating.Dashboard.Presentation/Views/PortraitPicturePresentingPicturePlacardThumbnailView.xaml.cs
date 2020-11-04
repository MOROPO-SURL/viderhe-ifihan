namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Dashboard.Presentation.Views
{
    public partial class PortraitPicturePresentingPicturePlacardThumbnailView : XFToolKit.Mvvm.Views.ContentView
    {
        public PortraitPicturePresentingPicturePlacardThumbnailView(Support.Presentation.Models.View.PlacardViewModel model, Support.Presentation.Providers.Facade.ICloudServerProviderFacade cloudServerProvider)
        {
            InitializeComponent();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Presentation.Models.Context.PortraitPicturePresentingPicturePlacardContextModel>(model.SerializedContext);

            PresentedImage.Source = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildThumbnailUri(cloudServerProvider, context.PresentedImage.ThumbnailId));

            PresenterImage.Source = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildThumbnailUri(cloudServerProvider, context.PresenterImage.ThumbnailId));
            PresenterImage.VerticalOptions = context.PresenterSide == Templating.Presentation.Enumerations.PortraitPresentationSide.Top ? Xamarin.Forms.LayoutOptions.Start : Xamarin.Forms.LayoutOptions.End;

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