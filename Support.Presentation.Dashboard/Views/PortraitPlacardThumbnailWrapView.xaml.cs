using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace MOROPO.VIDERHE.Support.Presentation.Dashboard.Views
{
    public partial class PortraitPlacardThumbnailWrapView : Xamarin.Forms.ContentView
    {
        public PortraitPlacardThumbnailWrapView(PlacardViewModel model)
        {
            InitializeComponent();

            BindingContext = model;
        }
    }
}