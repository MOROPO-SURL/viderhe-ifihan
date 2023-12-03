using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Enumerations;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Models.View.Placard
{
    public class FlatContextualOverlapForImagePlacardViewModel : Common.Templating.Presentation.Models.View.AbstractScreenTimedPlacardViewModel, Contract.IContextualOverlapSKPathTransformablePlacardViewModel
    {
        public Block.Contract.AbstractContentBlockViewModel[] ContentBlocks { get; set; }

        public OverlapAlignment OverlapAlignment { get; set; }

        public OverlapShapeKind OverlapShapeKind { get; set; }

        public OverlapSize OverlapSize { get; set; }

        public Xamarin.Forms.Color OverlapBackgroundColor { get; set; }

        public bool UseOverlapShadown { get; set; }

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
