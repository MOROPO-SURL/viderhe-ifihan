namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Views.Block
{
    public partial class TextContentBlockView : Xamarin.Forms.ContentView, Common.Templating.Presentation.Views.Facade.IRelativeSizeScalableViewFacade
    {
        public TextContentBlockView(double relativeSizeScaleFactor)
        {
            RelativeSizeScaleFactor = relativeSizeScaleFactor;

            InitializeComponent();
        }

        #region IRelativeSizeScalableViewFacade implementation

        public double RelativeSizeScaleFactor { get; set; } = 1.0d;

        #endregion
    }
}