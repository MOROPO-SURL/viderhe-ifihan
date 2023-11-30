using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Views
{
    public partial class PortraitTemplateThumbnailWrapView : Xamarin.Forms.ContentView
    {
        public PortraitTemplateThumbnailWrapView(TemplateViewModel model)
        {
            InitializeComponent();

            BindingContext = model;
        }
    }
}