using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Models.Context;

namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Views
{
    public partial class LandscapePennantTrainPlacardThumbnailView : SmartSolucionesCuba.XFToolKit.Mvvm.Views.ContentView
    {
        public LandscapePennantTrainPlacardThumbnailView(Support.Presentation.Models.View.PlacardViewModel model)
        {
            InitializeComponent();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<LandscapePennantPlacardContextModel>(model.SerializedContext);

            Image.Source = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildImageThumbnailUri(context.ContextedImage.Id));

            BindingContext = model;
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Image.Source = null;
        }
    }
}