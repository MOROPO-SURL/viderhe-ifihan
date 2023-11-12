namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Templating.Dashboard.Presentation.Views
{
    public partial class ClassicDeparturesPlacardThumbnailView : XFToolKit.Mvvm.Views.ContentView
    {
        public ClassicDeparturesPlacardThumbnailView(Support.Presentation.Models.View.PlacardViewModel model)
        {
            InitializeComponent();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.Placard.ClassicDeparturesPlacardContextModel>(model.SerializedContext);

            BackgroundColor = Xamarin.Forms.Color.FromHex(context.BackgroundColor);
        }
    }
}