namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Models.Context.Placard
{
    public class FlatContextualOverlapForVideoPlacardContextModel : Common.Templating.Models.Context.AbstractScreenTimedPlacardContextModel
    {
        public Block.Contract.AbstractContentBlockContextModel[] ContentBlocks { get; set; }

        public Enumerations.OverlapAlignment OverlapAlignment { get; set; }

        public Enumerations.OverlapShapeKind OverlapShapeKind { get; set; }

        public Enumerations.OverlapSize OverlapSize { get; set; }

        public string OverlapBackgroundColor { get; set; }

        public bool UseOverlapShadown { get; set; }

        public Common.Templating.Models.Context.VideoContextModel ContextedVideo { get; set; }

        public bool ContextedVideoCenteredAtPresentation { get; set; }
    }
}
