namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Views.Block
{
    public partial class ImageContentBlockView : FFImageLoading.Forms.CachedImage, Common.Templating.Presentation.Views.Facade.IRelativeSizeScalableViewFacade
    {
        public ImageContentBlockView()
        {
            InitializeComponent();
        }

        #region IRelativeSizeScalableViewFacade implementation

        public double RelativeSizeScaleFactor { get; set; } = 1.0d;

        #endregion
    }
}