namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Models.View.Placard
{
    public class TrailContextualOverlapForVideoPlacardViewModel : Common.Templating.Presentation.Models.View.AbstractPlacardViewModel, Contract.IContextualOverlapSKPathTransformablePlacardViewModel
    {
        public Block.Contract.AbstractContentBlockViewModel[] ContentBlocks { get; set; }

        public Enumerations.OverlapAlignment OverlapAlignment { get; set; }

        public Enumerations.OverlapShapeKind OverlapShapeKind { get; set; }

        public Enumerations.OverlapSize OverlapSize { get; set; }

        public Xamarin.Forms.Color OverlapBackgroundColor { get; set; }

        public Enumerations.OverlapTrailMode OverlapTrailMode { get; set; }

        public XFToolKit.Presentation.Sources.Video.VideoSource ContextedVideoSource { get; set; }

        public bool IsContextedVideoFramed { get; set; }

        public bool ContextedVideoCenteredAtPresentation { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            ContextedVideoSource = null;
        }
    }
}
