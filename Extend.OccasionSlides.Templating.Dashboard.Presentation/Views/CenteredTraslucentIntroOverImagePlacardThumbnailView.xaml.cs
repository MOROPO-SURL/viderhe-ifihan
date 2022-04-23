namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Views
{
    public partial class CenteredTraslucentIntroOverImagePlacardThumbnailView : XFToolKit.Mvvm.Views.ContentView
    {
        public CenteredTraslucentIntroOverImagePlacardThumbnailView(Support.Presentation.Models.View.PlacardViewModel model)
        {
            InitializeComponent();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Presentation.Models.Context.CenteredTraslucentIntroOverImagePlacardContextModel>(model.SerializedContext);

            BackgroundImage.Source = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildThumbnailUri(context.BackgroundImage.ThumbnailId));

            BindingContext = model;
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            BackgroundImage.Source = null;
        }
    }
}