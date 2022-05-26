namespace SmartSolucionesCuba.Viderhe.Extend.CPCC.Templating.Dashboard.Presentation.Views
{
    public partial class PortraitPosterVideoEventPromotionEventPlacardThumbnailView : XFToolKit.Mvvm.Views.ContentView
    {
        public PortraitPosterVideoEventPromotionEventPlacardThumbnailView(Support.Presentation.Models.View.PlacardViewModel model)
        {
            InitializeComponent();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.PortraitPosterVideoEventPromotionPlacardContextModel>(model.SerializedContext);

            EventVideoThumnailImage.Source = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildThumbnailUri(context.Video.ThumbnailId));

            EventPosterImage.Source = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildThumbnailUri(context.Poster.ThumbnailId));

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