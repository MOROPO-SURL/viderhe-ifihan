using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Views
{
    public partial class LandscapeTemplateThumbnailWrapView : Xamarin.Forms.ContentView
    {
        public LandscapeTemplateThumbnailWrapView(TemplateViewModel model)
        {
            InitializeComponent();

            BindingContext = model;
        }
    }
}