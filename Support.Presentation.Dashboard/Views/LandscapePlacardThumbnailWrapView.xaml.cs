using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace MOROPO.VIDERHE.Support.Presentation.Dashboard.Views
{
    public partial class LandscapePlacardThumbnailWrapView : Xamarin.Forms.ContentView
    {
        public LandscapePlacardThumbnailWrapView(PlacardViewModel model)
        {
            InitializeComponent();

            BindingContext = model;
        }
    }
}