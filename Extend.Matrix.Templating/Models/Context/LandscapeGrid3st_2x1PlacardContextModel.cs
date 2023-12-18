namespace MOROPO.VIDERHE.Extend.Matrix.Templating.Models.Context
{
    public class LandscapeGrid3st_2x1PlacardContextModel : Common.Templating.Models.Context.AbstractPlacardContextModel
    {
        public object[] OneOfTwoTargetPlacards { get; set; }

        public bool IsOneOfTwoTargetPlacardsScalable { get; set; }

        public object[] TwoOfTwoSplitOneOfTwoTargetPlacards { get; set; }

        public object[] TwoOfTwoSplitTwoOfTwoTargetPlacards { get; set; }
    }
}
