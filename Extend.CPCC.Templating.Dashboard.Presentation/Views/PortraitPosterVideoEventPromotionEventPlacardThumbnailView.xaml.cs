using MOROPO.VIDERHE.Extend.CPCC.Templating.Models.Context;

namespace MOROPO.VIDERHE.Extend.CPCC.Templating.Dashboard.Presentation.Views
{
    public partial class PortraitPosterVideoEventPromotionEventPlacardThumbnailView : SmartSolucionesCuba.XFToolKit.Mvvm.Views.ContentView
    {
        public PortraitPosterVideoEventPromotionEventPlacardThumbnailView(Support.Presentation.Models.View.PlacardViewModel model)
        {
            InitializeComponent();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<PortraitPosterVideoEventPromotionPlacardContextModel>(model.SerializedContext);

            EventVideoThumnailImage.Source = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildVideoThumbnailUri(context.Video.ThumbnailId));

            EventPosterImage.Source = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildImageThumbnailUri(context.Poster.ThumbnailId));

            BindingContext = model;
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            EventVideoThumnailImage.Source = null;
            EventPosterImage.Source = null;
        }
    }
}