using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Enumerations;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Models.View.Placard
{
    public class FlatContextualOverlapForVideoPlacardViewModel : Common.Templating.Presentation.Models.View.AbstractPlacardViewModel, Contract.IContextualOverlapSKPathTransformablePlacardViewModel
    {
        public Block.Contract.AbstractContentBlockViewModel[] ContentBlocks { get; set; }

        public OverlapAlignment OverlapAlignment { get; set; }

        public OverlapShapeKind OverlapShapeKind { get; set; }

        public OverlapSize OverlapSize { get; set; }

        public Xamarin.Forms.Color OverlapBackgroundColor { get; set; }

        public bool UseOverlapShadown { get; set; }

        public SmartSolucionesCuba.XFToolKit.Presentation.Sources.Video.VideoSource ContextedVideoSource { get; set; }

        public bool ContextedVideoCenteredAtPresentation { get; set; }

        public bool ContextedVideoMuted { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            ContextedVideoSource = null;
        }
    }
}
