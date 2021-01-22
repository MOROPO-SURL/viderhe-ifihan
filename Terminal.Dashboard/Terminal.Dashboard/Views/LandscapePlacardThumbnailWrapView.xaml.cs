namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Views
{
    public partial class LandscapePlacardThumbnailWrapView : Xamarin.Forms.ContentView
    {
        public LandscapePlacardThumbnailWrapView(Support.Presentation.Models.View.PlacardViewModel model)
        {
            InitializeComponent();

            BindingContext = model;
        }
    }
}