namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Views.Template.Block
{
    public partial class HeaderTextContentBlockViewTemplate : Xamarin.Forms.DataTemplate, Common.Templating.Presentation.Views.Contract.IRelativeDimensionScalable
    {
        public HeaderTextContentBlockViewTemplate()
        {
            InitializeComponent();
        }

        public double RelativeDeimensionScaleFactor { get; set; }
    }
}