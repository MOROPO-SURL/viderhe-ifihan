using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Models.Context;

namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Views
{
    public partial class CornerTileVideoPresentingVideoPlacardThumbnailView : SmartSolucionesCuba.XFToolKit.Mvvm.Views.ContentView
    {
        public CornerTileVideoPresentingVideoPlacardThumbnailView(Support.Presentation.Models.View.PlacardViewModel model)
        {
            InitializeComponent();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<CornerTileVideoPresentingVideoPlacardContextModel>(model.SerializedContext);

            Image.Source = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildVideoThumbnailUri(context.PresentedVideo.Id));

            BindingContext = model;
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Image.Source = null;
        }
    }
}