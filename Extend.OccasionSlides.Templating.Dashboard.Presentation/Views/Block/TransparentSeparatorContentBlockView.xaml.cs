namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Views.Block
{
    public partial class TransparentSeparatorContentBlockView : Xamarin.Forms.ContentView
    {
        private readonly System.EventHandler optionButtonClicked;

        public TransparentSeparatorContentBlockView(Templating.Presentation.Models.View.Block.TransparentSeparatorContentBlockViewModel model, System.EventHandler optionButtonClicked)
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