namespace MOROPO.VIDERHE.Extend.Matrix.Templating.Models.Context.Contract
{
    public abstract class AbstractGrid1x3PlacardContextModel : AbstractGridPlacardContextModel
    {
        public object[] OneOfThreeTargetPlacards { get; set; }

        public object[] TwoOfThreeTargetPlacards { get; set; }

        public object[] ThreeOfThreeTargetPlacards { get; set; }
    }
}
