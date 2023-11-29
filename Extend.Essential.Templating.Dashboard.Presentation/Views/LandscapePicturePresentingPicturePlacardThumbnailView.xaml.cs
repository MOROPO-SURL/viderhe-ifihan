using MOROPO.VIDERHE.Extend.Essential.Templating.Enumerations;
using MOROPO.VIDERHE.Extend.Essential.Templating.Models.Context;
using MOROPO.VIDERHE.Support.Presentation.Factories;
using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace MOROPO.VIDERHE.Extend.Essential.Templating.Dashboard.Presentation.Views
{
    public partial class LandscapePicturePresentingPicturePlacardThumbnailView : SmartSolucionesCuba.XFToolKit.Mvvm.Views.ContentView
    {
        public LandscapePicturePresentingPicturePlacardThumbnailView(PlacardViewModel model)
        {
            InitializeComponent();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<LandscapePicturePresentingPicturePlacardContextModel>(model.SerializedContext);

            PresentedImage.Source = Xamarin.Forms.ImageSource.FromUri(ThumbnailUriFactory.BuildThumbnailUri(context.PresentedImage.ThumbnailId));

            PresenterImage.Source = Xamarin.Forms.ImageSource.FromUri(ThumbnailUriFactory.BuildThumbnailUri(context.PresenterImage.ThumbnailId));
            PresenterImage.HorizontalOptions = context.PresenterSide == LandscapePresentationSide.Left ? Xamarin.Forms.LayoutOptions.Start : Xamarin.Forms.LayoutOptions.End;

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