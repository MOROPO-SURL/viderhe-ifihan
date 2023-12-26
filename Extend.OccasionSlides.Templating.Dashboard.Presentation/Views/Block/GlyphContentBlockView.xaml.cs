namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Dashboard.Presentation.Views.Block
{
    public partial class GlyphContentBlockView : Xamarin.Forms.ContentView
    {
        private readonly System.EventHandler optionButtonClicked;

        public GlyphContentBlockView(Templating.Presentation.Models.View.Block.GlyphContentBlockViewModel model, System.EventHandler optionButtonClicked)
        {
            InitializeComponent();

            this.optionButtonClicked = optionButtonClicked;

            BindingContext = model;
        }

        private void OptionsButton_Clicked(object sender, System.EventArgs e)
        {
            optionButtonClicked?.Invoke(sender, e);
        }
    }
}