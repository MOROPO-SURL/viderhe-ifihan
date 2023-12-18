namespace MOROPO.VIDERHE.Extend.Matrix.Templating.Presentation.Models.View
{
    public class LandscapeGrid3st_2x1PlacardViewModel : Common.Templating.Presentation.Models.View.AbstractPlacardViewModel
    {
        public Support.Presentation.Models.View.PlacardViewModel[] OneOfTwoTargetPlacards { get; set; }

        public bool IsOneOfTwoTargetPlacardsScalable { get; set; }

        public Support.Presentation.Models.View.PlacardViewModel[] TwoOfTwoSplitOneOfTwoTargetPlacards { get; set; }

        public Support.Presentation.Models.View.PlacardViewModel[] TwoOfTwoSplitTwoOfTwoTargetPlacards { get; set; }
    }
}
