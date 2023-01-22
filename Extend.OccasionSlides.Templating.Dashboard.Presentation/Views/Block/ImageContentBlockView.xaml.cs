namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Views.Block
{
    public partial class ImageContentBlockView : Xamarin.Forms.ContentView
    {
        private readonly System.EventHandler optionButtonClicked;

        public ImageContentBlockView(Templating.Presentation.Models.View.Block.ImageContentBlockViewModel model, System.EventHandler optionButtonClicked)
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