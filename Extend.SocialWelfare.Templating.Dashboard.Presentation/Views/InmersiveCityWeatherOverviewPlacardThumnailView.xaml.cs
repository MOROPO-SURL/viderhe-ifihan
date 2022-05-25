namespace SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Dashboard.Presentation.Views
{
    public partial class InmersiveCityWeatherOverviewPlacardThumnailView : XFToolKit.Mvvm.Views.ContentView
    {
        public InmersiveCityWeatherOverviewPlacardThumnailView(Support.Presentation.Models.View.PlacardViewModel model)
        {
            InitializeComponent();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.InmersiveCityWeatherOverviewContextModel>(model.SerializedContext);

            BackgroundImage.Source = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildThumbnailUri(context.BackgroundCityImage.ThumbnailId));

            BindingContext = model;
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            BackgroundImage.Source = null;
        }
    }
}