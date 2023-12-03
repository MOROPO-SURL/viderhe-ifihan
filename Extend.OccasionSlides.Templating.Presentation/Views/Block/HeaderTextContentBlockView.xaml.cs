namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Views.Block
{
    public partial class HeaderTextContentBlockView : Xamarin.Forms.StackLayout, Common.Templating.Presentation.Views.Facade.IRelativeSizeScalableViewFacade
    {
        public HeaderTextContentBlockView(double relativeSizeScaleFactor)
        {
            RelativeSizeScaleFactor = relativeSizeScaleFactor;

            InitializeComponent();
        }

        #region IRelativeSizeScalableViewFacade implementation

        public double RelativeSizeScaleFactor { get; set; } = 1.0d;

        #endregion
    }
}