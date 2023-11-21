namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Templating.Dashboard.Presentation.Views
{
    public partial class ClassicOperationsPlacardThumbnailView : XFToolKit.Mvvm.Views.ContentView
    {
        public ClassicOperationsPlacardThumbnailView(Support.Presentation.Models.View.PlacardViewModel model)
        {
            InitializeComponent();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.Placard.ClassicOperationsPlacardContextModel>(model.SerializedContext);

            BackgroundColor = Xamarin.Forms.Color.FromHex(context.BackgroundColor);
        }
    }
}