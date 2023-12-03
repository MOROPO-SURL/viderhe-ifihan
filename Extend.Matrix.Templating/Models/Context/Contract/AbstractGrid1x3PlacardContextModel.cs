namespace MOROPO.VIDERHE.Extend.Matrix.Templating.Models.Context.Contract
{
    public abstract class AbstractGrid1x3PlacardContextModel : Common.Templating.Models.Context.AbstractPlacardContextModel
    {
        public object[] OneOfThreeTargetPlacards { get; set; }

        public object[] TwoOfThreeTargetPlacards { get; set; }

        public object[] ThreeOfThreeTargetPlacards { get; set; }
    }
}
