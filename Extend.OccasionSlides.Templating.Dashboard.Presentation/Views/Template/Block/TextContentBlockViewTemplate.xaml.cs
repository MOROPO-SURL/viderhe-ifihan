namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Views.Template.Block
{
    public partial class TextContentBlockViewTemplate : Xamarin.Forms.DataTemplate
    {
        private readonly System.EventHandler optionButtonClicked;

        public TextContentBlockViewTemplate(System.EventHandler optionButtonClicked)
        {
            InitializeComponent();

            this.optionButtonClicked = optionButtonClicked;
        }

        private void OptionsButton_Clicked(object sender, System.EventArgs e)
        {
            optionButtonClicked?.Invoke(sender, e);
        }
    }
}