namespace MOROPO.VIDERHE.Extend.Matrix.Templating.Presentation.Models.View
{
    public class LandscapeGrid2x1PlacardViewModel : Common.Templating.Presentation.Models.View.AbstractPlacardViewModel
    {
        public Support.Presentation.Models.View.PlacardViewModel[] OneOfTwoTargetPlacards { get; set; }

        public bool IsOneOfTwoTargetPlacardsScalable { get; set; }

        public Support.Presentation.Models.View.PlacardViewModel[] TwoOfTwoTargetPlacards { get; set; }

        public bool IsTwoOfTwoTargetPlacardsScalable { get; set; }
    }
}
