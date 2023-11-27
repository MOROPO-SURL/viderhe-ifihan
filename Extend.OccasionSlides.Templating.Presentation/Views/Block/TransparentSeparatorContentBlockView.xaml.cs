namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Views.Block
{
    public partial class TransparentSeparatorContentBlockView : Xamarin.Forms.BoxView, Common.Templating.Presentation.Views.Facade.IRelativeSizeScalableViewFacade
    {
        public TransparentSeparatorContentBlockView(double relativeSizeScaleFactor)
        {
            RelativeSizeScaleFactor = relativeSizeScaleFactor;

            InitializeComponent();
        }

        #region IRelativeSizeScalableViewFacade implementation

        public double RelativeSizeScaleFactor { get; set; } = 1.0d;

        #endregion
    }
}