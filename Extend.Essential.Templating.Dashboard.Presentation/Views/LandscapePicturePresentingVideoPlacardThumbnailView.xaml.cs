using MOROPO.VIDERHE.Extend.Essential.Templating.Enumerations;
using MOROPO.VIDERHE.Extend.Essential.Templating.Models.Context;
using MOROPO.VIDERHE.Support.Presentation.Factories;
using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace MOROPO.VIDERHE.Extend.Essential.Templating.Dashboard.Presentation.Views
{
    public partial class LandscapePicturePresentingVideoPlacardThumbnailView : SmartSolucionesCuba.XFToolKit.Mvvm.Views.ContentView
    {
        public LandscapePicturePresentingVideoPlacardThumbnailView(PlacardViewModel model)
        {
            InitializeComponent();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<LandscapePicturePresentingVideoPlacardContextModel>(model.SerializedContext);

            PresentedVideoThumnailImage.Source = Xamarin.Forms.ImageSource.FromUri(ThumbnailUriFactory.BuildImageThumbnailUri(context.PresentedVideo.ThumbnailId));

            PresenterImage.Source = Xamarin.Forms.ImageSource.FromUri(ThumbnailUriFactory.BuildImageThumbnailUri(context.PresenterImage.ThumbnailId));
            PresenterImage.HorizontalOptions = context.PresenterSide == LandscapePresentationSide.Left ? Xamarin.Forms.LayoutOptions.Start : Xamarin.Forms.LayoutOptions.End;

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