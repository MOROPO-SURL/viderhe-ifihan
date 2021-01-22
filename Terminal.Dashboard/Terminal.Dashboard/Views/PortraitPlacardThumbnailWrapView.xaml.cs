namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Views
{
    public partial class PortraitPlacardThumbnailWrapView : Xamarin.Forms.ContentView
    {
        public PortraitPlacardThumbnailWrapView(Support.Presentation.Models.View.PlacardViewModel model)
        {
            InitializeComponent();

            BindingContext = model;
        }
    }
}