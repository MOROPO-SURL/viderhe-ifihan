namespace SmartSolucionesCuba.Videre.Terminal.Dashboard.Views
{
    public partial class LandscapeTemplateThumbnailWrapView : Xamarin.Forms.ContentView
    {
        public LandscapeTemplateThumbnailWrapView(Support.Presentation.Models.View.TemplateViewModel model)
        {
            InitializeComponent();

            BindingContext = model;
        }
    }
}