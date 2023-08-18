namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Views.Template.Block
{
    public partial class ImageContentBlockViewTemplate : Xamarin.Forms.DataTemplate, Common.Templating.Presentation.Views.Contract.IRelativeDimensionScalable
    {
        public ImageContentBlockViewTemplate()
        {
            InitializeComponent();
        }

        public double RelativeDeimensionScaleFactor { get; set; }
    }
}