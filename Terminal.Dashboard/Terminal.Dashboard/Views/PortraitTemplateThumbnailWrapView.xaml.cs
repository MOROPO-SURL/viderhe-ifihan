namespace SmartSolucionesCuba.Videre.Terminal.Dashboard.Views
{
    public partial class PortraitTemplateThumbnailWrapView : Xamarin.Forms.ContentView
    {
        public PortraitTemplateThumbnailWrapView(Support.Presentation.Models.View.TemplateViewModel model)
        {
            InitializeComponent();

            BindingContext = model;
        }
    }
}