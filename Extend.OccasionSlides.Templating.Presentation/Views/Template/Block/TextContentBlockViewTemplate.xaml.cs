namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Views.Template.Block
{
    public partial class TextContentBlockViewTemplate : Xamarin.Forms.DataTemplate, Common.Templating.Presentation.Views.Contract.IRelativeDimensionScalable
    {
        public TextContentBlockViewTemplate()
        {
            InitializeComponent();
        }

        public double RelativeDeimensionScaleFactor { get; set; }
    }
}