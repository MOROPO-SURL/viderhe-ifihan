using MOROPO.VIDERHE.Extend.Essential.Templating.Models.Context;
using MOROPO.VIDERHE.Support.Presentation.Factories;
using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace MOROPO.VIDERHE.Extend.Essential.Templating.Dashboard.Presentation.Views
{
    public partial class SimpleVideoPlacardThumbnailView : SmartSolucionesCuba.XFToolKit.Mvvm.Views.ContentView
    {
        public SimpleVideoPlacardThumbnailView(PlacardViewModel model)
        {
            InitializeComponent();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<SimpleVideoPlacardContextModel>(model.SerializedContext);

            Image.Source = Xamarin.Forms.ImageSource.FromUri(ThumbnailUriFactory.BuildImageThumbnailUri(context.Video.ThumbnailId));

            BindingContext = model;
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Image.Source = null;
        }
    }
}