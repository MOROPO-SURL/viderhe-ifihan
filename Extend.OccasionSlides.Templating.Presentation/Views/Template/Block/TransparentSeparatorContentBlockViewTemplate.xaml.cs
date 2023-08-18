namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Views.Template.Block
{
    public partial class TransparentSeparatorContentBlockViewTemplate : Xamarin.Forms.DataTemplate, Common.Templating.Presentation.Views.Contract.IRelativeDimensionScalable
    {
        public TransparentSeparatorContentBlockViewTemplate()
        {
            InitializeComponent();
        }

        public double RelativeDeimensionScaleFactor { get; set; }
    }
}