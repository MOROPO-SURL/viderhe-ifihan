using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Models.Context;

namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Views
{
    public partial class InfinityVideoPlacardThumbnailView : SmartSolucionesCuba.XFToolKit.Mvvm.Views.ContentView
    {
        public InfinityVideoPlacardThumbnailView(Support.Presentation.Models.View.PlacardViewModel model)
        {
            InitializeComponent();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<InfinityVideoPlacardContextModel>(model.SerializedContext);

            Image.Source = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildVideoThumbnailUri(context.Video.Id));

            BindingContext = model;
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Image.Source = null;
        }
    }
}