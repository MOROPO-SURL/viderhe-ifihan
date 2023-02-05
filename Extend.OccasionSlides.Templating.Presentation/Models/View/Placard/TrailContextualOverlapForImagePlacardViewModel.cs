namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Models.View.Placard
{
    public class TrailContextualOverlapForImagePlacardViewModel : Common.Templating.Presentation.Models.View.AbstractScreenTimedPlacardViewModel, Contract.IContextualOverlapSKPathTransformablePlacardViewModel
    {
        public Block.Contract.AbstractContentBlockViewModel[] ContentBlocks { get; set; }

        public Enumerations.OverlapAlignment OverlapAlignment { get; set; }

        public Enumerations.OverlapShapeKind OverlapShapeKind { get; set; }

        public Enumerations.OverlapSize OverlapSize { get; set; }

        public Xamarin.Forms.Color OverlapBackgroundColor { get; set; }

        public Enumerations.OverlapTrailMode OverlapTrailMode { get; set; }

        public Xamarin.Forms.ImageSource ContextedImageSource { get; set; }

        public Xamarin.Forms.ImageSource ContextedImageThumbnailSource { get; set; }

        public bool ContextedImageZoomingEnabled { get; set; }

        public bool ContextedImageCenteredAtPresentation { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            ContextedImageSource = null;
        }
    }
}
