namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Views.Block
{
    public partial class GlyphContentBlockView : Xamarin.Forms.ContentView, Common.Templating.Presentation.Views.Facade.IRelativeSizeScalableViewFacade
    {
        public GlyphContentBlockView(double relativeSizeScaleFactor)
        {
            RelativeSizeScaleFactor = relativeSizeScaleFactor;

            InitializeComponent();
        }

        #region IRelativeSizeScalableViewFacade implementation

        public double RelativeSizeScaleFactor { get; set; } = 1.0d;

        #endregion
    }
}